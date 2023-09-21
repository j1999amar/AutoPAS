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
    public class VehicleTypeRepo:IVehicleTypeRepo
    {
        private readonly APASDBContext _context;
        public VehicleTypeRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<vehicleType> AddVehicleType(vehicleType vehicleType)
        {
            await _context.vehicleType.AddAsync(vehicleType);
            var vehicleTypeIsAdded=await _context.SaveChangesAsync();
            return vehicleTypeIsAdded > 0 ? vehicleType : null;

        }

        public async Task<vehicleType> EditVehicleType(vehicleType vehicleType)
        {
            _context.vehicleType.Entry(vehicleType).State = EntityState.Modified;
            var change =await _context.SaveChangesAsync();
            return change > 0 ? vehicleType : null;
        }

        public async Task<List<vehicleType>> GetAllVehicleType()
        {
            var vehicletype = await _context.vehicleType.ToListAsync();
            if (vehicletype == null) return null;
            return vehicletype;
        }

        public bool IsExists(int id)
        {
            return _context.vehicleType.Any(x=>x.VehicleTypeId == id);
        }
    }
}
