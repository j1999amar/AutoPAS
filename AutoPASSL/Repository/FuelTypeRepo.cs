﻿using System;
using System.Collections.Generic;
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
    public class FuelTypeRepo : IFuelTypeRepo
    {
        private readonly APASDBContext _context;
        public FuelTypeRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task<List<fueltype>> GetFuelTypes(int ModelId)
        {
            List<fueltype> fueltypes = new List<fueltype>();
            var types = _context.modelfueltype.Where(y => y.ModelId == ModelId).Select(y => y.FuelTypeId);
            fueltypes = await _context.fueltype.Where(x => types.Contains(x.FuelTypeId)).ToListAsync();
            if (fueltypes == null) return null;
            return fueltypes;
        }
        public async Task<List<fueltype>> GetAllFuelTypes()
        {
            List<fueltype> fueltypes = new List<fueltype>();
            fueltypes = await _context.fueltype.ToListAsync();
            if (fueltypes == null) return null;
            return fueltypes;
        }

        public async Task<fueltype> AddFuelType(fueltype fuelType)
        {
            await _context.fueltype.AddAsync(fuelType);
            var fuelTypeIsAdded = await _context.SaveChangesAsync();
            return fuelTypeIsAdded > 0 ? fuelType : null;
        }

        public bool IsExists(int id)
        {
            return _context.fueltype.Any(x => x.FuelTypeId == id);
        }

        public async Task<fueltype> EditFuelType(fueltype fuelType)
        {
            _context.fueltype.Entry(fuelType).State = EntityState.Modified;
            var change = await _context.SaveChangesAsync();
            return change > 0 ? fuelType : null;
        }

        public bool DeleteFuelType(int id)
        {
            var fuelType = _context.fueltype.Find(id);
            _context.fueltype.Remove(fuelType);
            var change =  _context.SaveChanges();
            return change > 0 ? true : false;
        }
    }
}
