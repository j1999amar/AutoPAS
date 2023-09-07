using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AutoPASBL
{
    public class SupportingDocumentBL : ISupportingDocumentBL
    {

        public async Task<supportingdocument> AddDocument(IFormFile file)
        {
            string FileName = file.FileName;
            string SavingName = GetUniqueFilePath(FileName);
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = $"..\\..\\..\\..\\AutoPASAPI\\wwwroot\\Upload\\{SavingName}";
            var FilePath = Path.Combine(baseDirectory, relativePath);
            using (FileStream filestream = System.IO.File.Create(FilePath))
            {
                file.CopyTo(filestream);
                filestream.Flush();
            }
            supportingdocument newDoc = new supportingdocument();
            newDoc.PolicyId = SessionVariables.PolicyId.ToString();
            newDoc.DocumentName = SavingName;
            newDoc.DocumentLocation = FilePath;
            return newDoc;
        }
        public async Task UpdateDocument(IFormFile file, string DocLoc)
        {
            // Delete the old file
            if (File.Exists(DocLoc))
            {
                File.Delete(DocLoc);
            }
            using (FileStream filestream = System.IO.File.Create(DocLoc))
            {
                file.CopyTo(filestream);
                filestream.Flush();
            }
            return;
        }
        public async Task<FileStream> GetDocument(string docloc)
        {
            if (!System.IO.File.Exists(docloc))
            {
                return null;
            }
            var fileStream = new FileStream(docloc, FileMode.Open, FileAccess.Read);
            return fileStream;
        }
        public async Task <string> GetContentTypeForFile(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName).TrimStart('.');

            switch (fileExtension.ToLower())
            {
                case "pdf":
                    return "application/pdf";
                case "txt":
                    return "text/plain";
                case "doc":
                case "docx":
                    return "application/msword";
                case "xls":
                case "xlsx":
                    return "application/vnd.ms-excel";
                case "ppt":
                case "pptx":
                    return "application/vnd.ms-powerpoint";
                case "csv":
                    return "text/csv";
                case "jpge":
                case "jpg":

                    return "image/jpeg";
                default:
                    return "application/octet-stream";
            }
        }
        private string GetUniqueFilePath(string fileName)
        {
            var uniqueFileName = SessionVariables.PolicyId.ToString()+ "_" + fileName;
            return uniqueFileName;
        }
    }
}
