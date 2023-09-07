using AutoPASAL.IRepository;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class PolicyInsuredRepo : IPolicyInsuredRepo
    {
        private readonly APASDBContext _context;
        public PolicyInsuredRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<PolicyInsured> Insertpolicyinsured(PolicyInsured objpolicyinsured)
        {
            await _context.PolicyInsured.AddAsync(objpolicyinsured);
            await _context.SaveChangesAsync();
            return objpolicyinsured;

        }
    }
}
