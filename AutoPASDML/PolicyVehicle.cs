using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class PolicyVehicle
    {
        [Key]
        public Guid PolicyId { get; set; }
        public Guid VehicleId { get; set; }
    }
}
