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

    public class RT_LLPController : ControllerBase
    {
        private readonly ILogger<RT_LLPController> _logger;
        private readonly IRT_LLPService _rt_llpService;

        public RT_LLPController(IRT_LLPService rt_llpService, ILogger<RT_LLPController> logger)
        {
            _rt_llpService = rt_llpService;
            _logger = logger;
        }
        [HttpGet("GetRT_LLP")]

        public async Task<IActionResult> GetRT_LLP()
        {
            try
            {
                return Ok(await _rt_llpService.GetRT_LLP());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_LLPFactors");

                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetRT_LLPById/{id}")]

        public async Task<IActionResult> GetRT_LLPById(int id)
        {
            try
            {
                return Ok(await _rt_llpService.GetRT_LLPById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_LLPById");

                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateRT_LLPById")]

        public async Task<IActionResult> UpdateRT_LLPById([FromBody]RT_LLP obj)
        {
            try
            {
                return Ok(await _rt_llpService.UpdateRT_LLPById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdateRT_LLPById");

                return StatusCode(500, ex);
            }
        }
        [HttpPost("AddRT_LLPEntry")]

        public async Task<IActionResult> AddRT_LLPEntry([FromBody] RT_LLP obj)
        {
            try
            {
                return Ok(await _rt_llpService.AddRT_LLPEntry(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddRT_LLPEntry");

                return StatusCode(500, ex);
            }
        }
        [HttpDelete("DeleteRT_LLPEntry/{id}")]

        public async Task<IActionResult> DeleteRT_LLPEntry(int id)
        {
            try
            {
                return Ok(await _rt_llpService.DeleteRT_LLPEntry(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function DeleteRT_LLPEntry");

                return StatusCode(500, ex);
            }
        }
    }
}
