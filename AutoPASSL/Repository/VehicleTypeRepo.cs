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
        public async Task<List<vehicleType>> GetAllVehicleType()
        {
            var vehicletype = await _context.vehicleType.ToListAsync();
            if (vehicletype == null) return null;
            return vehicletype;
        }
    }
}
