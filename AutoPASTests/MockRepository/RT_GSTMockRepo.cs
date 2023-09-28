using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class RT_GSTMockRepo
    {
        public async Task<List<RT_GST>> ReturnsData()
        {
            var rt_gst = new List<RT_GST> { };
            return rt_gst;
        }
        public async Task<List<RT_GST>> ReturnsNull()
        {
            return null;
        }
    }
}
