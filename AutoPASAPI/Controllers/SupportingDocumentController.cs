using AutoPASAL.Services;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPASSL;
using System.Text.RegularExpressions;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class SupportingDocumentController : ControllerBase
    {
        private readonly ISupportingDocumentService _supportingDocumentService;
        private readonly ILogger<SupportingDocumentController> _logger;

        public SupportingDocumentController(ILogger<SupportingDocumentController> logger, ISupportingDocumentService supportingDocumentService)
        {
            _logger = logger;
            _supportingDocumentService = supportingDocumentService;
        }

        [HttpPost("AddDocument")]
        public async Task<IActionResult> AddDocument([FromForm] MultipleFile multiplefile)
        {
            try
            {
                if (multiplefile != null && multiplefile.files.Count > 0)
                {
                    foreach (var file in multiplefile.files)
                    {
                        if (file.Length > 0)
                        {
                            await _supportingDocumentService.AddDocument(file);
                        }
                    }
                }
                else
                {
                    return StatusCode(500, "No File");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddDocument");
                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateDocument")]
        public async Task<IActionResult> UpdateDocument([FromForm] MultipleFile multiplefile)
        {
            try
            {
                if (multiplefile.files != null && multiplefile.files.Count > 0)
                {
                    foreach (var file in multiplefile.files)
                    {
                        if (file.Length > 0)
                        {
                            await _supportingDocumentService.UpdateDocument(file);
                        }
                    }
                }
                else
                {
                    return StatusCode(500, "No file");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddDocument");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetDocumentById/{Id}/{filename}")]
        public async Task<IActionResult> GetDocumentById(string Id,string filename)
        {
            try
            {
                var fileStream = await _supportingDocumentService.GetDocumentById(Id,filename);
                if (fileStream == null)
                {
                    return BadRequest("Returns Null");
                }
                string doctype = await _supportingDocumentService.GetContentTypeForFile(Id,filename);
                return File(fileStream, doctype, filename);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetDocumentById");
                return StatusCode(500, ex);
            }
        }

       
    }

}
