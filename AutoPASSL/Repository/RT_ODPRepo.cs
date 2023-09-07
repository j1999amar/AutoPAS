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
    public class RT_ODPRepo: IRT_ODPRepo
    {
        private readonly APASDBContext _context;
        public RT_ODPRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task<List<RT_ODP>> GetRT_ODP()
        {
            var rt_odp = await _context.rt_odp.ToListAsync();
            return rt_odp;
        }
        public async Task<List<RT_ODP>> GetRT_ODPById(int id)
        {
            var rt_odp = await _context.rt_odp.Where(x => x.id == id).ToListAsync(); 
            return rt_odp;
        }

        public async Task<RT_ODP> UpdateRT_ODPById(RT_ODP obj)
        {
            var rt_odp = await _context.rt_odp.FirstOrDefaultAsync(x => x.id == obj.id);
            if (rt_odp != null)
            {
                rt_odp.factor = obj.factor;
                rt_odp.depreciation = obj.depreciation;
                rt_odp.year = obj.year;
                rt_odp.ins_type= obj.ins_type;
                rt_odp.part_type = obj.part_type;
                _context.Entry(rt_odp).Property(p => p.factor).IsModified = true;
                await _context.SaveChangesAsync();
            }

            return rt_odp;

        }
        public async Task<RT_ODP> AddRT_ODPEntry(RT_ODP obj)
        {
            await _context.rt_odp.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<RT_ODP> DeleteRT_ODPEntry(int id)
        {
            var rt_odp = await _context.rt_odp.FirstOrDefaultAsync(x => x.id == id);
            if (rt_odp != null)
            {
                _context.rt_odp.Remove(rt_odp);
                await _context.SaveChangesAsync();
            }
            return rt_odp;
        }
    }
}
