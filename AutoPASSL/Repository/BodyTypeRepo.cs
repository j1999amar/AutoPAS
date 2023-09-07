using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASAL.IRepository;
using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;

namespace AutoPASSL.Repository
{
    public class BodyTypeRepo : IBodyTypeRepo
    {
        private readonly APASDBContext _context;

        public BodyTypeRepo(APASDBContext context)
        {
            _context = context;
        }

        public async Task<List<bodyType>?> GetAllBodyType()
        {
            var bodytype = await _context.bodyType.ToListAsync();
            if (bodytype == null) return null;
            return bodytype;
        }
    }
}
