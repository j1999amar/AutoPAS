using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;

namespace AutoPASAL.IRepository
{
    public interface IInsuredContactRepo
    {
        Task<insured> AddInsured(insured objinsured);
        Task<insured> EditInsured(Guid Id, insured objinsured);
        Task<List<insured>?> GetInsuredById(Guid Id);
        Task<List<contact>?> GetContactById(Guid Id);
        Task<contact> AddContact(contact objcontact);
        Task<contact> EditContact(Guid ContId, contact objcontact);
        Task<object> GetInsuredContactByPolicyNumber(string policynumber);
    }
}
