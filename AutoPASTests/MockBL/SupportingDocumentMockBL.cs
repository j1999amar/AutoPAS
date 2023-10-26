using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AutoPASAPITests.MockBL
{
     public class SupportingDocumentMockBL
    {
        public async Task<FileStream> ReturnsFileStream()
        {
            string docloc = "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv";
            var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
            return fileStream;
        }
        public async Task<FileStream> ReturnsFileStreamNull()
        {
            return null;
        }
        public async Task<string> ReturnsContentType()
        {
            return "application/octet-stream";
        }
        public async Task<string> ReturnsContentTypeNull()
        {
            return null;
        }
    }
}
