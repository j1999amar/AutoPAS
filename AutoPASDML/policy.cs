using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoPASDML
{
    public class policy
    {
        [Key]
        public Guid PolicyId { get; set; }

        public int? AppUserId { get; set; }      

        public int? PolicyNumber { get; set; }

        public int QuoteNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Policy Effective date")]
        [Display(Name = "Policy Effective Date")]
        public DateTime PolicyEffectiveDt { get; set; }

        [Required(ErrorMessage = "Please Enter Policy Expiration date")]
        [Display(Name = "Policy Expiration Date")]
        public DateTime PolicyExpirationDt { get; set; }

        public string? Status { get; set; }
        public int? Term { get; set; }
        public DateTime? RateDt { get; set; }
        public decimal? TotalPremium { get; set; }
        public decimal? SGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? IGST { get; set; }
        public decimal? TotalFees { get; set; }
        public string? PaymentType { get; set; }
        public string? ReceiptNumber { get; set; }
        public int EligibleForNCB { get; set; }

    }
}
