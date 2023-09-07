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
    public class VariantService:IVariantService
    {
        private readonly IVariantRepo _variantRepo;
        public VariantService(IVariantRepo variantRepo)
        {
            _variantRepo = variantRepo;
        }
        public Task<List<variant>?> GetAllVariant()
        {
            var vari= _variantRepo.GetAllVariant();
            return vari;
        }
        public Task<List<variant>?> GetVariant(int ModelId, int FuelId, int TransmissionId)
        {
            var vari=_variantRepo.GetVariant(ModelId, FuelId, TransmissionId);
            return vari;
        }
    }
}
