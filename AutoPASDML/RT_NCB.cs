using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class RT_NCB
    {
        [Key]
        public int ID {  get; set; }
        public int no_claim_year { get; set; }
        public decimal factor { get; set; }
        //property

    }
}
