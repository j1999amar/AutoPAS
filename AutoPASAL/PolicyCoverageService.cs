using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL
{
    public class PolicyCoverageService:IPolicyCoverageService
    {
        private readonly IPolicyCoverageRepo _policyCoverageRepo;
        public PolicyCoverageService(IPolicyCoverageRepo policyCoverageRepo)
        {
            _policyCoverageRepo = policyCoverageRepo;
        }
        public Task<policycoverage> AddPolicyCoverage(List<int> coverageID)
        {
            var polcov= _policyCoverageRepo.AddPolicyCoverage(coverageID);
            return polcov;
        }
        public Task<policycoverage> EditPolicyCoverage(Guid Id, List<int> coverageID)
        {
            var polcov = _policyCoverageRepo.EditPolicyCoverage(Id,coverageID);
            return polcov;
        }
        public Task<List<policycoverage>?> GetPolicyCoverageById(Guid Id)
        {
            var polcov = _policyCoverageRepo.GetPolicyCoverageById(Id);
            return polcov;
        }
    }
}
