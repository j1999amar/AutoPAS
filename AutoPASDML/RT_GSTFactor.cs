using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class RT_GSTFactor
    {
        [Key]
        public decimal factor { get; set; }
    }
}
