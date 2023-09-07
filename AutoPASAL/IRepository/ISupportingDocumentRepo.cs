using AutoPASDML;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface ISupportingDocumentRepo
    {
        Task <supportingdocument>AddDocument(supportingdocument doc);
        Task <supportingdocument> UpdateDocument(string filename);
        Task<supportingdocument> GetDocumentById(string docname);
    }
}
