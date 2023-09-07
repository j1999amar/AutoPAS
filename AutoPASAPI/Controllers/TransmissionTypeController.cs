using AutoPASBL;
using AutoPASBL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using AutoPASAL.Services;
using AutoPASAL;

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]
    [ApiController]
    public class TransmissionTypeController : ControllerBase
    {
        private readonly ITransmissionTypeService _transmissionTypeService;
        private readonly ILogger<TransmissionTypeController> _logger;
        public TransmissionTypeController(ITransmissionTypeService transmissionTypeService, ILogger<TransmissionTypeController> logger)
        {
            _transmissionTypeService = transmissionTypeService;
            _logger = logger;
        }
        //Get All ModelsBL;

        //Get All Models
        [HttpGet("GetTransmission/{ModelId}/{FuelId}")]
        public async Task<IActionResult> GetTransmissionTypes(int ModelId, int FuelId)
        {
            try
            {
                return Ok(await _transmissionTypeService.GetTransmissionTypes(ModelId, FuelId));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllTransmissionTypes");
                return StatusCode(500, ex);
            }

        }
        [HttpGet("GetAllTransmission")]
        public async Task<IActionResult> GetAllTransmissionTypes()
        {
            try
            {
                return Ok(await _transmissionTypeService.GetAllTransmissionTypes());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetAllTransmissionTypes");
                return StatusCode(500, ex);
            }

        }
    }
}
