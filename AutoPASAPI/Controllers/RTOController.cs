using AutoPASBL;
using AutoPASAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPASAL;
using AutoPASDML;

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

        //Add RTO 
        [HttpPost("AddRTO")]
        public async Task<IActionResult> AddRTO([FromBody] rto rto)
        {
            try
            {

                if (!_rtoService.IsExists(rto.RTOId))
                {
                    return Ok(await _rtoService.AddRTO(rto));
                }
                else
                {
                    _logger.LogInformation("Error in function Add RTO Id is already exists");
                    return StatusCode(500, "Add RTO Id is already exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Add RTO");
                return StatusCode(500, ex);
            }

        }

        //Edit RTO 
        [HttpPut("EditRTO")]
        public async Task<IActionResult> EditRTO([FromBody] rto rto)
        {
            try
            {

                if (_rtoService.IsExists(rto.RTOId))
                {
                    return Ok(await _rtoService.EditRTO(rto));
                }
                else
                {
                    _logger.LogInformation("Error in function  RTO Id is not exists");
                    return StatusCode(500, " RTO Id is not exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Edit RTO");
                return StatusCode(500, ex);
            }

        }

        //Delete RTO 
        [HttpDelete("DeleteRTO/{id}")]
        public IActionResult DeleteRTO([FromRoute] int id)
        {
            try
            {

                if (_rtoService.IsExists(id))
                {
                    return Ok( _rtoService.DeleteRTO(id));
                }
                else
                {
                    _logger.LogInformation("Error in function  RTO Id is not exists");
                    return StatusCode(500, " RTO Id is not exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Edit RTO");
                return StatusCode(500, ex);
            }

        }
    }
}
