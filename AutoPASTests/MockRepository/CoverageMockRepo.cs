using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class CoverageMockRepo
    {
        public async Task<List<coverages>?> ReturnsCoverage()
        {
            var coverages = new List<coverages> { };
            return coverages;
        }
        public async Task<List<coverages>?> ReturnsNull()
        {
            return null;
        }
    }
}
