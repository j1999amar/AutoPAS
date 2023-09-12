using AutoPASAL;
using AutoPASAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class MasterController : Controller
    {
        private readonly IMasterService _masterService;
        private readonly ILogger<BrandsController> _logger;
        public MasterController(IMasterService masterService, ILogger<BrandsController> logger)
        {
            _masterService = masterService;
            _logger = logger;
        }

        [HttpGet("GetAllMaster")]
        public async Task<IActionResult> GetAllMaster()
        {
            try
            {
                return Ok(await _masterService.GetAllMaster());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllMaster");
                return StatusCode(500, ex);
            }
        }
    }
   }
