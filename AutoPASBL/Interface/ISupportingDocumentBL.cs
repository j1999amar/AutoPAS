using AutoPASDML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASBL.Interface
{
    public interface ISupportingDocumentBL
    {
        Task <supportingdocument> AddDocument(IFormFile file);
        Task UpdateDocument(IFormFile file,string DocLoc);
        Task <FileStream>GetDocument(string docloc);
        Task<string> GetContentTypeForFile(string fileName);
    }
}
