using Microsoft.AspNetCore.Mvc;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using AutoPASBL;
using AutoPASAL.Services;
using AutoPASSL;

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
                return Ok(await _insuredcontactService.GetInsuredById(Id));
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
                return Ok(await _insuredcontactService.GetContactById(Id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddInsuredContact");
                return StatusCode(500, ex);
            }
        }

    }
}
