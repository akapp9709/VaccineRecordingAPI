using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Repositories.Interfaces;
using VaccineRecording.Data.Services.Interfaces;

namespace VaccineRecordingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IPatientService _patientService;
        private IPatientRepository _patientRepository;          //Interface for patients to be access - used interface for easy changes via DI

        public PatientsController(
            IPatientService patientService,
            IPatientRepository patientRepository
            ) 
        {
            _patientService = patientService;
            _patientRepository = patientRepository;
        }

        [HttpGet("search")]
        // URL: api/reports?name=<name>&id=<nationalID&dob=<date%20of%20birth>
        public IActionResult Search(
            [FromQuery] string? name,       // Patient Name    
            [FromQuery] string? id,         // National Id
            [FromQuery] string? dob)        // Date of Birth
        {
            DateTime? date = DateTime.TryParse(dob, out DateTime result) ? result : null;    // Safe conversion of string date to DateTime

            
            
            //List<Patient> patients = _patientRepository.FindPatients(name, id, date);
            List<Patient> patients = _patientService.FindPatients(name, id, date);

            return Ok(new {patients});
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Patient result = _patientRepository.GetSingle(id);
            Patient result = _patientService.GetSingle(id);

            return Ok(new { result });
        }


        [HttpPost]
        public IActionResult Insert(Patient patient)
        {
            //_patientRepository.Insert(patient);
            _patientService.Insert(patient);

            return Ok();
        }

        [HttpPost("bulk")]
        public IActionResult Insert(List<Patient> patients)
        {
            //_patientRepository.UpsertPatients(patients);
            _patientService.UpsertPatients(patients);

            return Ok();
        }

        [HttpGet("{patientId}/immunisations")]
        public IActionResult GetPatientImmunisations(int patientId)
        {
            List<Administration> result = _patientService.GetPatientAdministrations(patientId);
            return Ok(new { result });
        }
    }
}
