using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoPASDML
{
    public class UploadFile
    {
        //public int Id {  get; set; }
        //public string Name { get; set; }

        public IFormFile files { get; set; }


    }
    public class MultipleFile
    {
        public List<IFormFile> files { get; set; }
    }
}
