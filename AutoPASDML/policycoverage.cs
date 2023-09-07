using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutoPASDML
{
    public class policycoverage
    {
        [Key]
        public Guid PolicyCoverageId { get; set; }

        public Guid PolicyId { get; set; }

        public int CoverageId { get; set; }

        public int Limit { get; set; }

    }
}
