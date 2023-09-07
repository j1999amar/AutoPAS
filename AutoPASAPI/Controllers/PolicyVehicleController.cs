using AutoPASBL.Interface;
using Microsoft.AspNetCore.Mvc;
using AutoPASBL;
using AutoPASDML;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AutoPASAL.Services;

namespace AutoPASAPI.Controllers
{

    [ApiController]
    [Route("autopasapi/[controller]")]
    public class PolicyVehicleController : Controller
    {
        private readonly IPolicyVehicleService _policyvehicleservice;
        private readonly ILogger<PolicyVehicleController> _logger;
        public PolicyVehicleController(IPolicyVehicleService policyvehicleservice, ILogger<PolicyVehicleController> logger)
        {
            _policyvehicleservice = policyvehicleservice;
            _logger = logger;
        }

        //Add Policy
        [HttpPost("insertpolicyvehicle")]
        public async Task<IActionResult> insertpolicyvehicle([FromBody] PolicyVehicle objPolicyVehicle)
        {
            try
            {
                return Ok(await _policyvehicleservice.Insertpolicyvehicle(objPolicyVehicle));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function InsertPolicyVehicle");
                return StatusCode(500, ex);
            }
        }
    }
}
