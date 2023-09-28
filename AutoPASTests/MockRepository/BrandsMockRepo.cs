using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class BrandsMockRepo
    {
        public async Task<List<Brands>> ReturnsBrand()
        {
            var brands = new List<Brands>{};
            return brands;
        }
        public async Task<List<Brands>> ReturnsNull()
        {
            return null;
        }
    }
}
