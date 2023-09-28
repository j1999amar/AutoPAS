using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class RTOMockRepo
    {
        public async Task<List<rto>?> ReturnsRTO()
        {
            var rto = new List<rto> { };
            return rto;
        }
        public async Task<List<rto>?> ReturnsNull()
        {
            return null;
        }
    }
}
