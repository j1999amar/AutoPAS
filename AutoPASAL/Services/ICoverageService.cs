using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;

namespace AutoPASAL.Services
{
    public interface ICoverageService
    {
        Task<PremiumRating> GetPremium();
        Task<List<coverages>> GetAllCoverages();
        Task<coverages> AddCoverages(coverages coverages);
        Task<coverages> EditCoverage(coverages coverages);
        public bool IsExists(int id);
    }
}
