using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class VehicleTypeMockRepo
    {
        public async Task<List<vehicleType>?> ReturnsVehicleType()
        {
            var veh = new List<vehicleType> { };
            return veh;
        }
        public async Task<List<vehicleType>?> ReturnsNull()
        {
            return null;
        }
    }
}
