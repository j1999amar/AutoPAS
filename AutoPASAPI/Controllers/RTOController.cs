using AutoPASBL;
using AutoPASAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]

    public class RTOController : Controller
    {
        private readonly IRTOService _rtoService;
        private readonly ILogger<RTOController> _logger;
        public RTOController(IRTOService rtoService, ILogger<RTOController> logger)
        {
            _rtoService = rtoService;
            _logger = logger;
        }


        //Get All RTO State
        [HttpGet("GetAllRTOState")]
        public async Task<IActionResult> GetAllRTOState()
        {
            try
            {
                return Ok(await _rtoService.GetAllRTOState());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllRTOState");
                return StatusCode(500, ex);
            }
        }

        //Get RTO City By State
        [HttpGet("GetRTOCityByState{State}")]
        public async Task<IActionResult> GetRTOCityByState(string State)
        {
            try
            {
                return Ok(await _rtoService.GetRTOCityByState(State));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRTOCityByState");
                return StatusCode(500, ex);
            }
        }


        //Get RTO Name By City
        [HttpGet("GetRTONameByCity{City}")]
        public async Task<IActionResult> GetRTONameByCity(string City)
        {
            try
            {
                return Ok(await _rtoService.GetRTONameByCity(City));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRTONameByCity");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetAllRTO/{Id}")]
        public async Task<IActionResult> GetAllRTO(Guid Id)
        {
            try
            {
                return Ok(await _rtoService.GetAllRTO(Id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllRTOState");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetCity/{Id}")]
        public async Task<IActionResult> GetCity(Guid Id)
        {
            try
            {
                return Ok(await _rtoService.GetCity(Id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllRTOState");
                return StatusCode(500, ex);
            }
        }

    }
}
