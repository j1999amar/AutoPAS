using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IVariantRepo
    {
        Task<List<variant>?> GetAllVariant();
        Task<List<variant>?> GetVariant(int ModelId, int FuelId, int TransmissionId);
        Task<variant> AddVariant(variant variant);
        Task<variant> EditVariant(variant variant);
        public bool IsExists(int id);
    }
}
