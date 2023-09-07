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
    public class PolicyCoverageRepo:IPolicyCoverageRepo
    {
        private readonly APASDBContext _context;
        public PolicyCoverageRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task<policycoverage> AddPolicyCoverage(List<int> coverageID)
        {
            policycoverage objpolicycoverage = null;

            foreach (var id in coverageID)
            {
                objpolicycoverage = new policycoverage();
                objpolicycoverage.CoverageId = id;
                objpolicycoverage.Limit = 1;
                objpolicycoverage.PolicyId = SessionVariables.PolicyId;
                await _context.policycoverage.AddAsync(objpolicycoverage);
                await _context.SaveChangesAsync();
            }

            return objpolicycoverage;
        }
        public async Task<policycoverage> EditPolicyCoverage(Guid Id, List<int> coverageID)
        {
            var existingCoverages = await _context.policycoverage.Where(x => x.PolicyId == Id).ToListAsync();

            foreach (var coverage in existingCoverages)
            {
                if (!coverageID.Contains(coverage.CoverageId))
                {
                    coverage.Limit = 0;
                }
                else
                {
                    coverage.Limit = 1;
                }
            }
            var existingCoverageIds = existingCoverages.Select(c => c.CoverageId).ToList();
            var newCoverages = coverageID.Where(c => !existingCoverageIds.Contains(c));
            policycoverage objpolicycoverage = null;
            foreach (var newCoverageId in newCoverages)
            {
                var newCoverage = new policycoverage();
                newCoverage.CoverageId = newCoverageId;
                newCoverage.Limit = 1;
                newCoverage.PolicyId = Id;
                _context.policycoverage.Add(newCoverage);
                await _context.SaveChangesAsync();
            }
            return objpolicycoverage;
        }

        public async Task<List<policycoverage>?> GetPolicyCoverageById(Guid Id)
        {
            var pol = await _context.policycoverage.Where(x => x.PolicyId == Id && x.Limit == 1).ToListAsync();
            return pol;
        }
    }
}
