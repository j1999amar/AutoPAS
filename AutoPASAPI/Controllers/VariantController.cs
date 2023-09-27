using AutoPASAL;
using AutoPASAL.Services;
using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class VariantController : Controller
    {
        private readonly IVariantService _variantService;
        private readonly ILogger<VariantController> _logger;
        public VariantController(IVariantService variantService, ILogger<VariantController> logger)
        {
            _variantService = variantService;
            _logger = logger;
        }

        //Get All Variant
        [HttpGet("GetAllVariant")]
        public async Task<IActionResult> GetAllVariant()
        {
            try
            {
                return Ok(await _variantService.GetAllVariant());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllVariant");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetVariant/{ModelId}/{FuelId}/{TransmissionId}")]
        public async Task<IActionResult> GetVariant(int ModelId, int FuelId, int TransmissionId)
        {
            try
            {
                return Ok(await _variantService.GetVariant(ModelId, FuelId, TransmissionId));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllVariant");
                return StatusCode(500, ex);
            }
        }

        //Add Variant 
        [HttpPost("AddVariant")]
        public async Task<IActionResult> AddVariant([FromBody] variant variant)
        {
            try
            {

                if (!_variantService.IsExists(variant.VariantId))
                {
                    return Ok(await _variantService.AddVariant(variant));
                }
                else
                {
                    _logger.LogInformation("Error in function Add variant Id is already exists");
                    return StatusCode(500, "Add Variant Id is already exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Add Variant");
                return StatusCode(500, ex);
            }

        }

        //Edit Variant 
        [HttpPut("EditVariant")]
        public async Task<IActionResult> EditVariant([FromBody] variant variant)
        {
            try
            {

                if (_variantService.IsExists(variant.VariantId))
                {
                    return Ok(await _variantService.EditVariant(variant));
                }
                else
                {
                    _logger.LogInformation("Error in function  variant Id is not exists");
                    return StatusCode(500, " Variant Id is not exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Edit Variant");
                return StatusCode(500, ex);
            }

        }
        //Delete Variant 
        [HttpDelete("DeleteVariant/{id}")]
        public IActionResult DeleteVariant([FromRoute] int id)
        {
            try
            {

                if (_variantService.IsExists(id))
                {
                    return Ok( _variantService.DeleteVariant(id));
                }
                else
                {
                    _logger.LogInformation("Error in function  variant Id is not exists");
                    return StatusCode(500, " Variant Id is not exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Edit Variant");
                return StatusCode(500, ex);
            }

        }
    }
}
