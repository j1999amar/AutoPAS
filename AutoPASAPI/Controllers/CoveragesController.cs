using AutoPASBL.Interface;
using Microsoft.AspNetCore.Mvc;
using AutoPASAL.Services;
using AutoPASDML;
using Microsoft.EntityFrameworkCore;
using AutoPASAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoPASAPI.Controllers
{
    [Route("autopasapi/[controller]")]
    [ApiController]
    public class CoveragesController : ControllerBase
    {
        // GET: api/<CoveragesController>
        private readonly ICoverageService _coverageService;
        private readonly ILogger<CoveragesController> _logger;
        public CoveragesController(ICoverageService coverageService, ILogger<CoveragesController> logger)
        {
            _coverageService = coverageService;
            _logger = logger;
        }

            
        [HttpGet]
        public async Task<IActionResult> GetAllCoverages()
        {
            try
            {
                return Ok(await _coverageService.GetAllCoverages());
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Error in function GetAllCoverages");
                return StatusCode(500, ex);
            }
        }

        // GET api/<CoveragesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CoveragesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CoveragesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoveragesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("CalculatePremium")]
        public async Task<IActionResult> CalculatePremium()
        {
            try
            {
                return Ok(await _coverageService.GetPremium());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function CalculatePremium");
                return StatusCode(500, ex);
            }
        }

        //Add Coverage 
        [HttpPost("AddCoverage")]
        public async Task<IActionResult> AddCoverage([FromBody] coverages coverages)
        {
            try
            {

                if (!_coverageService.IsExists(coverages.CoverageId))
                {
                    return Ok(await _coverageService.AddCoverages(coverages));
                }
                else
                {
                    _logger.LogInformation("Error in function Add Coverage. Id is already exists");
                    return StatusCode(500, "Add Coverage Id is already exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function Add Coverage");
                return StatusCode(500, ex);
            }

        }
    }
}
