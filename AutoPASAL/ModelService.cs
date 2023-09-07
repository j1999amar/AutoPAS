using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL
{
    public class ModelService:IModelService
    {
        private readonly IModelRepo _modelRepo;
        public ModelService(IModelRepo modelRepo)
        {
            _modelRepo = modelRepo;
        }

        public Task<List<model>> GetModelByBrand(int brandId)
        {
            var mod= _modelRepo.GetModelByBrand(brandId);
            return mod;
        }
        public Task<List<model>> GetAllModel()
        {
            var mod = _modelRepo.GetAllModel();
            return mod;
        }
    }
}
