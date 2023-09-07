using AutoPASBL;
using AutoPASAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class BrandsController : Controller
    {
        private readonly IBrandsService _brandsService;
        private readonly ILogger<BrandsController> _logger;
        public BrandsController(IBrandsService brandsService, ILogger<BrandsController> logger)
        {
            _brandsService = brandsService;
            _logger = logger;
        }


        
        [HttpGet("GetBrandByVehicleType{VehicleType}")]
        public async Task<IActionResult> GetBrandByVehicleType(int VehicleType)
        {
            try
            {
                return Ok(await _brandsService.GetBrandByVehicleType(VehicleType));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetBrandByVehicleType");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetAllBrand")]
        public async Task<IActionResult> GetAllBrand()
        {
            try
            {
                return Ok(await _brandsService.GetAllBrand());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetBrandByVehicleType");
                return StatusCode(500, ex);
            }
        }
    }
}
