using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class UploadMockRepo
    {
        public async Task<List<metadatatables>?> ReturnsUpload()
        {
            var meta = new List<metadatatables> { };
            return meta;
        }
        public async Task<List<metadatatables>?> ReturnsNull()
        {
            return null;
        }
    }
}
