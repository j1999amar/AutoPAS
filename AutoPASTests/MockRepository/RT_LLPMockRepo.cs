using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class RT_LLPMockRepo
    {
        public async Task<List<RT_LLP>> ReturnsData()
        {
            var rt_llp = new List<RT_LLP> { };
            return rt_llp;
        }
        public async Task<List<RT_LLP>> ReturnsNull()
        {
            return null;
        }
    }
}
