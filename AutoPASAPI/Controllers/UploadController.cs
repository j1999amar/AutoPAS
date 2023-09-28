using AutoPASAL.DTO_Model;
using AutoPASAL.Services;
using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;
        private readonly ILogger<UploadController> _logger;
        //private readonly TableDynamicController _tableDynamicController;

        public UploadController(IUploadService uploadService, ILogger<UploadController> logger) 
        {
            _uploadService = uploadService;
            _logger = logger;
            //_tableDynamicController = tableDynamicController;
        }

        [HttpPost("UploadTables/{filename}")]
        public async Task<IActionResult> AddRateTables([FromForm] UploadFile file,string filename)
         {
            try
            {
                if (file != null && file.files.Length > 0)
                {
                    return Ok(await _uploadService.AddRateTables(file, filename));
                }
                else
                {
                    return StatusCode(500, "No file uploaded."); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost("CreateTable/{filename}")]
        public async Task<IActionResult> CreateTables([FromBody] JsonElement filedata, string filename)
        {
            try
            {
                return Ok(await _uploadService.CreateTables(filedata, filename));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("GetTableList")]
        public async Task<IActionResult> GetTableList()
        {
            try
            {
               var meta = await _uploadService.GetTableList();
                if (meta == null)
                {
                    return BadRequest("Returns Null");
                }
                return Ok(meta);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetTableList");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetTableListById/{id}")]
        public async Task<IActionResult> GetTableListById(string id)
        {
            try
            {
                var meta = await _uploadService.GetTableListById(id);
                if (meta == null)
                {
                    return BadRequest("Returns Null");
                }
                return Ok(meta);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetTableListById");
                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateTableListById/{id}")]
        public async Task<IActionResult> UpdateTableListById([FromBody] metadatatables obj, string id)
        {
            try
            {
                return Ok(await _uploadService.UpdateTableListById(obj, id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdateTableListById");
                return StatusCode(500, ex);
            }
        }
    } 
}
