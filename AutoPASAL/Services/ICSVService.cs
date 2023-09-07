using AutoPASAL.DTO_Model;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface ICSVService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file);
        Task<string[]> GetHeader(UploadFile file);
        Task<HeaderRow> GetHeaderRow(UploadFile file);
    }
}
