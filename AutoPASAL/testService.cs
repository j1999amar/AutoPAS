using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;

namespace AutoPASAL
{
    public class testService : ItestService
    {
        private readonly ItestRepo _testRepo;
        public testService(ItestRepo testRepo)
        {
        _testRepo = testRepo;
        }
        public Task<List<test>> Gettest()
        {
        var test = _testRepo.Gettest();
        return test;
        }
        public Task<List<test>> GettestById(int id)
        {
        var test = _testRepo.GettestById(id);
        return test;
        }
        public Task<test> UpdatetestById(test obj)
        {
           var test = _testRepo.UpdatetestById(obj);
           return test;
        }
        public Task<test> AddtestEntry(test obj)
        {
            var test = _testRepo.AddtestEntry(obj);
            return test;
        }
        public Task <test> DeletetestEntry(int id)
        {
            var test = _testRepo.DeletetestEntry(id);
            return test;
        }
    }
}
