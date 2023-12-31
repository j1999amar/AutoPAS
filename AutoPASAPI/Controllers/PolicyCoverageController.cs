﻿using AutoPASAL.Services;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]
    [ApiController]
    public class PolicyCoverageController : ControllerBase
    {
        private readonly IPolicyCoverageService _policyCoverageService;
        private readonly ILogger<PolicyCoverageController> _logger;
        public PolicyCoverageController(IPolicyCoverageService policyCoverageService, ILogger<PolicyCoverageController> logger)
        {
            _policyCoverageService = policyCoverageService;
            _logger = logger;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddPolicyCoverage([FromBody] List<int> coverageID)
        {
            try
            {                
                return Ok(await _policyCoverageService.AddPolicyCoverage(coverageID));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddPolicyCoverage");
                return StatusCode(500, ex);
            }
        }

        [HttpPost("Edit/{Id}")]
        public async Task<IActionResult> EditPolicyCoverage(Guid Id,[FromBody] List<int> coverageID)
        {
            try
            {
           
                return Ok(await _policyCoverageService.EditPolicyCoverage(Id,coverageID));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function EditPolicyCoverage");
                return StatusCode(500, ex);
            }

        }
        [HttpGet("GetPolicyCoverageById/{Id}")]
        public async Task<IActionResult> GetPolicyCoverageById(Guid Id)
        {
            try
            {
                //Pass policyId and CoverageId from UI page. Based on implmentation this code may need to be modified later
                return Ok(await _policyCoverageService.GetPolicyCoverageById(Id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddPolicyCoverage");
                return StatusCode(500, ex);
            }

        }
    }
}
