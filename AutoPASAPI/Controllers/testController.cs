using Microsoft.AspNetCore.Mvc;
using AutoPASAL.Services;
using AutoPASDML;

namespace AutoPASAPI.Controllers
{
     [Route("autopasapi /[controller]")]

     [ApiController]

    public class testController : ControllerBase
     { 
        private readonly ILogger<testController> _logger;
        private readonly ItestService _testService;

        public testController(ILogger<testController> logger,ItestService testService)
         { 
             _logger = logger;
             _testService=testService; 
         }
        [HttpGet("Gettest")]

        public async Task<IActionResult> Gettest()
         {
             try
             {
                return Ok(await _testService.Gettest());
             }
             catch (Exception ex)
             {
             _logger.LogInformation("Error in function Gettest");

             return StatusCode(500, ex);
             }
         }
        [HttpGet("GettestById/{id}")]

        public async Task<IActionResult> GettestById(int id)
         {
             try
             {
                return Ok(await _testService.GettestById(id));
             }
             catch (Exception ex)
             {
             _logger.LogInformation("Error in function GettestById");

             return StatusCode(500, ex);
             }
         }
        [HttpPut("UpdatetestById")]

        public async Task<IActionResult> UpdatetestById([FromBody] test obj)
         {
             try
             {
                return Ok(await _testService.UpdatetestById(obj));
             }
             catch (Exception ex)
             {
             _logger.LogInformation("Error in function UpdatetestById");

             return StatusCode(500, ex);
             }
         }
         [HttpPost("AddtestEntry")]
         public async Task<IActionResult> AddtestEntry([FromBody] test obj)
         {
             try
             {
                 return Ok(await _testService.AddtestEntry(obj));
             }
             catch (Exception ex)
             {
             _logger.LogInformation("Error in function AddtestEntry");
             return StatusCode(500, ex);
             }
         }
         [HttpDelete("DeletetestEntry /{id}")]
         public async Task<IActionResult> DeletetestEntry(int id)
         {
             try
             {
                 return Ok(await _testService.DeletetestEntry(id));
             }
             catch (Exception ex)
             {
                 _logger.LogInformation("Error in function DeletetestEntry");
                 return StatusCode(500, ex);
             }
         }
     }
}
