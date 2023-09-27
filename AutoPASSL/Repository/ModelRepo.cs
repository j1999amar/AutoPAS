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

        public async Task<model> AddModels(model models)
        {
            await _context.model.AddAsync(models);
            var modelIsAdded=await _context.SaveChangesAsync();
            return modelIsAdded>0? models : null;
        }

        public bool IsExists(int id)
        {
            return _context.model.Any(x=>x.ModelId == id);
        }

        public bool brandIdIsExists(int id)
        {
            return _context.brand.Any(x => x.BrandId == id);

        }

        public async Task<model> EditModels(model models)
        {
            _context.model.Entry(models).State = EntityState.Modified;
            var change = await _context.SaveChangesAsync();
            return change > 0 ? models : null;
        }

        public bool DeleteModels(int id)
        {
                var models = _context.model.Find(id);
                _context.model.Remove(models);
                var change = _context.SaveChanges();
                return change > 0 ? true : false;
        
          
            
        }
    }
}
