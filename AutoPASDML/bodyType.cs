using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace AutoPASDML
{
    public class bodyType
    {
        public int BodyTypeId { get; set; }
        public string? BodyType { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
