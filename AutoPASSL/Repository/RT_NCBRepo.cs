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
    public class RT_NCBRepo:IRT_NCBRepo
    {
        private readonly APASDBContext _context;
        public RT_NCBRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<List<RT_NCB>> GetRT_NCB()
        {
            var rt_ncb= await _context.rt_ncb.ToListAsync();
            return rt_ncb;
        }
        public async Task<List<RT_NCB>> GetRT_NCBById(int id)
        {
            var rt_ncb = await _context.rt_ncb.Where(x => x.ID == id).ToListAsync();
            return rt_ncb;
        }
        public async Task<RT_NCB> UpdateRT_NCBById(RT_NCB obj)
        {
            var rt_ncb = await _context.rt_ncb.FirstOrDefaultAsync(x => x.ID == obj.ID);
            if (rt_ncb != null)
            {
                rt_ncb.factor = obj.factor;
                rt_ncb.no_claim_year = obj.no_claim_year;
                _context.Entry(rt_ncb).Property(p => p.factor).IsModified = true;
                await _context.SaveChangesAsync();
            }
            return rt_ncb;
        }
        public async Task<RT_NCB> AddRT_NCBEntry(RT_NCB obj)
        {
            await _context.rt_ncb.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<RT_NCB> DeleteRT_NCBEntry(int id)
        {
            var rt_ncb = await _context.rt_ncb.FirstOrDefaultAsync(x => x.ID == id);
            if (rt_ncb != null)
            {
                _context.rt_ncb.Remove(rt_ncb);
                await _context.SaveChangesAsync();
            }
            return rt_ncb;
        }
    }
}
