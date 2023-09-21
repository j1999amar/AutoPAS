using AutoPASAL.DTO_Model;
using AutoPASDML;

namespace AutoPASAL.IRepository
{
    public interface ICoverageRepo
    {
        Task<List<coverages>> GetAllCoverages();
        Task<IEnumerable<PolicyCoverageDto>> GetPolicyCoverage(Guid policyId);
        Task<PremiumFactors> GetPremiumFactors();
        Task<PolicyVehicleDto> GetPolicyVehicleDetails(Guid PolicyId);
        Task<coverages> AddCoverages(coverages coverages);
        Task<coverages> EditCoverage(coverages coverages);
        public bool IsExists(int id);
    }
}
