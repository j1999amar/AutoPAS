using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IRT_ODPRepo
    {
        Task<List<RT_ODP>> GetRT_ODP();
        Task<List<RT_ODP>> GetRT_ODPById(int id);
        Task<RT_ODP> UpdateRT_ODPById(RT_ODP obj);
        Task<RT_ODP> AddRT_ODPEntry(RT_ODP obj);
        Task<RT_ODP> DeleteRT_ODPEntry(int id);
    }
}
