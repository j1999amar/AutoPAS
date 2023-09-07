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
    public class modelfueltypevariant
    {
        [Key]
        public int ModelFuelTypeVariantId { get; set; }
        public int ModelFuelTypeId { get; set; }

        public int VariantId { get; set; }
        public int TransmissionTypeId { get; set; }
    }
}
