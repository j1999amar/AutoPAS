using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class RT_THEFTMockRepo
    {
        public async Task<List<RT_THEFT>> ReturnsData()
        {
            var rt_theft = new List<RT_THEFT> { };
            return rt_theft;
        }
        public async Task<List<RT_THEFT>> ReturnsNull()
        {
            return null;
        }
    }
}
