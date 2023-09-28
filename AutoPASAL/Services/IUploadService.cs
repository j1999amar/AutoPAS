using AutoPASAL.DTO_Model;
using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IUploadService
    {
        Task<object> AddRateTables(UploadFile file, string filename);
        Task<object> CreateTables(JsonElement filedata, string filename);
        Task<List<metadatatables>> GetTableList();
        Task<List<metadatatables>> GetTableListById(string id);
        Task<metadatatables> UpdateTableListById(metadatatables obj,string id);

    }
}
