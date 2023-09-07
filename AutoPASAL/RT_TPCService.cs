using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASBL.Interface;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL
{
    public class RT_TPCService:IRT_TPCService
    {
        private readonly IRT_TPCRepo _rt_tpcRepo;
        public RT_TPCService(IRT_TPCRepo rt_tpcRepo)
        {
            _rt_tpcRepo= rt_tpcRepo;
        }
        public Task<List<RT_TPC>> GetRT_TPC()
        {
            var rt_tpc= _rt_tpcRepo.GetRT_TPC();
            return rt_tpc;
        }
        public Task<List<RT_TPC>> GetRT_TPCById(int id)
        {
            var rt_tpc = _rt_tpcRepo.GetRT_TPCById(id);
            return rt_tpc;
        }
        public Task<RT_TPC> UpdateRT_TPCById(RT_TPC obj)
        {
            var rt_tpc = _rt_tpcRepo.UpdateRT_TPCById(obj);
            return rt_tpc;
        }
        public Task<RT_TPC> AddRT_TPCEntry(RT_TPC obj)
        {
            var rt_tpc = _rt_tpcRepo.AddRT_TPCEntry(obj);
            return rt_tpc;
        }
        public Task<RT_TPC> DeleteRT_TPCEntry(int id)
        {
            var rt_tpc = _rt_tpcRepo.DeleteRT_TPCEntry(id);
            return rt_tpc;
        }
    }
}
