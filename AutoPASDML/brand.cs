using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class Brands
    {
        [Key]
        public int BrandId { get; set; }
        public int VehicleTypeId { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
