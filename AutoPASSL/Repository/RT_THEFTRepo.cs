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
    public class RT_THEFTRepo:IRT_THEFTRepo
    {
        private readonly APASDBContext _context;
        public RT_THEFTRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task<List<RT_THEFT>> GetRT_THEFT()
        {
            var rt_theft = await _context.rt_theft.ToListAsync();
            return rt_theft;
        }
        public async Task<List<RT_THEFT>> GetRT_THEFTById(int id)
        {
            var rt_theft = await _context.rt_theft.Where(x => x.id == id).ToListAsync();
            return rt_theft;
        }
        public async Task<RT_THEFT> UpdateRT_THEFTById(RT_THEFT obj)
        {
            var rt_theft = await _context.rt_theft.FirstOrDefaultAsync(x => x.id == obj.id);
            if (rt_theft != null)
            {
                rt_theft.factor = obj.factor;
                _context.Entry(rt_theft).Property(p => p.factor).IsModified = true;
                await _context.SaveChangesAsync();
            }
            return rt_theft;
        }
        public async Task<RT_THEFT> AddRT_THEFTEntry(RT_THEFT obj)
        {
            await _context.rt_theft.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<RT_THEFT> DeleteRT_THEFTEntry(int id)
        {
            var rt_theft = await _context.rt_theft.FirstOrDefaultAsync(x => x.id == id);
            if (rt_theft != null)
            {
                _context.rt_theft.Remove(rt_theft);
                await _context.SaveChangesAsync();
            }
            return rt_theft;
        }
    }
}
