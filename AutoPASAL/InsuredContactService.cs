using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoPASAL
{
    public class InsuredContactService : IInsuredContactService
    {
        private readonly IInsuredContactRepo _insuredContactRepo;
        public InsuredContactService(IInsuredContactRepo insuredContactRepo)
        {
            _insuredContactRepo = insuredContactRepo;

        }

        public async Task<insuredContact> AddInsuredContact(insuredContact objInsuredContact)
        {
            contact con = objInsuredContact.contact;
            await _insuredContactRepo.AddContact(con);
            insured ins = objInsuredContact.insured;
            ins.ContactId = con.ContactId;
            ins.UserTypeId = 4;
            await _insuredContactRepo.AddInsured(ins);
            return objInsuredContact;
        }
        public async Task<insuredContact> EditInsuredContact(Guid Id, insuredContact objInsuredContact)
        {
            insured ins = objInsuredContact.insured;
            await _insuredContactRepo.EditInsured(Id,ins);
            var ContId = SessionVariables.ContactId;
            contact con = objInsuredContact.contact;
            await _insuredContactRepo.EditContact(ContId, con);
            return objInsuredContact;
        }
        public Task<List<insured>?> GetInsuredById(Guid Id)
        {
            var ins = _insuredContactRepo.GetInsuredById(Id);
            return ins;
        }
        public Task<List<contact>?> GetContactById(Guid Id)
        {
            var con = _insuredContactRepo.GetContactById(Id);
            return con;
        }
    }
}
