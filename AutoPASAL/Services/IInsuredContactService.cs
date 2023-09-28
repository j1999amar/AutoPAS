using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;

namespace AutoPASAL.Services
{
    public interface IInsuredContactService
    {
        Task<insuredContact> AddInsuredContact(insuredContact objInsuredContact);
        Task<insuredContact> EditInsuredContact(Guid Id, insuredContact objInsuredContact);
        Task<List<insured>?> GetInsuredById(Guid Id);
        Task<List<contact>?> GetContactById(Guid Id);
        Task<object> GetInsuredContactByPolicyNumber(string policynumber);
    }
}
