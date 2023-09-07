using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class supportingdocument
    {
        [Key]
        public Guid DocumentId { get; set; }
        public string PolicyId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentLocation { get; set; }

    }
}