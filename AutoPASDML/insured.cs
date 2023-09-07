using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class insured
    {
        [Key]
        public Guid InsuredId { get; set; }
        public int UserTypeId { get; set; }

        public Guid ContactId { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string? AadharNumber { get; set; }

        public string? LicenseNumber { get; set; }

        public string? PANNumber { get; set; }

        public string? AccountNumber { get; set; }

        public string? IFSCCode { get; set; }

        public string? BankName { get; set; }

        public string? BankAddress { get; set; }

    }
}
