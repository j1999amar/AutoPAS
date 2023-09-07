using AutoPASDML;
using AutoPASBL.Interface;
using Microsoft.AspNetCore.Mvc;
using AutoPASBL;
using AutoPASSL;
using AutoPASAL.Services;
using AutoPASAL;

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]

    [ApiController]

    public class RT_TPCController : ControllerBase
    {
        private readonly ILogger<RT_TPCController> _logger;
        private readonly IRT_TPCService _rt_tpcService;

        public RT_TPCController(IRT_TPCService rt_tpcService, ILogger<RT_TPCController> logger)
        {
            _rt_tpcService = rt_tpcService;
            _logger = logger;
        }
        [HttpGet("GetRT_TPC")]

        public async Task<IActionResult> GetRT_TPC()
        {
            try
            {
                return Ok(await _rt_tpcService.GetRT_TPC());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_TPCFactors");

                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetRT_TPCById/{id}")]

        public async Task<IActionResult> GetRT_TPCById(int id)
        {
            try
            {
                return Ok(await _rt_tpcService.GetRT_TPCById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_TPCById");

                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateRT_TPCById")]

        public async Task<IActionResult> UpdateRT_TPCById([FromBody] RT_TPC obj)
        {
            try
            {
                return Ok(await _rt_tpcService.UpdateRT_TPCById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdateRT_TPCById");

                return StatusCode(500, ex);
            }
        }
        [HttpPost("AddRT_TPCEntry")]

        public async Task<IActionResult> AddRT_TPCEntry([FromBody] RT_TPC obj)
        {
            try
            {
                return Ok(await _rt_tpcService.AddRT_TPCEntry(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddRT_TPCEntry");

                return StatusCode(500, ex);
            }
        }
        [HttpDelete("DeleteRT_TPCEntry/{id}")]

        public async Task<IActionResult> DeleteRT_TPCEntry(int id)
        {
            try
            {
                return Ok(await _rt_tpcService.DeleteRT_TPCEntry(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function DeleteRT_TPCEntry");

                return StatusCode(500, ex);
            }
        }
    }
}
