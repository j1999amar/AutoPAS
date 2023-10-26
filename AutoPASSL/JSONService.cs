using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json.Linq;
using AutoPASAL.DTO_Model;
using AutoPASAL.Services;
using System.Text.Json;

namespace AutoPASSL
{
    public class JSONService: IJSONService
    {
        public async Task <JSONDataHeader> JSONDivideField(JsonElement filedata)
        {
            JObject jsonObject = JObject.Parse(filedata.ToString());
            var dataPart = jsonObject["data"];
            var headersPart = jsonObject["headers"];
            string dataJson = dataPart.ToString((Newtonsoft.Json.Formatting)Formatting.None);
            string headersJson = headersPart.ToString((Newtonsoft.Json.Formatting)Formatting.None);
            var jsondataheader = new JSONDataHeader { Data = dataJson, Header = headersJson };
            return jsondataheader;
        }
        public async Task<HeaderRow> JSONDivideData(string Data)
        {
            JArray jsonArray = JArray.Parse(Data);

            List<string> fields = new List<string>();
            List<string> data = new List<string>();
            int i=0;
            foreach (JObject jsonObject in jsonArray)
            {
                StringBuilder rowdata = new StringBuilder();
                StringBuilder rowfield = new StringBuilder();
                foreach (var property in jsonObject.Properties())
                {
                    if (i == 0)
                    {
                        rowfield.Append(property.Name.ToString());
                        rowfield.Append(",");
                    }
                    rowdata.Append(property.Value.ToString());
                    rowdata.Append(",");
                }
                if (i == 0)
                {
                    rowfield.Length -= 1;
                    fields.Add(rowfield.ToString());
                }
                i++;
                rowdata.Length -= 1;
                data.Add(rowdata.ToString()); 
            }
            HeaderRow headerRow = new HeaderRow() { Header = fields, Row = data };
            return headerRow;
        }

    }
}
