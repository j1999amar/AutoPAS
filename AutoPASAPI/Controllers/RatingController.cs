using AutoPASBL;
using AutoPASAL.Services;
using AutoPASDML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Drawing.Printing;
using System.Text.Json;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class RatingController : Controller
    {
        private readonly IRT_GSTService _rt_gstService;
        private readonly IRT_LLPService _rt_llpService;
        private readonly IRT_NCBService _rt_ncbService;
        private readonly IRT_ODPService _rt_odpService;
        private readonly IRT_THEFTService _rt_theftService;
        private readonly IRT_TPCService _rt_tpcService;
        private readonly IRatingService _ratingService;
        private readonly ILogger<RatingController> _logger;
        public RatingController(IRatingService ratingService,IRT_GSTService rt_gstService, IRT_LLPService rt_llpService, IRT_NCBService rt_ncbService, IRT_ODPService rt_odpService, IRT_THEFTService rt_theftService, IRT_TPCService rt_tpcService, ILogger<RatingController> logger)
        {
            _ratingService = ratingService;
            _rt_gstService = rt_gstService;
            _rt_llpService = rt_llpService;
            _rt_ncbService = rt_ncbService;
            _rt_odpService = rt_odpService;
            _rt_theftService = rt_theftService;
            _rt_tpcService = rt_tpcService;
            _logger = logger;
        }
        [HttpGet("GetTableByName/{tablename}")]
        public async Task<IActionResult> GetTableByName(string tablename)
        {
            try
            {
                 return Ok(await _ratingService.GetTableByName(tablename));
                
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function  GetTableByName");
                return StatusCode(500, ex);
            }

        }
        [HttpGet("GetTableByNameAndId/{tablename}/{id}")]
        public async Task<IActionResult> GetTableByNameAndId(string tablename, int id)
        {
            try
            {
                return Ok(await _ratingService.GetTableByNameAndId(tablename,id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetTableByNameAndId");
                return StatusCode(500, ex);
            }
        }
        [HttpPut("UpdateTableEntryByName/{tablename}")]
        public async Task<IActionResult> UpdateTableByName(string tablename,[FromBody] JsonElement obj)
        {
            try
            {
                return Ok(await _ratingService.UpdateTableByName(tablename,obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdateRT_GSTById");

                return StatusCode(500, ex);
            }
        }
        [HttpPost("AddTableEntryByName/{tablename}")]
        public async Task<IActionResult> AddTableEntryByName(string tablename, [FromBody] JsonElement obj)
        {
            try
            {
                return Ok(await _ratingService.AddTableEntryByName(tablename,obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddRT_GSTEntry");

                return StatusCode(500, ex);
            }
        }
        [HttpDelete("DeleteTableEntry/{tablename}/{id}")]
        public async Task<IActionResult> DeleteTableEntry(string tablename,int id)
        {
            try
            {
                return Ok(await _ratingService.DeleteTableEntry(tablename,id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function DeleteRT_GSTEntry");

                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetNCBFactors")]
        public async Task<IActionResult> GetNCBFactors()
        {
            try
            {
                /**
                 *  For changing back to Dynamic Creation
                 */
                //return Ok(await _NCBFactorBL.GetNCBFactors());

                return Ok(await _rt_ncbService.GetRT_NCB());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetNCBFactors");
                return StatusCode(500, ex);
            }
        }
        [HttpGet("GetRateTableById/{id}")]
        [ActionName("GetRateTableById")]
        public async Task<IActionResult> GetRateTableById(int id)
        {
            try
            {
                return Ok(await _rt_ncbService.GetRT_NCBById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetNCBFactorsByID");
                return StatusCode(500, ex);
            }
        }
        /**
         * Update NCB factor
         */
        [HttpPut("UpdateNCBById")]
        public async Task<IActionResult> UpdateNCBById(RT_NCB obj)
        {
            try
            {
                return Ok(await _rt_ncbService.UpdateRT_NCBById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdatePolicy");
                return StatusCode(500, ex);
            }
        }
        /**
         * Update ODP factor
         */
        [HttpPut("UpdateODPById")]
        public async Task<IActionResult> UpdateODPById([FromBody]RT_ODP obj)
        {
            try
            {
                return Ok(await _rt_odpService.UpdateRT_ODPById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdatePolicy");
                return StatusCode(500, ex);
            }
        }
        /**
         *  Update TPC factor 
         */
        [HttpPut("UpdateTPCById")]
        public async Task<IActionResult> UpdateTPCById(RT_TPC obj)
        {
            try
            {
                return Ok(await _rt_tpcService.UpdateRT_TPCById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdatePolicy");
                return StatusCode(500, ex);
            }
        }
        /**
         *  Update LLP factor 
         */
        [HttpPut("UpdateLLPById")]
        public async Task<IActionResult> UpdateLLPById([FromBody] RT_LLP obj)
        {
            try
            {
                return Ok(await _rt_llpService.UpdateRT_LLPById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdatePolicy");
                return StatusCode(500, ex);
            }
        }
        /**
         *  Update Theft factor 
         */
        [HttpPut("UpdateTheftById")]
        public async Task<IActionResult> UpdateTheftById([FromBody] RT_THEFT obj)
        {
            try
            {
                return Ok(await _rt_theftService.UpdateRT_THEFTById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdatePolicy");
                return StatusCode(500, ex);
            }
        }
        /**
         *  Update Gst factor 
         */
        [HttpPut("UpdateGstById")]
        public async Task<IActionResult> UpdateGstById([FromBody] RT_GST obj)
        {
            try
            {
                return Ok(await _rt_gstService.UpdateRT_GSTById(obj));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function UpdatePolicy");
                return StatusCode(500, ex);
            }
        }
        //Get All OD Factor
        [HttpGet("GetODFactors")]
        public async Task<IActionResult> GetODFactors()
        {
            try
            {
                //return Ok(await _OwnDamageFactorBL.GetODFactors());
                return Ok(await _rt_odpService.GetRT_ODP());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetODFactors");
                return StatusCode(500, ex);
            }
        }
        //Get All LLP Factor
        [HttpGet("GetLLPFactors")]
        public async Task<IActionResult> GetLLPFactors()
        {
            try
            {
                // return Ok(await _LegalLiabilityPremiumBL.GetLLPFactors());
                return Ok(await _rt_llpService.GetRT_LLP());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetLLPFactors");
                return StatusCode(500, ex);
            }
        }
        //Get All TPCP Factor
        [HttpGet("GetTPCPFactors")]
        public async Task<IActionResult> GetTPCPFactors()
        {
            try
            {
                // return Ok(await _ThirdPartyCoverPremiumBL.GetTPCPFactors());
                return Ok(await _rt_tpcService.GetRT_TPC());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetTPCPFactors");
                return StatusCode(500, ex);
            }
        }
        //Get All Theft Factor
        [HttpGet("GetTheftFactors")]
        public async Task<IActionResult> GetTheftFactors()
        {
            try
            {
                // return Ok(await _TheftFactorBL.GetTheftFactors());
                return Ok(await _rt_theftService.GetRT_THEFT());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetTheftFactors");
                return StatusCode(500, ex);
            }
        }
        //Get All GST Factor
        [HttpGet("GetGSTFactors")]
        public async Task<IActionResult> GetGSTFactors()
        {
            try
            {
                //return Ok(await _GSTFactorBL.GetGSTFactors());
                return Ok(await _rt_gstService.GetRT_GST());

            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetGSTFactors");
                return StatusCode(500, ex);
            }
        }
    }
}
