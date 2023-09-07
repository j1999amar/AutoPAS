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
    public class PolicyInsuredService:IPolicyInsuredService
    {
        private readonly IPolicyInsuredRepo _policyInsuredRepo;
        public PolicyInsuredService(IPolicyInsuredRepo policyInsuredRepo)
        {
            _policyInsuredRepo = policyInsuredRepo;
        }

        public Task<PolicyInsured> Insertpolicyinsured(PolicyInsured PolicyInsured)
        {
            var obj = _policyInsuredRepo.Insertpolicyinsured(PolicyInsured);
            return obj;
        }
    }
}
