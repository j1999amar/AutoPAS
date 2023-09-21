using AutoPASBL;
using AutoPASAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPASAL;
using AutoPASDML;

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

        //Add Brands 
        [HttpPost("AddBrands")]
        public async Task<IActionResult> AddBrands([FromBody] Brands brands)
        {
            try
            {

                if (!_brandsService.IsExists(brands.BrandId))
                {
                    if (_brandsService.vehicleTypeIdIsExists(brands.VehicleTypeId))
                    {
                        return Ok(await _brandsService.AddBrands(brands));
                    }
                    else
                    {
                        _logger.LogInformation("Error in function  Vehicle Type Id is not exists");
                        return StatusCode(500, " Vehicle Type Id is not exists");
                    }

                }
                else
                {
                    _logger.LogInformation("Error in function Add Brands Id is already exists");
                    return StatusCode(500, " Brands Id is already exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Add Brands");
                return StatusCode(500, ex);
            }

        }

        //Edit Brands 
        [HttpPut("EditBrands")]
        public async Task<IActionResult> EditBrands([FromBody] Brands brands)
        {
            try
            {

                if (_brandsService.IsExists(brands.BrandId))
                {
                    if (_brandsService.vehicleTypeIdIsExists(brands.VehicleTypeId))
                    {
                        return Ok(await _brandsService.EditBrands(brands));
                    }
                    else
                    {
                        _logger.LogInformation("Error in function  Vehicle Type Id is not exists");
                        return StatusCode(500, " Vehicle Type Id is not exists");
                    }
                }
                else
                {
                    _logger.LogInformation("Error in function  Brands Id is not exists");
                    return StatusCode(500, " Brands Id is not exists ");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Brands");
                return StatusCode(500, ex);
            }
        }
    }
}
