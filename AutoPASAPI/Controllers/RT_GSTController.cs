using AutoPASDML;
using AutoPASBL.Interface;
using Microsoft.AspNetCore.Mvc;
using AutoPASAL.Services;
using AutoPASSL;

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]

    [ApiController]

    public class RT_GSTController : ControllerBase
    {
        private readonly ILogger<RT_GSTController> _logger;
        private readonly IRT_GSTService _rt_gstService;
        public RT_GSTController(IRT_GSTService rt_gstService, ILogger<RT_GSTController> logger)
        {
            _rt_gstService = rt_gstService;
            _logger = logger;
        }
        [HttpGet("GetRT_GST")]

        public async Task<IActionResult> GetRT_GST()
        {
            try
            {
                return Ok(await _rt_gstService.GetRT_GST());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_GSTFactors");

                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetRT_GSTById/{id}")]

        public async Task<IActionResult> GetRT_GSTById(int id)
        {
            try
            {
                return Ok(await _rt_gstService.GetRT_GSTById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_GSTById");

                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateRT_GSTById")]

        public async Task<IActionResult> UpdateRT_GSTById([FromBody]RT_GST obj)
        {
            try
            {
                return Ok(await _rt_gstService.UpdateRT_GSTById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdateRT_GSTById");

                return StatusCode(500, ex);
            }
        }
        [HttpPost("AddRT_GSTEntry")]

        public async Task<IActionResult> AddRT_GSTEntry([FromBody] RT_GST obj)
        {
            try
            {
                return Ok(await _rt_gstService.AddRT_GSTEntry(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddRT_GSTEntry");

                return StatusCode(500, ex);
            }
        }
        [HttpDelete("DeleteRT_GSTEntry/{id}")]

        public async Task<IActionResult> DeleteRT_GSTEntry(int id)
        {
            try
            {
                return Ok(await _rt_gstService.DeleteRT_GSTEntry(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function DeleteRT_GSTEntry");

                return StatusCode(500, ex);
            }
        }
    }
}
