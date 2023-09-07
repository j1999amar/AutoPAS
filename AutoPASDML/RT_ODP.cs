using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class RT_ODP
    {
        [Key]
        public int id { get; set; }
        public string ins_type { get; set; }
        public string part_type { get; set; }
        public string year { get; set; }
        public decimal depreciation { get; set; }
        public decimal factor { get; set; }
        
        //property

    }
}
