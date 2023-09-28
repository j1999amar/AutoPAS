using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class VariantMockRepo
    {
        public async Task<List<variant>?> ReturnsVariants()
        {
            var variant = new List<variant> { };
            return variant;
        }
        public async Task<List<variant>?> ReturnsNull()
        {
            return null;
        }
    }
}
