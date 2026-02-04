using VaccineRecording.Data.Entities;

namespace VaccineRecordingAPI.Requests
{
    public class VaccinePostRequest
    {
        public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
    }
}
