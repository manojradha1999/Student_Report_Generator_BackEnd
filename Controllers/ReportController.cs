using Microsoft.AspNetCore.Mvc;
using StudentMarks.BusinessLogic;
using StudentMarks.Context;
using StudentMarks.DTO.Report;
using StudentMarks.Repositery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentMarks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepositery _reportRepositery;

        public ReportController(IReportRepositery reportRepositery) {
            _reportRepositery = reportRepositery;
        }

        // Gets the report of the particular student.
        [HttpGet("{standard}/{name}")]
        public async Task<ActionResult<ReportDTO>> Get(int standard,string name)
        {
            var Reports = await _reportRepositery.GetReport(standard, name);
            if (Reports!= null)
            {
                return Ok(Reports);
            }

            return StatusCode(404, "Not Found");
        }
    }
}
