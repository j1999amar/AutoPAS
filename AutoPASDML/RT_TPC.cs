using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class RT_TPC
    {
        [Key]
        public int id { get; set; }
        public string vehicle_status { get; set; }
        public int claim_year { get; set; }
        public decimal factor { get; set; }
        //property
    }
}
