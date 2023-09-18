using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoPASAL.Services;
using AutoPASBL;
using Microsoft.EntityFrameworkCore;
using AutoPASDML;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class BodyTypeController : Controller
    {
        private readonly IBodyTypeService _bodytypeService;
        private readonly ILogger<BodyTypeController> _logger;
        public BodyTypeController(IBodyTypeService bodytypeService, ILogger<BodyTypeController> logger)
        {
            _bodytypeService = bodytypeService;
            _logger = logger;
        }

        //Get All Vehicle Type
        [HttpGet("GetAllBodyType")]
        public async Task<IActionResult> GetAllBodyType()
        {
            try
            {
                return Ok(await _bodytypeService.GetAllBodyType());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllBodyType");
                return StatusCode(500, ex);
            }
        }

        //Add BodyType 
        [HttpPost("AddBodyType")]
        public async Task<IActionResult> AddBodyType([FromBody] bodyType bodyType)
        {
            try
            {
               
                if (!_bodytypeService.IsExists(bodyType.BodyTypeId))
                {
                    return Ok(await _bodytypeService.AddBodyType(bodyType));
                }
                else
                {
                    _logger.LogInformation("Error in function AddBodyType Id is already exists");
                    return StatusCode(500, "AddBodyType Id is already exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddBodyType");
                return StatusCode(500, ex);
            }

        }

    }
}
