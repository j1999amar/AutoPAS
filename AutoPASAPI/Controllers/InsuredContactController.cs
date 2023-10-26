using Microsoft.AspNetCore.Mvc;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using AutoPASBL;
using AutoPASAL.Services;
using AutoPASSL;
using System.Net;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class InsuredContactController : Controller
    {
        private readonly IInsuredContactService _insuredcontactService;
        private readonly ILogger<InsuredContactController> _logger;
        
        public InsuredContactController(IInsuredContactService insuredcontactService, ILogger<InsuredContactController> logger)
        {
            _insuredcontactService = insuredcontactService;
            _logger = logger;
        }


        //Add Contact and Insured
        [HttpPost("AddInsuredContact")]
        public async Task<IActionResult> AddInsuredContact([FromBody] insuredContact objInsuredContact)
        {
            try
            {
                return Ok( await _insuredcontactService.AddInsuredContact(objInsuredContact));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddInsuredContact");
                return StatusCode(500, ex);
            }

        }
        
        [HttpPost ("EditInsuredContact/{Id}")]
        public async Task<IActionResult> EditInsuredContact(Guid Id,[FromBody] insuredContact objInsuredContact)
        {
            try
            {
                return Ok(await _insuredcontactService.EditInsuredContact(Id,objInsuredContact));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddInsuredContact");
                return StatusCode(500, ex);
            }

        }

        [HttpGet ("GetInsuredById/{Id}")]
        public async Task<IActionResult> GetInsuredById(Guid Id)
        {
            try
            {
                var ins = await _insuredcontactService.GetInsuredById(Id);
                if (ins == null)
                {
                     return BadRequest("Returns Null");
                }
                return Ok(ins);
                
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddInsuredContact");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetContactById/{Id}")]
        public async Task<IActionResult> GetContactById(Guid Id)
        {
            try
            {
                var con = await _insuredcontactService.GetContactById(Id);
                if (con == null)
                {
                    return BadRequest("Returns Null");
                }
                return Ok(con);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddInsuredContact");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetInsuredContactByPolicyNumber/{policynumber}")]
        public async Task<IActionResult> GetInsuredContactByPolicyNumber(string policynumber)
        {
            try
            {
                var inscon = await _insuredcontactService.GetInsuredContactByPolicyNumber(policynumber);
                if (inscon == null)
                {
                    return BadRequest("Returns Null");
                }
                return Ok(inscon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
