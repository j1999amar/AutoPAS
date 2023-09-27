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
    public class VehicleService:IVehicleService
    {
        private readonly IVehicleRepo _vehicleRepo;
        public VehicleService(IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }
        public Task<List<vehicle>> GetAllVehicles()
        {
            var veh = _vehicleRepo.GetAllVehicles();
            return veh;
        }
        public Task<List<vehicle>?> GetVehicleById(Guid Id)
        {
            var veh = _vehicleRepo.GetVehicleById(Id);
            return veh;
        }
        public Task<List<RTO>?> GetAllRTOState()
        {
            var rto= _vehicleRepo.GetAllRTOState();
            return rto;
        }
        public Task<List<RTO>?> GetRTOCityByState(string state)
        {
            var rto = _vehicleRepo.GetRTOCityByState(state);
            return rto;
        }
        public Task<List<RTO>?> GetRTONameByCity(string city)
        {
            var rto = _vehicleRepo.GetRTONameByCity(city);
            return rto;
        }
        public Task<List<Brands>> GetBrandByVehicleType(int Id)
        {
            var brand = _vehicleRepo.GetBrandByVehicleType(Id);
            return brand;
        }
        public Task<vehicle> AddVehicle(vehicle objVehicle)
        {
            var obj= _vehicleRepo.AddVehicle(objVehicle);
            return obj;
        }
        public Task<vehicle> UpdateVehicleById(Guid Id, vehicle objVehicle)
        {
            var obj = _vehicleRepo.UpdateVehicleById(Id, objVehicle);
            return obj;
        }
    }
}
