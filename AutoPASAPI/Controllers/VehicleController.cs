using AutoPASAL;
using AutoPASAL.Services;
using AutoPASBL;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehicleController> _logger;
        public VehicleController(IVehicleService vehicleService, ILogger<VehicleController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        [HttpGet("GetAllVehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                var veh = await _vehicleService.GetAllVehicles();
                if (veh == null)
                {
                    return BadRequest("Returns Null");
                }
                return Ok(veh);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllPolicies");
                return StatusCode(500, ex);
            }

        }
        [HttpGet("GetVehicleById/{Id}")]
        public async Task<IActionResult> GetVehicleById(Guid Id)
        {
            try
            {
                var veh = await _vehicleService.GetVehicleById(Id);
                if (veh == null)
                {
                    return BadRequest("Returns Null");
                }
                return Ok(veh);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetPolicyId");
                return StatusCode(500, ex);
            }
        }

        //Get All RTO State
        [HttpGet("GetAllRTOState")]
        public async Task<IActionResult> GetAllRTOState()
        {
            try
            {
                return Ok(await _vehicleService.GetAllRTOState());
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
                return Ok(await _vehicleService.GetRTOCityByState(State));
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
                return Ok(await _vehicleService.GetRTONameByCity(City));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetRTONameByCity");
                return StatusCode(500, ex);
            }
        }
        //Get Brand Name By Vehicle Type
        [HttpGet("GetBrandByVehicleType{VehicleType}")]
        public async Task<IActionResult> GetBrandByVehicleType(int VehicleType)
        {
            try
            {
                return Ok(await _vehicleService.GetBrandByVehicleType(VehicleType));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetBrandByVehicleType");
                return StatusCode(500, ex);
            }
        }

        [HttpPost("AddVehicle")]
        public async Task<IActionResult> AddVehicle([FromBody] vehicle objVehicle)
        {
            try
            {
                return Ok(await _vehicleService.AddVehicle(objVehicle));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddVehicle");
                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateVehicleById/{Id}")]
        public async Task<IActionResult> UpdateVehicleById(Guid Id, [FromBody] vehicle objVehicle)
        {
            try
            {
                return Ok(await _vehicleService.UpdateVehicleById(Id, objVehicle));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdatePolicyById");
                return StatusCode(500, ex);
            }
        }


        //Customer Portal Url to be shared to Other team : Get Vehicle Details By PolicyNumber
        [HttpGet("PolicyVehicle/{policyNumber}")]
        public async Task<IActionResult> GetVehicleDetailsByPolicyNumber([FromRoute] int policyNumber)
        {
            try
            {
                var veh = await _vehicleService.GetVehicleDetailsByPolicyNumber(policyNumber);
                if (veh == null)
                {
                    return BadRequest("Returns Null");
                }
                return Ok(veh);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetVehicleDetailsByPolicyNumber");
                return StatusCode(500, ex);
            }
        }
    }
}
