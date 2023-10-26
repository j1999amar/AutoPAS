using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class MasterRepo:IMasterRepo
    {
        private readonly APASDBContext _context;

        public MasterRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<List<Master>> GetAllMaster()
        {
            var tableList=await _context.Masters.ToListAsync();
            return tableList;

        }
    }
}
