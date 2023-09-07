using AutoPASDML;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface ISupportingDocumentService
    {
        Task <supportingdocument> AddDocument(IFormFile file);
        Task<supportingdocument> UpdateDocument(IFormFile file);
        Task <FileStream> GetDocumentById(string Id, string filename);
        Task<string> GetContentTypeForFile(string Id, string filename);
    }
}
