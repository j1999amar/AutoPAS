using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPASDML;
using AutoPASAL.Services;
using CsvHelper;
using AutoPASAL.DTO_Model;

namespace AutoPASSL
{
    
    public class CSVService : ICSVService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<T>();
            return records;
        }
        public async Task<string[]> GetHeader(UploadFile file)
        {
            using var csvReader = new StreamReader(file.files.OpenReadStream());
            var csvHeaders = csvReader.ReadLine()?.Split(',');
            return csvHeaders;
        }
        public async Task<HeaderRow> GetHeaderRow(UploadFile file)
        {
            List<string> head_col = new List<string>();
            List<string> row_cols = new List<string>();
            using (var fileStream = file.files.OpenReadStream())
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                string row;
                int i = 0;
                while ((row = reader.ReadLine()) != null)
                {
                    if (i == 0)
                    {
                        head_col.Add(row);
                        i++;
                    }
                    else
                    {
                        row_cols.Add(row);
                        i++;
                    }
                }

            }
            HeaderRow headerRow= new HeaderRow() { Header= head_col ,Row=row_cols};
            return headerRow;
        }
    }
}
