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
    public class RT_NCBService:IRT_NCBService
    {
        private readonly IRT_NCBRepo _rt_ncbRepo;
        public RT_NCBService(IRT_NCBRepo rt_ncbRepo)
        {
            _rt_ncbRepo = rt_ncbRepo;
        }
        public Task<List<RT_NCB>> GetRT_NCB()
        {
            var rt_ncb= _rt_ncbRepo.GetRT_NCB();
            return rt_ncb;
        }
        public Task<List<RT_NCB>> GetRT_NCBById(int id)
        {
            var rt_ncb = _rt_ncbRepo.GetRT_NCBById(id);
            return rt_ncb;
        }
        public Task<RT_NCB> UpdateRT_NCBById(RT_NCB obj)
        {
            var rt_ncb = _rt_ncbRepo.UpdateRT_NCBById(obj);
            return rt_ncb;
        }
        public Task<RT_NCB> AddRT_NCBEntry(RT_NCB obj)
        {
            var rt_ncb = _rt_ncbRepo.AddRT_NCBEntry(obj);
            return rt_ncb;
        }
        public Task<RT_NCB> DeleteRT_NCBEntry(int id)
        {
            var rt_ncb = _rt_ncbRepo.DeleteRT_NCBEntry(id);
            return rt_ncb;
        }
    }
}
