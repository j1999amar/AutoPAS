using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;

namespace AutoPASSL.Repository
{
        public class testRepo : ItestRepo
        {
            private readonly APASDBContext _context;
            public testRepo(APASDBContext context)
            {
                _context = context;
            }
            public async Task<List<test>> Gettest()
            {
                var obj = await _context.test.ToListAsync();
                return obj;
            }
            public async Task<List<test>> GettestById(int id)
            {
                var obj = await _context.test.Where(x => x.id == id.ToString()).ToListAsync();
                return obj;
            }
            public async Task<test> UpdatetestById(test obj)
            {
                var  test = await _context.test.FirstOrDefaultAsync(x => x.id == obj.id);
                if (test  != null)
                {
                   test.id = obj.id;
                   test.factor = obj.factor;
                   
                    test.value = obj.value;
                   //property
                    await _context.SaveChangesAsync();
                }
                return test  ;
            }
            public async Task<test> AddtestEntry(test obj)
            {
                await _context.test.AddAsync(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            public async Task<test> DeletetestEntry(int id)
            {
                var test= await _context.test.FirstOrDefaultAsync(x => x.id == id.ToString());
                if (test != null)
                {
                    _context.test.Remove(test);
                    await _context.SaveChangesAsync();
                }
               return test;
            }
        }
}
