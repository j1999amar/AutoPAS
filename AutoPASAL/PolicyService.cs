using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL
{
    public class PolicyService:IPolicyService
    {
        private readonly IPolicyRepo _policyRepo;
        public PolicyService(IPolicyRepo policyRepo)
        {
            _policyRepo = policyRepo;
        }
        public Task<List<policy>> GetAllPolicies()
        {
            var pol= _policyRepo.GetAllPolicies();
            return pol;
        }
        public Task<List<policy>> GetPoliciesInRange(int startIndex, int count)
        {
            var pol = _policyRepo.GetPoliciesInRange(startIndex,count);
            return pol;
        }
        public Task<int> GetPolicyCount()
        {
            var count = _policyRepo.GetPolicyCount();
            return count;
        }
        public Task<List<policy>?> GetPolicyById(Guid Id)
        {
            SessionVariables.PolicyId = Id;
            var pol = _policyRepo.GetPolicyById(Id);
            return pol;
        }
        public Task<policy> AddPolicy(policy objPolicy)
        {
            var pol = _policyRepo.AddPolicy(objPolicy);
            return pol;
        }
        public Task<policy?> UpdatePolicyNCB(int NCB)
        {
            var pol = _policyRepo.UpdatePolicyNCB( NCB);
            return pol;
        }
        public Task<policy?> UpdatePolicyById(Guid Id, policy objPolicy)
        {
            var pol = _policyRepo.UpdatePolicyById(Id, objPolicy);
            return pol;
        }
        public Task<int> GetNCBById(Guid Id)
        {
            var ncb = _policyRepo.GetNCBById(Id);
            return ncb;
        }
        public Task<List<policy>?> GetPolicyByPolicyNumber(string policynumber)
        {
            var pol = _policyRepo.GetPolicyByPolicyNumber(policynumber);
            return pol;
        }
    }
}
