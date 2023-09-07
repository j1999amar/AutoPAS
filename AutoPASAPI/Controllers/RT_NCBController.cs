using AutoPASDML;
using AutoPASAL.Services;
using Microsoft.AspNetCore.Mvc;
using AutoPASSL;
using AutoPASAL;

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]

    [ApiController]

    public class RT_NCBController : ControllerBase
    {
        private readonly ILogger<RT_NCBController> _logger;
        private readonly IRT_NCBService _rt_ncbService;

        public RT_NCBController(IRT_NCBService rt_ncbService, ILogger<RT_NCBController> logger)
        {
            _rt_ncbService = rt_ncbService;
            _logger = logger;
        }
        [HttpGet("GetRT_NCB")]

        public async Task<IActionResult> GetRT_NCB()
        {
            try
            {
                return Ok(await _rt_ncbService.GetRT_NCB());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_NCBFactors");

                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetRT_NCBById/{id}")]

        public async Task<IActionResult> GetRT_NCBById(int id)
        {
            try
            {
                return Ok(await _rt_ncbService.GetRT_NCBById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_NCBById");

                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateRT_NCBById")]

        public async Task<IActionResult> UpdateRT_NCBById([FromBody] RT_NCB obj)
        {
            try
            {
                return Ok(await _rt_ncbService.UpdateRT_NCBById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdateRT_NCBById");

                return StatusCode(500, ex);
            }
        }
        [HttpPost("AddRT_NCBEntry")]

        public async Task<IActionResult> AddRT_NCBEntry([FromBody] RT_NCB obj)
        {
            try
            {
                return Ok(await _rt_ncbService.AddRT_NCBEntry(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddRT_NCBEntry");

                return StatusCode(500, ex);
            }
        }
        [HttpDelete("DeleteRT_NCBEntry/{id}")]

        public async Task<IActionResult> DeleteRT_NCBEntry(int id)
        {
            try
            {
                return Ok(await _rt_ncbService.DeleteRT_NCBEntry(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function DeleteRT_NCBEntry");

                return StatusCode(500, ex);
            }
        }
    }
}
