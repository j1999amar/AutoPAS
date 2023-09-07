using AutoPASDML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IRatingService
    {
        Task <object> GetTableByName(string tablename);
        Task<object> GetTableByNameAndId(string tablename, int id);
        Task<object> UpdateTableByName(string tablename, JsonElement obj);
        Task<object> AddTableEntryByName(string tablename, JsonElement obj);
        Task<object> DeleteTableEntry(string tablename, int id);
    }
}
