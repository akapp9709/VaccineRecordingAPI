using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineRecording.Data.Entities;

namespace VaccineRecording.Data.Repositories.Interfaces
{
    public interface IPatientRepository: IRepository<Patient>
    {
        public List<Patient> FindPatients(string? name, string? idNo, DateTime? dateOfBirth);   // Finds All patients that cold match to any of the 3 fields
        public void UpsertPatients(List<Patient> patients);
        public Patient GetById(int id);// Inserts Patients that do not already exist, and Updates Patients that do.
    }
}
