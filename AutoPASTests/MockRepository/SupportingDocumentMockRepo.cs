using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoPASAPITests.MockRepository
{
    public class SupportingDocumentMockRepo
    {
        public async Task<supportingdocument> ReturnsSupportingDocument()
        {
            var docs = new supportingdocument { DocumentLocation= "D:\\AutoPASAPI\\autopasapi\\AutoPAS\\AutoPASAPI\\wwwroot\\Upload\\00000000-0000-0000-0000-000000000000_gst.csv" ,DocumentName= "Id_filename" };
            return docs;
        }
        public async Task<supportingdocument> ReturnsNull()
        {
            return null;
        }
    }
}
