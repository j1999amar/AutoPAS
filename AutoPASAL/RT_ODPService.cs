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
    public class RT_ODPService:IRT_ODPService
    {
        private readonly IRT_ODPRepo _rt_odpRepo;
        public RT_ODPService(IRT_ODPRepo rt_odpRepo)
        {
            _rt_odpRepo = rt_odpRepo;
        }
        public Task<List<RT_ODP>> GetRT_ODP()
        {
            var rt_odp=_rt_odpRepo.GetRT_ODP();
            return rt_odp; 
        }
        public Task<List<RT_ODP>> GetRT_ODPById(int id)
        {
            var rt_odp = _rt_odpRepo.GetRT_ODPById(id);
            return rt_odp;
        }
        public Task<RT_ODP> UpdateRT_ODPById(RT_ODP obj)
        {
            var rt_odp = _rt_odpRepo.UpdateRT_ODPById(obj);
            return rt_odp;
        }
        public Task<RT_ODP> AddRT_ODPEntry(RT_ODP obj)
        {
            var rt_odp = _rt_odpRepo.AddRT_ODPEntry(obj);
            return rt_odp;
        }
        public Task<RT_ODP> DeleteRT_ODPEntry(int id)
        {
            var rt_odp = _rt_odpRepo.DeleteRT_ODPEntry(id);
            return rt_odp;
        }
    }
}
