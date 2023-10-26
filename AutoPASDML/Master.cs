using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    [Table("master_table_list")]
    public class Master
    {
        [Key]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Fields { get; set; }

    }
}
