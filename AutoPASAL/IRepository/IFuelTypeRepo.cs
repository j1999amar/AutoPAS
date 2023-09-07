using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;

namespace AutoPASAL.IRepository
{
    public interface IFuelTypeRepo
    {
        Task<List<fueltype>> GetFuelTypes(int ModelId);
        Task<List<fueltype>> GetAllFuelTypes();
    }
}
