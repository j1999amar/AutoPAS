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

        public async Task<fueltype> AddFuelType(fueltype fuelType)
        {
            return await _fuelTypeRepo.AddFuelType(fuelType);
        }

        public  bool IsExists(int id)
        {
            return  _fuelTypeRepo.IsExists(id);
        }

        public Task<fueltype> EditFuelType(fueltype fuelType)
        {
            return _fuelTypeRepo.EditFuelType(fuelType);
        }

        public bool DeleteFuelType(int id)
        {
            return _fuelTypeRepo.DeleteFuelType(id);
        }
    }
}
