﻿using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IPolicyCoverageRepo
    {
        Task<policycoverage> AddPolicyCoverage(List<int> coverageID);
        Task<policycoverage> EditPolicyCoverage(Guid Id, List<int> coverageID);
        Task<List<policycoverage>?> GetPolicyCoverageById(Guid Id);
    }
}
