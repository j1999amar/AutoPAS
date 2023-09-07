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

    public class RT_ODPController : ControllerBase
    {
        private readonly ILogger<RT_ODPController> _logger;
        private readonly IRT_ODPService _rt_odpService;

        public RT_ODPController(IRT_ODPService rt_odpService, ILogger<RT_ODPController> logger)
        {
            _rt_odpService = rt_odpService;
            _logger = logger;
        }
        [HttpGet("GetRT_ODP")]

        public async Task<IActionResult> GetRT_ODP()
        {
            try
            {
                return Ok(await _rt_odpService.GetRT_ODP());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRT_ODPFactors");

                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateRT_ODPById")]

        public async Task<IActionResult> UpdateRT_ODPById([FromBody] RT_ODP obj)
        {
            try
            {
                return Ok(await _rt_odpService.UpdateRT_ODPById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdateRT_ODPById");

                return StatusCode(500, ex);
            }
        }
        [HttpPost("AddRT_ODPEntry")]

        public async Task<IActionResult> AddRT_ODPEntry([FromBody] RT_ODP obj)
        {
            try
            {
                return Ok(await _rt_odpService.AddRT_ODPEntry(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddRT_ODPEntry");

                return StatusCode(500, ex);
            }
        }
        [HttpDelete("DeleteRT_ODPEntry/{id}")]

        public async Task<IActionResult> DeleteRT_ODPEntry(int id)
        {
            try
            {
                return Ok(await _rt_odpService.DeleteRT_ODPEntry(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function DeleteRT_ODPEntry");

                return StatusCode(500, ex);
            }
        }
    }
}
