using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Repositories.Interfaces;
using VaccineRecording.Data.Services.Interfaces;

namespace VaccineRecordingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private IVaccineService _vaccineService;

        public VaccinesController(
            IVaccineService vaccineService
            )
        {
            _vaccineService = vaccineService;
        }

        [HttpGet]
        public IActionResult GetVaccines()
        {
            List<Vaccine> result = _vaccineService.GetAllVaccines();

            return Ok( new {result});
        }

        [HttpGet]
        public IActionResult GetVaccine([FromQuery]int id)
        {
            Vaccine result = _vaccineService.GetVaccineById(id);

            return Ok(new { result });
        }

        [HttpPost]
        public IActionResult PostVaccine(Vaccine vaccine)
        {
            _vaccineService.InsertVaccine(vaccine);

            return Created();
        }

    }
}
