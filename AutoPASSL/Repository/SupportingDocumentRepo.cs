using AutoPASAL.IRepository;
using AutoPASDML;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class SupportingDocumentRepo:ISupportingDocumentRepo
    {
        private readonly APASDBContext _context;
        public SupportingDocumentRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task <supportingdocument> AddDocument(supportingdocument doc)
        {
            await _context.supportingdocuments.AddAsync(doc);
            await _context.SaveChangesAsync();
            return doc;
        }
        public async Task<supportingdocument> UpdateDocument(string filename)
        {
            supportingdocument existingDoc = await _context.supportingdocuments.FirstOrDefaultAsync(doc => doc.DocumentName == SessionVariables.PolicyId.ToString() + "_" + filename);
            if (existingDoc != null)
            {
                return existingDoc;
            }
            return null;
        }
        public async Task<supportingdocument> GetDocumentById(string docname)
        {
            var docs = await _context.supportingdocuments.ToListAsync(); 
            return docs.FirstOrDefault(e => Regex.IsMatch(e.DocumentName, docname));
        }

    }
}
