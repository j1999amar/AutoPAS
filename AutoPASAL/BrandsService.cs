using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;

namespace AutoPASAL
{
    public class BrandsService : IBrandsService
    {
        public readonly IBrandsRepo _brandRepo;
        public BrandsService(IBrandsRepo brandsRepo) 
        { 
            _brandRepo = brandsRepo;
        }

        public async Task<List<Brands>> GetBrandByVehicleType(int VehicleType)
        {
            return await _brandRepo.GetBrandByVehicleType(VehicleType);
        }

        public async Task<List<Brands>> GetAllBrand()
        {
            return await _brandRepo.GetAllBrand();
        }
    }
}
