using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;

namespace AutoPASSL.Repository
{
    public class RT_TPCRepo: IRT_TPCRepo
    {
        private readonly APASDBContext _context;
        public RT_TPCRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task<List<RT_TPC>> GetRT_TPC()
        {
            var rt_tpc = await _context.rt_tpc.ToListAsync();
            return rt_tpc;
        }
        public async Task<List<RT_TPC>> GetRT_TPCById(int id)
        {

            var rt_tpc = await _context.rt_tpc.Where(x => x.id == id).ToListAsync();
            return rt_tpc;
        }
        public async Task<RT_TPC> UpdateRT_TPCById(RT_TPC obj)
        {
            var rt_tpc = await _context.rt_tpc.FirstOrDefaultAsync(x => x.id == obj.id);
            if (rt_tpc != null)
            {
                rt_tpc.factor =obj.factor;
                rt_tpc.vehicle_status = obj.vehicle_status;
                rt_tpc.claim_year = obj.claim_year;
                _context.Entry(rt_tpc).Property(p => p.factor).IsModified = true;
                await _context.SaveChangesAsync();
            }
            return rt_tpc;
        }
        public async Task<RT_TPC> AddRT_TPCEntry(RT_TPC obj)
        {
            await _context.rt_tpc.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<RT_TPC> DeleteRT_TPCEntry(int id)
        {
            var rt_tpc = await _context.rt_tpc.FirstOrDefaultAsync(x => x.id == id);
            if (rt_tpc != null)
            {
                _context.rt_tpc.Remove(rt_tpc);
                await _context.SaveChangesAsync();
            }
            return rt_tpc;
        }
    }
}
