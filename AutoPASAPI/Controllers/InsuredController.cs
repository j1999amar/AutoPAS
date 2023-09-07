using AutoPASBL.Interface;
using AutoPASDML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoPASSL;

namespace AutoPASAPI.Controllers
{
    [ApiController]
    [Route("autopasapi/[controller]")]
    public class InsuredController : Controller
    {
        private readonly APASDBContext ApasDBContext;
        private readonly ILogger<InsuredController> _logger;
        public InsuredController(APASDBContext apasDBContext, ILogger<InsuredController> logger)
        {
            this.ApasDBContext = apasDBContext;
            _logger = logger;
        }


        //Get Insured
        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetInsured")]
        public async Task<IActionResult> GetInsured([FromRoute] Guid id)
        {
            try
            {
                var insured = await ApasDBContext.insured.FirstOrDefaultAsync(x => x.InsuredId == id);
                if (insured == null)
                {
                    return NotFound("Insured not found");
                   
                }
                return Ok(insured);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function GetInsured");
                return StatusCode(500, ex);
            }
        }

        //Add Insured
        [HttpPost]
        public async Task<IActionResult> AddInsured([FromBody] insured insured)
        {
            try
            {
                insured.InsuredId = new Guid();
                await ApasDBContext.insured.AddAsync(insured);
                await ApasDBContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetInsured), new { id = insured.InsuredId }, insured);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in function AddInsured");
                return StatusCode(500, ex);
            }
        }
    }
}
