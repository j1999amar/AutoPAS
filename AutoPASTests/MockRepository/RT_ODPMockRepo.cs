using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class RT_ODPMockRepo
    {
        public async Task<List<RT_ODP>> ReturnsData()
        {
            var rt_odp = new List<RT_ODP> { };
            return rt_odp;
        }
        public async Task<List<RT_ODP>> ReturnsNull()
        {
            return null;
        }
    }
}
