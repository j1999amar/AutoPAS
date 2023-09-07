using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.DTO_Model
{
    public class PolicyVehicleDto
    {
        public Guid PolicyId { get; set; }
        public Guid VehicleId { get; set; }
        public int EligibleForNCB { get; set; }
        public decimal IDV { get; set; }
        public int YearOfManufacture { get; set; }
        public decimal ExShowroomPrice { get; set; }
    }
}
