using AutoPASBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoPASAL.Services;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        private readonly ILogger<ModelController> _logger;
        public ModelController(IModelService modelService, ILogger<ModelController> logger)
        {
            _modelService = modelService;
            _logger = logger;
        }
        //Get All Models
        [HttpGet("GetModelByBrand{BrandId}")]
        public async Task<IActionResult> GetModelByBrand(int BrandId)
        {
            try
            {
                return Ok(await _modelService.GetModelByBrand(BrandId));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllModels");
                return StatusCode(500, ex);
            }

        }
        [HttpGet("GetAllModel")]
        public async Task<IActionResult> GetAllModel()
        {
            try
            {
                return Ok(await _modelService.GetAllModel());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllModels");
                return StatusCode(500, ex);
            }

        }
    }
}
