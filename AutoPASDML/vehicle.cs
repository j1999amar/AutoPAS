using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class vehicle
    {
        [Key]
        public Guid VehicleId { get; set; }

        [Required]
        public int RTOId { get; set; }
        public int VehicleTypeid { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }

        public int VariantId { get; set; }

        public int BodyTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int TransmissionTypeId { get; set; }      

        public string RegistrationNumber { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Color { get; set; }

        public string ChasisNumber { get; set; }

        public string EngineNumber { get; set; }

        public int CubicCapacity { get; set; }

        public int SeatingCapacity { get; set; }

        public int YearOfManufacture { get; set; }

        public decimal IDV { get; set; }

        public decimal ExShowroomPrice { get; set; }

    }
}
