using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Services.Interfaces;

namespace VaccineRecordingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationsController : ControllerBase
    {
        private IAdministrationsService _administrationsService;

        public AdministrationsController(
            IAdministrationsService administrationsService)
        {
            _administrationsService = administrationsService;
        }

        [HttpPost]
        public IActionResult PostAdministration(Administration administration)
        {
            _administrationsService.InsertAdministration(administration);

            return Created();
        }

    }
}
