using AutoPASAL.IRepository;
using AutoPASAL.Services;
using Microsoft.AspNetCore.Http;
using AutoPASBL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoPASDML;

namespace AutoPASAL
{
    public class SupportingDocumentService:ISupportingDocumentService
    {
        private readonly ISupportingDocumentRepo _supportingDocumentRepo;
        private readonly ISupportingDocumentBL _supportingDocumentBL;
        public SupportingDocumentService(ISupportingDocumentRepo supportingDocumentRepo, ISupportingDocumentBL supportingDocumentBL)
        {
            _supportingDocumentRepo= supportingDocumentRepo;
            _supportingDocumentBL= supportingDocumentBL;
        }
        public async Task<supportingdocument> AddDocument(IFormFile file)
        {
            supportingdocument doc = await _supportingDocumentBL.AddDocument(file);
            await _supportingDocumentRepo.AddDocument(doc);
            return doc;
        }
        public async Task<supportingdocument> UpdateDocument(IFormFile file)
        {
            string filename = file.FileName;
            supportingdocument existingDoc=await _supportingDocumentRepo.UpdateDocument(filename);
            if (existingDoc != null)
            {
                string DocLoc = existingDoc.DocumentLocation.ToString();
                _supportingDocumentBL.UpdateDocument(file, DocLoc);
                return existingDoc;
            }
            supportingdocument doc = await _supportingDocumentBL.AddDocument(file);
            await _supportingDocumentRepo.AddDocument(doc);
            return doc;
        }
        public async Task<FileStream> GetDocumentById(string Id, string filename)
        {
            string docname = Id + "_" + filename;
            supportingdocument docs = await _supportingDocumentRepo.GetDocumentById(docname);
            if (docs == null)
            {
                return null;
            }
            string docloc = docs.DocumentLocation;
            var filestream = await _supportingDocumentBL.GetDocument(docloc);
            
            return filestream;
        }
        public async Task<string> GetContentTypeForFile(string Id, string filename)
        {
            string docname = Id + "_" + filename;
            supportingdocument docs = await _supportingDocumentRepo.GetDocumentById(docname);
            string type = await _supportingDocumentBL.GetContentTypeForFile(docs.DocumentName);
            return type;
        }
    }
}
