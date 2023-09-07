using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoPASBL.Interface;
using AutoPASBL;
using Microsoft.EntityFrameworkCore;
using AutoPASAL.Services;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class VehicleTypeController : Controller
    {
        private readonly IVehicleTypeService _vehicletypeservice;
        private readonly ILogger<VehicleTypeController> _logger;
        public VehicleTypeController(IVehicleTypeService vehicletypeservice, ILogger<VehicleTypeController> logger)
        {
            _vehicletypeservice = vehicletypeservice;
            _logger = logger;
        }

        //Get All Vehicle Type
        [HttpGet("GetAllVehicleType")]
        public async Task<IActionResult> GetAllVehicleType()
        {
            try
            {
                return Ok(await _vehicletypeservice.GetAllVehicleType());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllVehicleType");
                return StatusCode(500, ex);
            }
        }

    }
}
