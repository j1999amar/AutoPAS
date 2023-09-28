using AutoPASAL.DTO_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPASAL.Services
{
    public interface IJSONService
    {
        Task<JSONDataHeader> JSONDivideField(JsonElement filedata);
        Task<HeaderRow> JSONDivideData(string Data);
    }
}
