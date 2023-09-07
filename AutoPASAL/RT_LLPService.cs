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
    public class RT_LLPService:IRT_LLPService
    {
        private readonly IRT_LLPRepo _rt_llpRepo;
        public RT_LLPService(IRT_LLPRepo rt_llpRepo)
        {
            _rt_llpRepo = rt_llpRepo;
        }
        public Task<List<RT_LLP>> GetRT_LLP()
        {
            var rt_llp=_rt_llpRepo.GetRT_LLP();
            return rt_llp;
        }
        public Task<List<RT_LLP>> GetRT_LLPById(int id)
        {
            var rt_llp = _rt_llpRepo.GetRT_LLPById(id);
            return rt_llp;
        }
        public Task<RT_LLP> UpdateRT_LLPById(RT_LLP obj)
        {
            var rt_llp = _rt_llpRepo.UpdateRT_LLPById(obj);
            return rt_llp;
        }
        public Task<RT_LLP> AddRT_LLPEntry(RT_LLP obj)
        {
            var rt_llp = _rt_llpRepo.AddRT_LLPEntry(obj);
            return rt_llp;
        }
        public Task<RT_LLP> DeleteRT_LLPEntry(int id)
        {
            var rt_llp = _rt_llpRepo.DeleteRT_LLPEntry(id);
            return rt_llp;
        }
    }
}
