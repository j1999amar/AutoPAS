using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IModelRepo
    {
        Task<List<model>> GetModelByBrand(int brandId);
        Task<List<model>> GetAllModel();
        Task<model> AddModels(model models);
        Task<model> EditModels(model models);
        public bool IsExists(int id);
        public bool brandIdIsExists(int id);

    }
}
