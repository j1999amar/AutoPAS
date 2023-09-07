using AutoPASAL.DTO_Model;
using AutoPASDML;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASAL.IRepository
{
    public interface IMetaDataRepo
    {
        Task DynamicMetadataTableAdd(metadatatables meta);
        Task<metadatatables> DynamicMetadataTableEditing(string filename,string field);
        Task DynamicTableCreation(HeaderRow headerRow, string filename);
        Task DynamicTableAlteration(string[] csvHeaders, List<string> extraHeaders, HeaderRow headerRow, string filename);
        Task<List<metadatatables>> GetTableList();
        Task<List<metadatatables>> GetTableListById(string id);
        Task<metadatatables> UpdateTableListById(metadatatables obj, string id);
    }
}
