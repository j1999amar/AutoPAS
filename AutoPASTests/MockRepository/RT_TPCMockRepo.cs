using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class RT_TPCMockRepo
    {
        public async Task<List<RT_TPC>> ReturnsData()
        {
            var rt_tpc = new List<RT_TPC> { };
            return rt_tpc;
        }
        public async Task<List<RT_TPC>> ReturnsNull()
        {
            return null;
        }
    }
}
