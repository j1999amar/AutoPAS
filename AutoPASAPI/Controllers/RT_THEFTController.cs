using AutoPASDML;
using AutoPASBL.Interface;
using Microsoft.AspNetCore.Mvc;
using AutoPASAL.Services;
using AutoPASSL;
using AutoPASAL;

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]

    [ApiController]

    public class RT_THEFTController : ControllerBase
    {
        private readonly ILogger<RT_THEFTController> _logger;
        private readonly IRT_THEFTService _rt_theftService;

        public RT_THEFTController(IRT_THEFTService rt_theftService, ILogger<RT_THEFTController> logger)
        {
            _rt_theftService = rt_theftService;
            _logger = logger;
        }
        [HttpGet("GetRT_THEFT")]

        public async Task<IActionResult> GetRT_THEFT()
        {
            try
            {
                return Ok(await _rt_theftService.GetRT_THEFT());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_THEFTFactors");

                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetRT_THEFTById/{id}")]

        public async Task<IActionResult> GetRT_THEFTById(int id)
        {
            try
            {
                return Ok(await _rt_theftService.GetRT_THEFTById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_THEFTById");

                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateRT_THEFTById")]

        public async Task<IActionResult> UpdateRT_THEFTById([FromBody] RT_THEFT obj)
        {
            try
            {
                return Ok(await _rt_theftService.UpdateRT_THEFTById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdateRT_THEFTById");

                return StatusCode(500, ex);
            }
        }
        [HttpPost("AddRT_THEFTEntry")]

        public async Task<IActionResult> AddRT_THEFTEntry([FromBody] RT_THEFT obj)
        {
            try
            {
                return Ok(await _rt_theftService.AddRT_THEFTEntry(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddRT_THEFTEntry");

                return StatusCode(500, ex);
            }
        }
        [HttpDelete("DeleteRT_THEFTEntry/{id}")]

        public async Task<IActionResult> DeleteRT_THEFTEntry(int id)
        {
            try
            {
                return Ok(await _rt_theftService.DeleteRT_THEFTEntry(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function DeleteRT_THEFTEntry");

                return StatusCode(500, ex);
            }
        }
    }
}
