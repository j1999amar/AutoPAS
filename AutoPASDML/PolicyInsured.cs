using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class PolicyInsured
    {
        [Key]
        public string PolicyId { get; set; }
        public string InsuredId { get; set; }
    }
}
