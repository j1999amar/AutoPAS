using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL
{
    public class VehicleTypeService:IVehicleTypeService
    {
        private readonly IVehicleTypeRepo _vehicleTypeRepo;
        public VehicleTypeService(IVehicleTypeRepo vehicleTypeRepo)
        {
            _vehicleTypeRepo = vehicleTypeRepo;
        }

        public Task<List<vehicleType>> GetAllVehicleType()
        {
            var veh=_vehicleTypeRepo.GetAllVehicleType();
            return veh;
        }
    }
}
