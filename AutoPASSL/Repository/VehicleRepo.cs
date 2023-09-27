using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class VehicleRepo: IVehicleRepo
    {
        private readonly APASDBContext _context;
        private readonly IPolicyVehicleRepo _policyVehicleRepo;

        public VehicleRepo(APASDBContext context, IPolicyVehicleRepo policyVehicleRepo)
        {
            _context = context;
            _policyVehicleRepo= policyVehicleRepo;
        }

        public async Task<List<vehicle>> GetAllVehicles()
        {
            var vehicles = await _context.vehicle.ToListAsync();
            return vehicles;
        }

        public async Task<List<vehicle>?> GetVehicleById(Guid Id)
        {
            var vehicle = await _context.PolicyVehicle.FirstOrDefaultAsync(x => x.PolicyId == Id);
            var vehicleid = vehicle.VehicleId;
            var veh = await _context.vehicle.Where(x => x.VehicleId == vehicleid).ToListAsync();
            return veh;
        }
        public async Task<List<RTO>?> GetAllRTOState()
        {
            var rtos = await _context.rto.GroupBy(x => x.State).Select(g => g.OrderBy(x => x.State).FirstOrDefault()).ToListAsync();
            if (rtos == null) return null;
            return rtos;
        }
        public async Task<List<RTO>?> GetRTOCityByState(string state)
        {
            var rtos = await _context.rto.Where(x => x.State.ToLower() == state.ToLower()).GroupBy(x => x.City).Select(g => g.OrderBy(x => x.City).FirstOrDefault()).ToListAsync();
            if (rtos == null) return null;
            return rtos;
        }
        public async Task<List<RTO>?> GetRTONameByCity(string city)
        {
            var rtos = await _context.rto.Where(x => x.City.ToLower() == city.ToLower()).ToListAsync();
            if (rtos == null) return null;
            return rtos;
        }
        public async Task<List<Brands>> GetBrandByVehicleType(int VehicleType)
        {
            List<Brands> brand = new List<Brands>();
            brand = await _context.brand.Where(x => x.VehicleTypeId == VehicleType).ToListAsync();
            if (brand == null) return null;
            return brand;
        }

        public async Task<vehicle> AddVehicle(vehicle objvehicle)
        {
            await _context.vehicle.AddAsync(objvehicle);
            await _context.SaveChangesAsync();

            // Saving VehicleId and PolicyId to the PolicyVehicle table.
            PolicyVehicle objPolicyVehicle = new PolicyVehicle();
            objPolicyVehicle.PolicyId = SessionVariables.PolicyId;
            objPolicyVehicle.VehicleId = objvehicle.VehicleId;
            await _policyVehicleRepo.Insertpolicyvehicle(objPolicyVehicle);
            //--- End ---
            return objvehicle;
        }
        public async Task<vehicle> UpdateVehicleById(Guid Id, vehicle objvehicle)
        {
            var vehicle = await _context.PolicyVehicle.FirstOrDefaultAsync(x => x.PolicyId == Id);
            var vehicleid = vehicle.VehicleId;
            var veh = await _context.vehicle.FirstOrDefaultAsync(y => y.VehicleId == vehicleid);
            if (veh != null)
            {
                veh.RTOId = objvehicle.RTOId;
                veh.VehicleTypeid = objvehicle.VehicleTypeid;
                veh.BrandId = objvehicle.BrandId;
                veh.ModelId = objvehicle.ModelId;
                veh.VariantId = objvehicle.VariantId;
                veh.BodyTypeId = objvehicle.BodyTypeId;
                veh.FuelTypeId = objvehicle.FuelTypeId;
                veh.TransmissionTypeId = objvehicle.TransmissionTypeId;
                veh.RegistrationNumber = objvehicle.RegistrationNumber;
                veh.DateOfPurchase = objvehicle.DateOfPurchase;
                veh.Color = objvehicle.Color;
                veh.ChasisNumber = objvehicle.ChasisNumber;
                veh.EngineNumber = objvehicle.EngineNumber;
                veh.CubicCapacity = objvehicle.CubicCapacity;
                veh.SeatingCapacity = objvehicle.SeatingCapacity;
                veh.YearOfManufacture = objvehicle.YearOfManufacture;
                veh.IDV = objvehicle.IDV;
                veh.ExShowroomPrice = objvehicle.ExShowroomPrice;
                _context.Entry(veh).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return veh;
        }
    }
}
