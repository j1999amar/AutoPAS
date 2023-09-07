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
    public class RT_GSTRepo:IRT_GSTRepo
    {
        private readonly APASDBContext _context;
        public RT_GSTRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<List<RT_GST>> GetRT_GST()
        {
            var rt_gst = _context.rt_gst.ToList();
            return rt_gst;
        }
        public async Task<List<RT_GST>> GetRT_GSTById(int id)
        {

            var rt_gst = await _context.rt_gst.Where(x => x.id == id).ToListAsync();
            return rt_gst;
        }
        public async Task<RT_GST> UpdateRT_GSTById(RT_GST obj)
        {
            var rt_gst = await _context.rt_gst.FirstOrDefaultAsync(x => x.id == obj.id);
            if (rt_gst != null)
            {
                rt_gst.factor = obj.factor;
                _context.Entry(rt_gst).Property(p => p.factor).IsModified = true;
                await _context.SaveChangesAsync();
            }

            return rt_gst;

        }
        public async Task<RT_GST> AddRT_GSTEntry(RT_GST obj)
        {
            await _context.rt_gst.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task <RT_GST> DeleteRT_GSTEntry(int id)
        {
            var rt_gst = await _context.rt_gst.FirstOrDefaultAsync(x => x.id == id);
            if (rt_gst != null)
            {
                _context.rt_gst.Remove(rt_gst);
                await _context.SaveChangesAsync();
            }
            return rt_gst;
        }
    }
}
