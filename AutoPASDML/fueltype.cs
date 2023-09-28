using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class fueltype
    {
        [Key]
        public int FuelTypeId { get; set; }
        public string FuelType { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
