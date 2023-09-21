using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class coverages
    {
        [Key]
        public int CoverageId { get; set; }

        [Required(ErrorMessage = "Please select coverage")]
        public string CoverageName { get; set; }
        public string CovCd { get; set; }
        public DateTime EffectiveDt { get; set; }
        public DateTime ExpirationDt { get; set; }
        public int SortOrder { get; set; }         
        public string Description { get; set; }
        public bool IsActive { get; set; }








    }
}
