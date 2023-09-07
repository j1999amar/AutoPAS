using System.ComponentModel.DataAnnotations;

namespace AutoPASAL
{
    public class PremiumRating
    {
        public int Year { get; set; }
        public decimal ExShowroomPrice { get; set; }
        public decimal IDV { get; set; }
        public decimal ODP { get; set; }
        public decimal NCB { get; set; }
        public decimal TCP { get; set; }
        public decimal THEFT { get; set; }
        public decimal NetPremium { get; set; }
        public decimal GST { get; set; }
        public decimal TotalPremium { get; set; }
    }
    public class PolicyCoverageDto
    {
        public Guid PolicyId { get; set; }
        public Guid PolicyCoverageId { get; set; }
        public string? CoverageCode { get; set; }
    }
    public class PremiumFactors
    {
        public decimal RT_OD_Factor { get; set; }
        public decimal RT_NCB_Factor { get; set; }
        public decimal RT_TPC_Factor { get; set; }
        public decimal RT_THEFT_Factor { get; set; }
        public decimal GST_Factor { get; set; }
    }
}
