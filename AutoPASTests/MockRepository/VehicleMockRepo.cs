using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class VehicleMockRepo
    {
        public async Task<List<vehicle>> ReturnsVehicle()
        {
            var vehicles = new List < vehicle> { };
            return vehicles;
        }
        public async Task<List<vehicle>> ReturnsNull()
        {
            return null;
        }
        public async Task<object> ReturnsPolicyVehicle()
        {
            var vehpol = new object { };
            return vehpol;
        }
        public async Task<object> ReturnsPolicyVehicleNull()
        {
            return null;
        }
    }
}
