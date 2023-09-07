using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class model
    {
        [Key]
        public int ModelId { get; set; }
        public int BrandId { get; set; }

        public string ModelName { get; set; }
        public string Description { get; set; }

    }
}
