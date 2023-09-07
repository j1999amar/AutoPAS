using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASAL.IRepository;
using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;

namespace AutoPASSL.Repository
{
    public class FuelTypeRepo : IFuelTypeRepo
    {
        private readonly APASDBContext _context;
        public FuelTypeRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task<List<fueltype>> GetFuelTypes(int ModelId)
        {
            List<fueltype> fueltypes = new List<fueltype>();
            var types = _context.modelfueltype.Where(y => y.ModelId == ModelId).Select(y => y.FuelTypeId);
            fueltypes = await _context.fueltype.Where(x => types.Contains(x.FuelTypeId)).ToListAsync();
            if (fueltypes == null) return null;
            return fueltypes;
        }
        public async Task<List<fueltype>> GetAllFuelTypes()
        {
            List<fueltype> fueltypes = new List<fueltype>();
            fueltypes = await _context.fueltype.ToListAsync();
            if (fueltypes == null) return null;
            return fueltypes;
        }
    }
}
