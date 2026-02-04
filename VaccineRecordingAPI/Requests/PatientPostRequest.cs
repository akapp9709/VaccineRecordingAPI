using VaccineRecording.Data.Entities;

namespace VaccineRecordingAPI.Requests
{
    public class PatientPostRequest
    {
        public List<Patient> patients { get; set; } = new List<Patient>();
    }
}
