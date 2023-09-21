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
        public async Task<Brands> AddBrands(Brands brands)
        {
            return await _brandRepo.AddBrands(brands);
        }

        public bool IsExists(int id)
        {
            return _brandRepo.IsExists(id);
        }

        public bool vehicleTypeIdIsExists(int id)
        {
            return _brandRepo.vehicleTypeIdIsExists(id);
        }

        public Task<Brands> EditBrands(Brands brands)
        {
            return _brandRepo.EditBrands(brands);
        }
    }
}
