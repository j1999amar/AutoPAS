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
        //Add Transmission Type  
        [HttpPost("AddTransmissionType")]
        public async Task<IActionResult> AddTransmissionType([FromBody] transmissiontype transmissiontype)
        {
            try
            {

                if (!_transmissionTypeService.IsExists(transmissiontype.TransmissionTypeId))
                {
                    return Ok(await _transmissionTypeService.AddTransmissionType(transmissiontype));
                }
                else
                {
                    _logger.LogInformation("Error in function Add transmission type Id is already exists");
                    return StatusCode(500, "Add transmission Id is already exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Add transmission");
                return StatusCode(500, ex);
            }

        }

        //Edit Transmission Type  
        [HttpPut("EditTransmissionType")]
        public async Task<IActionResult> EditTransmissionType([FromBody] transmissiontype transmissiontype)
        {
            try
            {

                if (_transmissionTypeService.IsExists(transmissiontype.TransmissionTypeId))
                {
                    return Ok(await _transmissionTypeService.EditTransmissionType(transmissiontype));
                }
                else
                {
                    _logger.LogInformation("Error in function  transmission type Id is not exists");
                    return StatusCode(500, "Transmission Id is not exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function edit transmission");
                return StatusCode(500, ex);
            }

        }
    }
}
