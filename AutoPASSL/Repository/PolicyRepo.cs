using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class PolicyRepo: IPolicyRepo
    {
        private readonly APASDBContext _context;

        public PolicyRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<List<policy>> GetAllPolicies()
        {
            var policies = await _context.policy.ToListAsync();
            if (policies == null) return null;
            return policies;
        }
        public async Task<List<policy>> GetPoliciesInRange(int startIndex, int count)
        {
            var policies = await _context.policy
                .Skip(startIndex)
                .Take(count)
                .ToListAsync();
            if (policies == null) return null;
            return policies;
        }

        public async Task<int> GetPolicyCount()
        {
            var count = await _context.policy.CountAsync();
            return count;
        }
        public async Task<policy> AddPolicy(policy objpolicy)
        {
            await _context.policy.AddAsync(objpolicy);
            await _context.SaveChangesAsync();
            SessionVariables.PolicyId = objpolicy.PolicyId;
            return objpolicy;
        }

        public async Task<List<policy>?> GetPolicyById(Guid Id)
        {
            SessionVariables.PolicyId = Id;
            var pol = await _context.policy.Where(x => x.PolicyId == Id).ToListAsync();
            if (pol == null) return null;
            return pol;
        }
        public async Task<policy?> UpdatePolicyNCB(int NCB)
        {
            var id = SessionVariables.PolicyId;
            var pol = await _context.policy.FirstOrDefaultAsync(x => x.PolicyId == id);
            if (pol != null)
            {
                pol.EligibleForNCB = NCB;
                _context.Entry(pol).Property(p => p.EligibleForNCB).IsModified = true;
                await _context.SaveChangesAsync();
            }
            return pol;
        }
        public async Task<policy> UpdatePolicyById(Guid Id, policy objpolicy)
        {
            var pol = await _context.policy.FirstOrDefaultAsync(x => x.PolicyId == Id);
            if (pol != null)
            {
                pol.PolicyEffectiveDt = objpolicy.PolicyEffectiveDt;
                pol.PolicyExpirationDt = objpolicy.PolicyExpirationDt;
                pol.Term = objpolicy.Term;
                _context.Entry(pol).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            SessionVariables.PolicyId = objpolicy.PolicyId;
            return pol;
        }
        public async Task<int> GetNCBById(Guid Id)
        {
            var pol = await _context.policy.FirstOrDefaultAsync(x => x.PolicyId == Id);
            if (pol != null)
            {
                return pol.EligibleForNCB;
            }
            return 10;
        }
        public async Task<List<policy>?> GetPolicyByPolicyNumber(string policynumber)
        {
            var pol = await _context.policy.Where(x => x.PolicyNumber.ToString() == policynumber).ToListAsync();
            return pol;
        }
    }
}
