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
    public class RT_LLPRepo:IRT_LLPRepo
    {
        private readonly APASDBContext _context;
        public RT_LLPRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<List<RT_LLP>> GetRT_LLP()
        {
            var rt_llp = await _context.rt_llp.ToListAsync();
            return rt_llp;
        }
        public async Task<List<RT_LLP>> GetRT_LLPById(int id)
        {
            var rt_llp = await _context.rt_llp.Where(x => x.id == id).ToListAsync();
            return rt_llp;
        }
        public async Task<RT_LLP> UpdateRT_LLPById(RT_LLP obj)
        {
            var rt_llp = await _context.rt_llp.FirstOrDefaultAsync(x => x.id == obj.id);
            if (rt_llp != null)
            {
                rt_llp.factor = obj.factor;
                _context.Entry(rt_llp).Property(p => p.factor).IsModified = true;
                await _context.SaveChangesAsync();
            }

            return rt_llp;

        }
        public async Task<RT_LLP> AddRT_LLPEntry(RT_LLP obj)
        {
            await _context.rt_llp.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<RT_LLP> DeleteRT_LLPEntry(int id)
        {
            var rt_llp = await _context.rt_llp.FirstOrDefaultAsync(x => x.id == id);
            if (rt_llp != null)
            {
                _context.rt_llp.Remove(rt_llp);
                await _context.SaveChangesAsync();
            }
            return rt_llp;
        }
    }
}
