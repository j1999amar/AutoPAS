﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;

namespace AutoPASAL.Services
{
    public interface IFuelTypeService
    {
        Task<List<fueltype>> GetFuelTypes(int ModelId);
        Task<List<fueltype>> GetAllFuelTypes();
        Task<fueltype> AddFuelType(fueltype fuelType);
        Task<fueltype> EditFuelType(fueltype fuelType);
        public bool DeleteFuelType(int id);
        public bool IsExists(int id);
    }
}
