using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IModelService
    {
        Task<List<model>> GetModelByBrand(int brandId);
        Task<List<model>> GetAllModel();
        Task<model> AddModels(model models);
        Task<model> EditModels(model models);
        public bool DeleteModels(int id);

        public bool IsExists(int id);
        public bool brandIdIsExists(int id);

    }
}
