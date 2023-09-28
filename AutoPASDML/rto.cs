using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class rto
    {
        [Key]
        public int RTOId { get; set; }

        public string? RTOName { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Description { get; set; }

        public int? IsActive { get; set; }

    }
}
