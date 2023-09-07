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
    public class RT_THEFTService:IRT_THEFTService
    {
        private readonly IRT_THEFTRepo _rt_theftRepo;
        public RT_THEFTService(IRT_THEFTRepo rt_theftRepo)
        {
            _rt_theftRepo= rt_theftRepo;
        }
        public Task<List<RT_THEFT>> GetRT_THEFT()
        {
            var rt_theft= _rt_theftRepo.GetRT_THEFT();
            return rt_theft;
        }
        public Task<List<RT_THEFT>> GetRT_THEFTById(int id)
        {
            var rt_theft = _rt_theftRepo.GetRT_THEFTById(id);
            return rt_theft;
        }
        public Task<RT_THEFT> UpdateRT_THEFTById(RT_THEFT obj)
        {
            var rt_theft = _rt_theftRepo.UpdateRT_THEFTById(obj);
            return rt_theft;
        }
        public Task<RT_THEFT> AddRT_THEFTEntry(RT_THEFT obj)
        {
            var rt_theft = _rt_theftRepo.AddRT_THEFTEntry(obj);
            return rt_theft;
        }
        public Task<RT_THEFT> DeleteRT_THEFTEntry(int id)
        {
            var rt_theft = _rt_theftRepo.DeleteRT_THEFTEntry(id);
            return rt_theft;
        }
    }
}
