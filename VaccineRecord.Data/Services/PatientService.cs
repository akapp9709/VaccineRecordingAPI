using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Exceptions;
using VaccineRecording.Data.Repositories.Interfaces;
using VaccineRecording.Data.Services.Interfaces;

namespace VaccineRecording.Data.Services
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        private IAdministrationsRepository _administrationsRepository;

        public PatientService(
            IPatientRepository patientRepository,
            IAdministrationsRepository administrationsRepository)
        {
            _patientRepository = patientRepository;
            _administrationsRepository = administrationsRepository;
        }

        public List<Patient> FindPatients(string? name, string? id, DateTime? date)
        {
            List<Patient> patients = _patientRepository.FindPatients(name, id, date);

            return patients;
        }

        public List<Administration> GetPatientAdministrations(int patientId)
        {
            List<Administration> administrations = _administrationsRepository.GetCompletedCourses(patientId);

            return administrations;
        }

        public Patient GetSingle(int id)
        {
            Patient? patient = _patientRepository.GetSingle<int>(id);

            if (patient == null)
                throw new NotFoundException($"Patient with ID ({id}) not found");

            return patient;
        }

        public void Insert(Patient patient)
        {
            _patientRepository.Insert(patient);
        }

        public void UpsertPatients(List<Patient> patients)
        {
            _patientRepository.UpsertPatients(patients);
        }
    }
}
