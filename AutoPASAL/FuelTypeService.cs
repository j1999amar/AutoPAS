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
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IFuelTypeRepo _fuelTypeRepo;

        public FuelTypeService(IFuelTypeRepo fuelTypeRepo)
        {
            _fuelTypeRepo = fuelTypeRepo;
        }

        public async Task<List<fueltype>> GetFuelTypes(int ModelId)
        {
            return await _fuelTypeRepo.GetFuelTypes(ModelId);
        }
        public async Task<List<fueltype>> GetAllFuelTypes()
        {
            return await _fuelTypeRepo.GetAllFuelTypes();
        }
    }
}
