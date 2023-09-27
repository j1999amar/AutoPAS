using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IVehicleTypeService
    {
        Task<List<vehicleType>> GetAllVehicleType();
        Task<vehicleType> AddVehicleType(vehicleType vehicleType);
        Task<vehicleType> EditVehicleType(vehicleType vehicleType);
        public bool DeleteVehicleType(int id);
        public bool IsExists(int id);
    }
}
