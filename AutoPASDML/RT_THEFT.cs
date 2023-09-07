using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class RT_THEFT
    {
        [Key]
        public int id { get; set; }
        public decimal factor { get; set; }
        //property
    }
}
