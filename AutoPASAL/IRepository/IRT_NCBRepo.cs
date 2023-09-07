using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IRT_NCBRepo
    {
        Task<List<RT_NCB>> GetRT_NCB();
        Task<List<RT_NCB>> GetRT_NCBById(int id);
        Task<RT_NCB> UpdateRT_NCBById(RT_NCB obj);
        Task<RT_NCB> AddRT_NCBEntry(RT_NCB obj);
        Task<RT_NCB> DeleteRT_NCBEntry(int id);
    }
}
