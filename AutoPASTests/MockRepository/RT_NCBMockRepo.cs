using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class RT_NCBMockRepo
    {
        public async Task<List<RT_NCB>> ReturnsData()
        {
            var rt_ncb = new List<RT_NCB> { };
            return rt_ncb;
        }
        public async Task<List<RT_NCB>> ReturnsNull()
        {
            return null;
        }
    }
}
