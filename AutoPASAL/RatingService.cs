using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AutoPASAL
{
    public class RatingService:IRatingService
    {
        private readonly IRT_GSTRepo _rt_gstRepo;
        private readonly IRT_LLPRepo _rt_llpRepo;
        private readonly IRT_NCBRepo _rt_ncbRepo;
        private readonly IRT_ODPRepo _rt_odpRepo;
        private readonly IRT_TPCRepo _rt_tpcRepo;
        private readonly IRT_THEFTRepo _rt_theftRepo;
        //insert1

        public RatingService(IRT_GSTRepo rt_gstRepo, IRT_LLPRepo rt_llpRepo, IRT_NCBRepo rt_ncbRepo, IRT_ODPRepo rt_odpRepo, IRT_THEFTRepo rt_theftRepo, IRT_TPCRepo rt_tpcRepo/*insert2*/)
        {
            _rt_gstRepo = rt_gstRepo;
            _rt_llpRepo = rt_llpRepo;
            _rt_ncbRepo = rt_ncbRepo;
            _rt_odpRepo = rt_odpRepo;
            _rt_theftRepo = rt_theftRepo;
            _rt_tpcRepo = rt_tpcRepo;
            //insert3
        }
        public async Task<object> GetTableByName(string tablename)
        {
            object obj = new();
            if (tablename == "RT_GST")
            {
                obj = await _rt_gstRepo.GetRT_GST();
            }
            else if (tablename == "RT_LLP")
            {
                obj = await _rt_llpRepo.GetRT_LLP();
            }
            else if (tablename == "RT_NCB")
            {
                obj = await _rt_ncbRepo.GetRT_NCB();
            }
            else if (tablename == "RT_ODP")
            {
                obj = await _rt_odpRepo.GetRT_ODP();
            }
            else if (tablename == "RT_THEFT")
            {
                obj = await _rt_theftRepo.GetRT_THEFT();
            }
            else if (tablename == "RT_TPC")
            {
                obj = await _rt_tpcRepo.GetRT_TPC();
            }
            //insert4
            return obj;
        }
        public async Task<object> GetTableByNameAndId(string tablename, int id)
        {
            object obj = new();
            if (tablename == "RT_GST")
            {
                obj = await _rt_gstRepo.GetRT_GSTById(id);
            }
            else if (tablename == "RT_LLP")
            {
                obj = await _rt_llpRepo.GetRT_LLPById(id);
            }
            else if (tablename == "RT_NCB")
            {
                obj = await _rt_ncbRepo.GetRT_NCBById(id);
            }
            else if (tablename == "RT_ODP")
            {
                obj = await _rt_odpRepo.GetRT_ODPById(id);
            }
            else if (tablename == "RT_THEFT")
            {
                obj = await _rt_theftRepo.GetRT_THEFTById(id);
            }
            else if (tablename == "RT_TPC")
            {
                obj = await _rt_tpcRepo.GetRT_TPCById(id);
            }
            //insert5
            return obj;
        }
        public async Task<object> UpdateTableByName(string tablename, JsonElement body)
        {
            object obj = new();
            if (tablename == "RT_GST")
            {
                obj = await _rt_gstRepo.UpdateRT_GSTById(JsonSerializer.Deserialize<RT_GST>(body.GetRawText()));
            }
            else if (tablename == "RT_LLP")
            {
                obj = await _rt_llpRepo.UpdateRT_LLPById(JsonSerializer.Deserialize<RT_LLP>(body.GetRawText()));
            }
            else if (tablename == "RT_NCB")
            {
                obj = await _rt_ncbRepo.UpdateRT_NCBById(JsonSerializer.Deserialize<RT_NCB>(body.GetRawText()));
            }
            else if (tablename == "RT_ODP")
            {
                obj = await _rt_odpRepo.UpdateRT_ODPById(JsonSerializer.Deserialize<RT_ODP>(body.GetRawText()));
            }
            else if (tablename == "RT_THEFT")
            {
                obj = await _rt_theftRepo.UpdateRT_THEFTById(JsonSerializer.Deserialize<RT_THEFT>(body.GetRawText()));
            }
            else if (tablename == "RT_TPC")
            {
                obj = await _rt_tpcRepo.UpdateRT_TPCById(JsonSerializer.Deserialize<RT_TPC>(body.GetRawText()));
            }
            //insert6
            return obj;
        }
        public async Task<object> AddTableEntryByName(string tablename, JsonElement body)
        {
            object obj = new();
            if (tablename == "RT_GST")
            {
                obj = await _rt_gstRepo.AddRT_GSTEntry(JsonSerializer.Deserialize<RT_GST>(body.GetRawText()));
            }
            else if (tablename == "RT_LLP")
            {
                obj = await _rt_llpRepo.AddRT_LLPEntry(JsonSerializer.Deserialize<RT_LLP>(body.GetRawText()));
            }
            else if (tablename == "RT_NCB")
            {
                obj = await _rt_ncbRepo.AddRT_NCBEntry(JsonSerializer.Deserialize<RT_NCB>(body.GetRawText()));
            }
            else if (tablename == "RT_ODP")
            {
                obj = await _rt_odpRepo.AddRT_ODPEntry(JsonSerializer.Deserialize<RT_ODP>(body.GetRawText()));
            }
            else if (tablename == "RT_THEFT")
            {
                obj = await _rt_theftRepo.AddRT_THEFTEntry(JsonSerializer.Deserialize<RT_THEFT>(body.GetRawText()));
            }
            else if (tablename == "RT_TPC")
            {
                obj = await _rt_tpcRepo.AddRT_TPCEntry(JsonSerializer.Deserialize<RT_TPC>(body.GetRawText()));
            }
            //insert7
            return obj;
        }
        public async Task<object>DeleteTableEntry(string tablename, int id)
        {
            object obj = new();
            if (tablename == "RT_GST")
            {
                obj = await _rt_gstRepo.DeleteRT_GSTEntry(id);
            }
            else if (tablename == "RT_LLP")
            {
                obj = await _rt_llpRepo.DeleteRT_LLPEntry(id);
            }
            else if (tablename == "RT_NCB")
            {
                obj = await _rt_ncbRepo.DeleteRT_NCBEntry(id);
            }
            else if (tablename == "RT_ODP")
            {
                obj = await _rt_odpRepo.DeleteRT_ODPEntry(id);
            }
            else if (tablename == "RT_THEFT")
            {
                obj = await _rt_theftRepo.DeleteRT_THEFTEntry(id);
            }
            else if (tablename == "RT_TPC")
            {
                obj = await _rt_tpcRepo.DeleteRT_TPCEntry(id);
            }
            //insert8
            return obj;
        }
    }
}
