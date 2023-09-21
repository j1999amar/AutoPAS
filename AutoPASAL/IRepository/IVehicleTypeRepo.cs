using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IVehicleTypeRepo
    {
        Task<List<vehicleType>> GetAllVehicleType();
        Task<vehicleType> AddVehicleType(vehicleType vehicleType);
        Task<vehicleType> EditVehicleType(vehicleType vehicleType);
        public bool IsExists(int id);
    }
}
