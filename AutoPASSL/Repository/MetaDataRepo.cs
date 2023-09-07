using AutoPASAL.DTO_Model;
using AutoPASAL.IRepository;
using AutoPASDML;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPASSL.Repository
{
    public class MetaDataRepo: IMetaDataRepo
    {
        private readonly APASDBContext _context;
        public MetaDataRepo(APASDBContext context)
        {
            _context = context;
        }
        public async Task DynamicMetadataTableAdd(metadatatables meta)
        {
            try
            {
                await _context.metadatatables.AddAsync(meta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return;
        }
        public async Task<metadatatables> DynamicMetadataTableEditing(string filename, string field)
        {
            var meta = await _context.metadatatables.FirstOrDefaultAsync(x => x.Id == filename);
            if (meta != null)
            {
                meta.Fields = field;
                _context.Entry(meta).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return meta;
        }
        public async Task<List<metadatatables>> GetTableList()
        {
            var table = await _context.metadatatables.ToListAsync();
            return table;
        }
        public async Task<List<metadatatables>> GetTableListById(string id)
        {
            var table = await _context.metadatatables.Where(x => x.Id == id).ToListAsync();
            return table;
        }
        public async Task<metadatatables> UpdateTableListById(metadatatables obj, string id)
        {
            var table= await _context.metadatatables.FirstOrDefaultAsync(x => x.Id == id);
            if (table != null)
            {
                table.Title = obj.Title;
                table.Description = obj.Description;
                await _context.SaveChangesAsync();
            }
            return table;
        }
        public async Task DynamicTableCreation(HeaderRow headerRow, string filename)
        {
            var columns = "";
            var param_col = "";
            var table_col = "";

            bool exists = _context.CallCheckTableObjectExists(filename);

            if (exists)
            {
                _context.CallDropTableStoredProcedure(filename);
            }
            foreach (string str_head in headerRow.Header)
            {
                columns = str_head;
                foreach (string str_head_col in str_head.Split(','))
                {
                    table_col += str_head_col + " varchar(255),";
                    param_col += "@" + str_head_col + ",";
                }
            }

            _context.CallCreateTableStoredProcedure(filename, table_col.TrimEnd(','));

            foreach (string str_col in headerRow.Row)
            {
                _context.CallDynamicTableInsertStoredProcedure(filename, columns, str_col);
            }
            return;
        }
        public async Task DynamicTableAlteration(string[] csvHeaders, List<string> extraHeaders, HeaderRow headerRow, string filename)
        {
            var columns = "";
            var param_col = "";
            foreach (string item in csvHeaders)
            {
                var exists = _context.CallCheckTableObjectExistswithColumn(filename, item);
                if (exists)
                {
                    continue;
                }
                else
                {
                    _context.CallAlterTableAddNewColumnStoredProcedure(filename, item);
                }
            }
                // Remove extra headers from file content
                foreach (var extraHeader in extraHeaders)
                {
                    var exists_fordrop = _context.CallCheckTableObjectExistswithColumn(filename, extraHeader);
                    if (exists_fordrop)
                    {
                        _context.CallAlterTableDropColumnStoredProcedure(filename, extraHeader);
                    }
                    else
                    {
                        continue;
                    }
                }


                _context.CallDeleteTableStoredProcedure(filename);

                foreach (string str_col in headerRow.Row)
                {
                _context.CallDynamicTableInsertStoredProcedure(filename, columns, str_col);
                }
            return;
        }
    }
}
