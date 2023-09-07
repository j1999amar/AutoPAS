using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class contact
    {
        [Key]
        public Guid ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string? LastName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Pincode { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }

    }
}
