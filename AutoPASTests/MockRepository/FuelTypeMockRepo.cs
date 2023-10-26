using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class FuelTypeMockRepo
    {
        public async Task<List<fueltype>> ReturnsFuelTypes()
        {
            var fuel = new List<fueltype> { };
            return fuel;
        }
        public async Task<List<fueltype>> ReturnsNull()
        {
            return null;
        }
    }

}
