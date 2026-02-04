using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Services.Interfaces;

namespace VaccineRecordingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IAdministrationsService _administrationsService;

        public ReportsController(
            IAdministrationsService administrationsService)
        {
            _administrationsService = administrationsService;
        }

        [HttpGet("overdue")]
        public IActionResult GetOverDueVaccinations([FromQuery] string asof)
        {
            List<Administration> result = _administrationsService.GetOverdueVaccinations(asof);
            return Ok(result);
        }

        [HttpGet("coverage")]
        public IActionResult GetCoveredVaccinations([FromQuery] string from, [FromQuery] string to)
        {
            List<Administration> result = _administrationsService.GetAdministrations(from, to);
            return Ok(result);
        }
    }
}
