﻿using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IPolicyService
    {
        Task<List<policy>> GetAllPolicies();
        Task<List<policy>> GetPoliciesInRange(int startIndex, int count);
        Task<int> GetPolicyCount();
        Task<List<policy>?> GetPolicyById(Guid Id);
        Task<policy> AddPolicy(policy objPolicy);
        Task<policy?> UpdatePolicyNCB(int NCB);
        Task<policy?> UpdatePolicyById(Guid Id, policy objPolicy);
        Task<int> GetNCBById(Guid Id);
    }
}
