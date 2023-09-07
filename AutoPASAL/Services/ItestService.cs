using AutoPASDML;

namespace AutoPASAL.Services
{
    public interface ItestService
    {
        Task<List<test>> Gettest();
        Task<List<test>> GettestById(int id);
        Task<test> UpdatetestById(test obj);
        Task<test> AddtestEntry(test obj);
        Task <test> DeletetestEntry(int id);
    }
}
