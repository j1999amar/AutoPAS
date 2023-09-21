using AutoPASBL;
using AutoPASAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPASAL;
using AutoPASDML;

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelTypeService _fueltypeService;
        private readonly ILogger<FuelTypeController> _logger;
        public FuelTypeController(IFuelTypeService fueltypeService, ILogger<FuelTypeController> logger)
        {
            _fueltypeService = fueltypeService;
            _logger = logger;
        }


        //Get All fuel types
        [HttpGet("GetFuelTypes{ModelId}")]
        public async Task<IActionResult> GetFuelTypes(int ModelId)
        {
            try
            {
                return Ok(await _fueltypeService.GetFuelTypes(ModelId));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllFuelTypes");
                return StatusCode(500, ex);
            }

        }
        [HttpGet("GetAllFuelTypes")]
        public async Task<IActionResult> GetAllFuelTypes()
        {
            try
            {
                return Ok(await _fueltypeService.GetAllFuelTypes());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllFuelTypes");
                return StatusCode(500, ex);
            }

        }

        //Add FuelType 
        [HttpPost("AddFuelType")]
        public async Task<IActionResult> AddFuelType([FromBody] fueltype fuelType)
        {
            try
            {

                if (!_fueltypeService.IsExists(fuelType.FuelTypeId))
                {
                    return Ok(await _fueltypeService.AddFuelType(fuelType));
                }
                else
                {
                    _logger.LogInformation("Error in function AddFuelType Id is already exists");
                    return StatusCode(500, "AddFuelType Id is already exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddFuelType");
                return StatusCode(500, ex);
            }

        }

        //Edit FuelType 
        [HttpPut("EditFuelType")]
        public async Task<IActionResult> EditFuelType([FromBody] fueltype fuelType)
        {
            try
            {

                if (_fueltypeService.IsExists(fuelType.FuelTypeId))
                {
                    return Ok(await _fueltypeService.EditFuelType(fuelType));
                }
                else
                {
                    _logger.LogInformation("Error in function FuelType Id is not exists");
                    return StatusCode(500, "FuelType Id is not exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Edit FuelType");
                return StatusCode(500, ex);
            }

        }
    }
}
