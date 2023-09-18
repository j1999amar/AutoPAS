﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASAL.IRepository;
using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AutoPASSL.Repository
{
    public class BodyTypeRepo : IBodyTypeRepo
    {
        private readonly APASDBContext _context;

        public BodyTypeRepo(APASDBContext context)
        {
            _context = context;
        }

        public  bool IsExists(int id)
        {
           return _context.bodyType.Any(x => x.BodyTypeId == id);
        }

        public async Task<List<bodyType>?> GetAllBodyType()
        {
            var bodytype = await _context.bodyType.ToListAsync();
            if (bodytype == null) return null;
            return bodytype;
        }

        public async Task<bodyType> AddBodyType(bodyType bodyType)
        {
            await _context.bodyType.AddAsync(bodyType);
            var bodyTypeIsAdded = await _context.SaveChangesAsync();
            return bodyTypeIsAdded > 0 ? bodyType : null;



        }
    }
}
