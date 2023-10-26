using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class PolicyCoverageMockRepo
    {
        public async Task<List<policycoverage>?> ReturnsPolicyCoverage()
        {
            var polcov = new List<policycoverage> { };
            return polcov;
        }
        public async Task<List<policycoverage>> ReturnsPolicyCoverageNull()
        {
            return null;
        }
        public async Task<List<coverages>?> ReturnsCoverage()
        {
            var cov = new List<coverages> { };
            return cov;
        }
        public async Task<List<coverages>?> ReturnsCoverageNull()
        {
            return null;
        }
    }
}
