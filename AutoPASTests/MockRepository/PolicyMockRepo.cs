using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class PolicyMockRepo
    {
        public async Task<List<policy>?> ReturnsPolicy()
        {
            var policies = new List<policy> { };
            return policies;
        }
        public async Task<List<policy>?> ReturnsNullPolicy()
        {
            return null;
        }
        public async Task<int> ReturnsONE()
        {
            return 1;
        }
        public async Task<int> ReturnsZERO()
        {
            return 0;
        }
        public async Task<int> ReturnsTWO()
        {
            return 2;
        }
    }
}
