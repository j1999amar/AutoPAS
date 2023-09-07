using AutoPASDML;

namespace AutoPASAL.Services
{
    public interface IRT_NCBService
    {
        Task<List<RT_NCB>> GetRT_NCB();
        Task<List<RT_NCB>> GetRT_NCBById(int id);
        Task<RT_NCB> UpdateRT_NCBById(RT_NCB obj);
        Task<RT_NCB> AddRT_NCBEntry(RT_NCB obj);
        Task<RT_NCB> DeleteRT_NCBEntry(int id);
    }
}
