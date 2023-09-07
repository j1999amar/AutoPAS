using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IRT_TPCService
    {
        Task<List<RT_TPC>> GetRT_TPC();
        Task<List<RT_TPC>> GetRT_TPCById(int id);
        Task<RT_TPC> UpdateRT_TPCById(RT_TPC obj);
        Task<RT_TPC> AddRT_TPCEntry(RT_TPC obj);
        Task<RT_TPC> DeleteRT_TPCEntry(int id);
    }
}
