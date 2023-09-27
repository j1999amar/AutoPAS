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

        public Task<vehicleType> AddVehicleType(vehicleType vehicleType)
        {
            return _vehicleTypeRepo.AddVehicleType(vehicleType);
        }

        public bool DeleteVehicleType(int id)
        {
            return _vehicleTypeRepo.DeleteVehicleType(id);
        }

        public Task<vehicleType> EditVehicleType(vehicleType vehicleType)
        {
            return _vehicleTypeRepo.EditVehicleType(vehicleType);
        }

        public Task<List<vehicleType>> GetAllVehicleType()
        {
            var veh=_vehicleTypeRepo.GetAllVehicleType();
            return veh;
        }

        public bool IsExists(int id)
        {
            return _vehicleTypeRepo.IsExists(id);
        }
    }
}
