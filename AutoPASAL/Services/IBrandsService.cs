using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;

namespace AutoPASAL.Services
{
    public interface IBrandsService
    {
        Task<List<Brands>> GetBrandByVehicleType(int Id);
        Task<List<Brands>> GetAllBrand();
        Task<Brands> AddBrands(Brands brands);
        public bool IsExists(int id);
        public bool vehicleTypeIdIsExists(int id);
    }
}
