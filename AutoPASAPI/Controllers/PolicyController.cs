using AutoPASAL.Services;
using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class PolicyController : Controller

    {
        private readonly IPolicyService _policyService;
        private readonly ILogger<PolicyController> _logger;
        public PolicyController(IPolicyService policyService, ILogger<PolicyController> logger)
        {
            _policyService = policyService;
            _logger = logger;
        }


        //Get All Policies
        [HttpGet("GetAllPolicies")]
        public async Task<IActionResult> GetAllPolicies()
        {
            try
            {
                var pol = await _policyService.GetAllPolicies();
                if (pol != null)
                {
                    return Ok(pol);
                }
                else
                {
                    return BadRequest("Returns Null");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllPolicies");
                return StatusCode(500, ex);
            }

        }
        [HttpGet("GetPoliciesInRange/{startIndex}/{count}")]
        public async Task<IActionResult> GetPoliciesInRange(int startIndex, int count)
        {
            try
            {
                var pol = await _policyService.GetPoliciesInRange(startIndex,count);
                if (pol != null)
                {
                    return Ok(pol);
                }
                else
                {
                    return BadRequest("Returns Null");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllPolicies");
                return StatusCode(500, ex);
            }

        }
        [HttpGet("GetPolicyCount")]
        public async Task<IActionResult> GetPolicyCount()
        {
            try
            {
                var count = await _policyService.GetPolicyCount();
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("No Policy");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllPolicies");
                return StatusCode(500, ex);
            }

        }

        //Get Single Policy
        [HttpGet("GetPolicyById/{Id}")]     
        public async Task<IActionResult> GetPolicyById(Guid Id)
        {
            try
            {
                var pol = await _policyService.GetPolicyById(Id);
                if (pol != null)
                {
                    return Ok(pol);
                }
                else
                {
                    return BadRequest("Returns Null");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetPolicyId");
                return StatusCode(500, ex);
            }
        }

        //Add Policy
        [HttpPost("AddPolicy")]
        public async Task<IActionResult> AddPolicy([FromBody] policy objPolicy)
        {
            try
            {
                return Ok(await _policyService.AddPolicy(objPolicy));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddPolicy");
                return StatusCode(500, ex);
            }
        }

        //Update Policy NCB
        [HttpPut("UpdatePolicy/{NCB}")]
        public async Task<IActionResult> UpdatePolicyNCB(int NCB)
        {
            try
            {
                return Ok(await _policyService.UpdatePolicyNCB(NCB));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdatePolicy");
                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdatePolicyById/{Id}")]
        public async Task<IActionResult> UpdatePolicyById(Guid Id, [FromBody] policy objPolicy)
        {
            try
            {
                return Ok(await _policyService.UpdatePolicyById(Id,objPolicy));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdatePolicyById");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetNCBById/{Id}")]
        public async Task<IActionResult> GetNCBById(Guid Id)
        {
            try
            {
                var ncb = await _policyService.GetNCBById(Id);
                if (ncb == 0 || ncb == 1)
                {
                    return Ok(ncb);
                }
                else
                {
                    return BadRequest("No NCB");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetPolicyId");
                return StatusCode(500, ex);
            }
        }
        //Get policy details
        [HttpGet("GetPolicyByPolicyNumber/{policynumber}")]
        public async Task<IActionResult> GetPolicyByPolicyNumber(string policynumber)
        {
            try
            {
                var pol = await _policyService.GetPolicyByPolicyNumber(policynumber);
                if (pol == null)
                {
                    return BadRequest("Returns Null");
                }
                return Ok(pol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
