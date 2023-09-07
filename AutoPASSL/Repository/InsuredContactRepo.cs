using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;

namespace AutoPASSL.Repository
{
    public class InsuredContactRepo : IInsuredContactRepo
    {
        private readonly APASDBContext _context;
        private readonly IPolicyInsuredRepo _policyInsuredRepo;
        public InsuredContactRepo(APASDBContext context, IPolicyInsuredRepo policyInsuredRepo)
        {
            _context = context;
            _policyInsuredRepo = policyInsuredRepo;
        }
        public async Task<insured> AddInsured(insured objinsured)
        {
            await _context.insured.AddAsync(objinsured);
            await _context.SaveChangesAsync();
            // Saving InsuredId and PolicyId to the PolicyInsured table.
            PolicyInsured objPolicyInsured = new PolicyInsured();
            objPolicyInsured.PolicyId = SessionVariables.PolicyId.ToString();
            objPolicyInsured.InsuredId = objinsured.InsuredId.ToString();
            await _policyInsuredRepo.Insertpolicyinsured(objPolicyInsured);
            //--- End ---
            return objinsured;
        }
        public async Task<insured> EditInsured(Guid Id, insured objinsured)
        {
            var ins = await _context.PolicyInsured.FirstOrDefaultAsync(x => x.PolicyId == Id.ToString());
            var insid = ins.InsuredId;
            var insure = await _context.insured.FirstOrDefaultAsync(y => y.InsuredId.ToString() == insid);
            if (insure != null)
            {
                insure.FirstName = objinsured.FirstName;
                insure.LastName = objinsured.LastName;
                insure.AadharNumber = objinsured.AadharNumber;
                insure.LicenseNumber = objinsured.LicenseNumber;
                insure.PANNumber = objinsured.PANNumber;
                insure.AccountNumber = objinsured.AccountNumber;
                insure.IFSCCode = objinsured.IFSCCode;
                insure.BankName = objinsured.BankName;
                insure.BankAddress = objinsured.BankAddress;
                _context.Entry(insure).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            SessionVariables.ContactId = insure.ContactId;
            return insure;
        }
        public async Task<List<insured>?> GetInsuredById(Guid Id)
        {
            var insured = await _context.PolicyInsured.FirstOrDefaultAsync(x => x.PolicyId == Id.ToString());
            var insuredid = insured.InsuredId;
            var ins = await _context.insured.Where(x => x.InsuredId.ToString() == insuredid).ToListAsync();
            return ins;
        }
        public async Task<List<contact>?> GetContactById(Guid Id)
        {
            var insured = await _context.PolicyInsured.FirstOrDefaultAsync(x => x.PolicyId == Id.ToString());
            var insuredid = insured.InsuredId;
            var insure = await _context.insured.FirstOrDefaultAsync(y => y.InsuredId.ToString() == insuredid);
            var contactid = insure.ContactId;
            var con = await _context.contact.Where(x => x.ContactId == contactid).ToListAsync();
            return con;
        }
        public async Task<contact> AddContact(contact objcontact)
        {
            await _context.contact.AddAsync(objcontact);
            await _context.SaveChangesAsync();
            return objcontact;
        }
        public async Task<contact> EditContact(Guid ContId, contact objcontact)
        {
            var con = await _context.contact.FirstOrDefaultAsync(x => x.ContactId == ContId);
            if (con != null)
            {
                con.FirstName = objcontact.FirstName;
                con.LastName = objcontact.LastName;
                con.AddressLine1 = objcontact.AddressLine1;
                con.AddressLine2 = objcontact.AddressLine2;
                con.Pincode = objcontact.Pincode;
                con.City = objcontact.City;
                con.State = objcontact.State;
                con.MobileNo = objcontact.MobileNo;
                con.Email = objcontact.Email;
                _context.Entry(con).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return con;
        }
    }
}
