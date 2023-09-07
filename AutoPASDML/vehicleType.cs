using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace AutoPASDML
{
    public class vehicleType
    {
        public int VehicleTypeId { get; set; }
        public string? VehicleType { get; set; }
        public string? Description { get; set; }
        public int IsActive { get; set; }
    }
}
