using AutoPASDML;
namespace AutoPASAL.IRepository

{
    public interface ItestRepo
    {
        Task<List<test>> Gettest();
        Task<List<test>> GettestById(int id);
        Task<test> UpdatetestById(test obj);
        Task<test> AddtestEntry(test obj);
        Task <test> DeletetestEntry(int id);
    }
}
