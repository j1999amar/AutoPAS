using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASAL;
using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;

namespace AutoPASSL.Repository
{
    public class BrandsRepo : IBrandsRepo
    {
        private readonly APASDBContext _context;

        public BrandsRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<List<Brands>> GetBrandByVehicleType(int VehicleType)
        {
            List<Brands> brand = new List<Brands>();
            brand = await _context.brand.Where(x => x.VehicleTypeId == VehicleType).ToListAsync();
            if (brand == null) return null;
            return brand;
        }

        public async Task<List<Brands>> GetAllBrand()
        {
            List<Brands> brand = new List<Brands>();
            brand = await _context.brand.ToListAsync();
            if (brand == null) return null;
            return brand;
        }

        public async Task<Brands> AddBrands(Brands brands)
        {
            await _context.brand.AddAsync(brands);
            var brandIsAdded= await _context.SaveChangesAsync();
            return brandIsAdded>0?brands:null;
        }

        public bool IsExists(int id)
        {
            return _context.brand.Any(x=>x.BrandId == id);
        }

        public bool vehicleTypeIdIsExists(int id)
        {
            return _context.vehicleType.Any(x => x.VehicleTypeId == id);
        }
    }
}
