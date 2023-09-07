using AutoPASBL;
using AutoPASAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
