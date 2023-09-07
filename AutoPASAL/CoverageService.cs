using AutoPASAL;
using AutoPASAL.Services;
using AutoPASDML;
using AutoPASAL.IRepository;
using AutoPASBL.Services;

namespace AutoPASAL
{
    public class CoverageService:ICoverageService
    {
        private readonly ICoverageRepo _coverageRepo;
        public CoverageService(ICoverageRepo coverageRepo)
        {
            _coverageRepo= coverageRepo;
        }
        public Task<List<coverages>> GetAllCoverages()
        {
            var cov = _coverageRepo.GetAllCoverages();
            return cov;
        }
        public async Task<PremiumRating> GetPremium()
        {
            PremiumRating premiumRating = new PremiumRating();
            var Id = SessionVariables.PolicyId;
            var policyVehicle = await _coverageRepo.GetPolicyVehicleDetails(Id);
            if(policyVehicle == null) return premiumRating;

            var policyCoverage = await _coverageRepo.GetPolicyCoverage(policyVehicle.PolicyId);
            if(policyCoverage == null) return premiumRating;

            var premiumFactors = await _coverageRepo.GetPremiumFactors();

            var ODCoverage = policyCoverage.Where(pc => pc.CoverageCode?.ToUpper() == "OD").FirstOrDefault();
            var TPLCoverage= policyCoverage.Where(pc => pc.CoverageCode?.ToUpper() == "TPL").FirstOrDefault();
            var TCCoverage = policyCoverage.Where(pc => pc.CoverageCode?.ToUpper() == "TPL").FirstOrDefault();

            var premiumCalculationService = new PremiumCalculationService()
            {
                IDV = policyVehicle.IDV,
                RT_NCB_Factor = premiumFactors.RT_NCB_Factor,
                RT_ODP_Factor = premiumFactors.RT_OD_Factor,
                RT_TPC_Factor = premiumFactors.RT_TPC_Factor,
                RT_THEFT_Factor = premiumFactors.RT_THEFT_Factor,
                RT_GST_Factor = premiumFactors.GST_Factor
            };

            if (ODCoverage != null) 
            {
                premiumCalculationService.CalculateODPremium(policyVehicle.EligibleForNCB);
                premiumRating.ODP = premiumCalculationService.RT_ODP_Value;
                premiumRating.NCB = premiumCalculationService.RT_NCB_Value; 
            }

            if (TPLCoverage != null) 
            { 
                premiumCalculationService.CalculateTPCPremium();
                premiumRating.TCP = premiumCalculationService.RT_TPC_Value;
            }

            if (TCCoverage != null)
            {
                premiumCalculationService.CalculateTHEFTPremium();
                premiumRating.THEFT = premiumCalculationService.RT_THEFT_Value;   
            }

            premiumCalculationService.CalculateTotalPremium();
            premiumRating.GST = premiumCalculationService.RT_GST_Value;
            premiumRating.IDV = policyVehicle.IDV;
            premiumRating.Year = policyVehicle.YearOfManufacture;
            premiumRating.ExShowroomPrice = policyVehicle.ExShowroomPrice;
            premiumRating.NetPremium = premiumCalculationService.TotalNetPremium;
            premiumRating.TotalPremium = premiumCalculationService.TotalPremium;

            return premiumRating;
        
        }
    }
}