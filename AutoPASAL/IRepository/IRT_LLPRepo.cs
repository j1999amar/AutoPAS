using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IRT_LLPRepo
    {
        Task<List<RT_LLP>> GetRT_LLP();
        Task<List<RT_LLP>> GetRT_LLPById(int id);
        Task<RT_LLP> UpdateRT_LLPById(RT_LLP obj);
        Task<RT_LLP> AddRT_LLPEntry(RT_LLP obj);
        Task<RT_LLP> DeleteRT_LLPEntry(int id);
    }
}
