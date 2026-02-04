using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineRecording.Data.Entities;

namespace VaccineRecording.Data.Services.Interfaces
{
    public interface IPatientService
    {
        List<Patient> FindPatients(string? name, string? id, DateTime? date);
        List<Administration> GetPatientAdministrations(int patientId);
        Patient GetSingle(int id);
        void Insert(Patient patient);
        void UpsertPatients(List<Patient> patients);
    }
}
