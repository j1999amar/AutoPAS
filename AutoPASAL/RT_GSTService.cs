using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;

namespace AutoPASAL
{
    public class RT_GSTService:IRT_GSTService
    {
        private readonly IRT_GSTRepo _rt_gstRepo;
        public RT_GSTService(IRT_GSTRepo rt_gstRepo)
        {
            _rt_gstRepo= rt_gstRepo;
        }
        public Task<List<RT_GST>> GetRT_GST()
        {
            var rt_gst= _rt_gstRepo.GetRT_GST();
            return rt_gst;
        }
        public Task<List<RT_GST>> GetRT_GSTById(int id)
        {
            var rt_gst = _rt_gstRepo.GetRT_GSTById(id);
            return rt_gst;
        }
        public Task<RT_GST> UpdateRT_GSTById(RT_GST obj)
        {
            var rt_gst = _rt_gstRepo.UpdateRT_GSTById( obj);
            return rt_gst;
        }
        public Task<RT_GST> AddRT_GSTEntry(RT_GST obj)
        {
            var rt_gst = _rt_gstRepo.AddRT_GSTEntry(obj);
            return rt_gst;
        }
        public Task<RT_GST> DeleteRT_GSTEntry(int id)
        {
            var rt_gst = _rt_gstRepo.DeleteRT_GSTEntry(id); 
            return rt_gst;
        }

    }
}
