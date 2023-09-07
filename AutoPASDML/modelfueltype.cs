using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class modelfueltype
    {
        [Key]
        public int ModelFuelTypeId { get; set; }
        public int ModelId { get; set; }
        
        [ForeignKey("FuelType")]
        public int FuelTypeId { get; set; }

        public fueltype FuelType { get; set; }
    }
}