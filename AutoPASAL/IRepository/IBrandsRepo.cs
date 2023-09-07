using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;

namespace AutoPASAL.IRepository
{
    public interface IBrandsRepo
    {
        Task<List<Brands>> GetBrandByVehicleType(int VehicleType);
        Task<List<Brands>> GetAllBrand();
    }
}
