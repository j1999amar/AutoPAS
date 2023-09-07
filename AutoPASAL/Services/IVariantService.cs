using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IVariantService
    {
        Task<List<variant>?> GetAllVariant();
        Task<List<variant>?> GetVariant(int ModelId, int FuelId, int TransmissionId);
    }
}
