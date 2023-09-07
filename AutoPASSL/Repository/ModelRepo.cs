using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class ModelRepo:IModelRepo
    {
        private readonly APASDBContext _context;
        public ModelRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task<List<model>> GetModelByBrand(int Brandid)
        {
            List<model> model = new List<model>();
            model = await _context.model.Where(x => x.BrandId == Brandid).ToListAsync();
            if (model == null) return null;
            return model;
        }
        public async Task<List<model>> GetAllModel()
        {
            List<model> model = new List<model>();
            model = await _context.model.ToListAsync();
            if (model == null) return null;
            return model;
        }
    }
}
