using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Services.Interfaces;

namespace VaccineRecordingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private IBatchesService _batchesService;

        public BatchesController(
            IBatchesService batchesService
            )
        {
            _batchesService = batchesService;
        }

        [HttpGet]
        public IActionResult GetBatchs([FromQuery] int vaccineId)
        {
            List<VaccineBatch> result = _batchesService.GetBatchesForVaccine(vaccineId);

            return Ok(new { result });
        }
    }
}
