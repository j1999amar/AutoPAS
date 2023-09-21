using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class VariantRepo: IVariantRepo
    {
        private readonly APASDBContext _context;

        public VariantRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<variant> AddVariant(variant variant)
        {
            await _context.variant.AddAsync(variant);
            var variantIsAdded=await _context.SaveChangesAsync();
            return variantIsAdded > 0 ? variant : null;
        }

        public async Task<variant> EditVariant(variant variant)
        {
            _context.variant.Entry(variant).State = EntityState.Modified;
            var change = await _context.SaveChangesAsync();
            return change > 0 ? variant : null;
        }

        public async Task<List<variant>?> GetAllVariant()
        {
            List<variant> variant = new List<variant>();

            variant = await _context.variant.ToListAsync();
            if (variant == null) return null;
            return variant;
        }

        public async Task<List<variant>?> GetVariant(int ModelId, int FuelId, int TransmissionId)
        {
            List<variant> variant = new List<variant>();
            var id1 = _context.modelfueltype.Where(y => y.ModelId == ModelId && y.FuelTypeId == FuelId).Select(y => y.ModelFuelTypeId);
            var id2 = _context.modelfueltypevariant.Where(x => id1.Contains(x.ModelFuelTypeId) && x.TransmissionTypeId == TransmissionId).Select(x => x.VariantId);
            variant = await _context.variant.Where(z => id2.Contains(z.VariantId)).ToListAsync();
            if (variant == null) return null;
            return variant;
        }

        public bool IsExists(int id)
        {
            return _context.variant.Any(x=>x.VariantId== id);
        }
    }
}
