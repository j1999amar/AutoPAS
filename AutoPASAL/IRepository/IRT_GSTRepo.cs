using AutoPASDML;
namespace AutoPASAL.IRepository
{
    public interface IRT_GSTRepo
    {
        Task<List<RT_GST>> GetRT_GST();
        Task<List<RT_GST>> GetRT_GSTById(int id);
        Task<RT_GST> UpdateRT_GSTById(RT_GST obj);
        Task<RT_GST> AddRT_GSTEntry(RT_GST obj);
        Task<RT_GST> DeleteRT_GSTEntry(int id);
    }
}
