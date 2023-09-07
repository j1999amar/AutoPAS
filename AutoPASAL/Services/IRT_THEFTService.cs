using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IRT_THEFTService
    {
        Task<List<RT_THEFT>> GetRT_THEFT();
        Task<List<RT_THEFT>> GetRT_THEFTById(int id);
        Task<RT_THEFT> UpdateRT_THEFTById(RT_THEFT obj);
        Task<RT_THEFT> AddRT_THEFTEntry(RT_THEFT obj);
        Task<RT_THEFT> DeleteRT_THEFTEntry(int id);
    }
}
