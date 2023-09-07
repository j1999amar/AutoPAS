using AutoPASAL.Services;
using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class PolicyInsuredController : Controller
    {
        private readonly IPolicyInsuredService _policyInsuredService;
        private readonly ILogger<PolicyInsuredController> _logger;
        public PolicyInsuredController(IPolicyInsuredService policyInsuredService, ILogger<PolicyInsuredController> logger)
        {
            _policyInsuredService = policyInsuredService;
            _logger = logger;
        }
       
        //Add Policy
        [HttpPost("insertpolicyinsured")]
        public async Task<IActionResult> insertpolicyinsured([FromBody] PolicyInsured objPolicyInsured)
        {
            try
            {
                objPolicyInsured.PolicyId = SessionVariables.PolicyId.ToString();
                return Ok(await _policyInsuredService.Insertpolicyinsured(objPolicyInsured));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function InsertPolicyInsured");
                return StatusCode(500, ex);
            }
        }
    }
}
