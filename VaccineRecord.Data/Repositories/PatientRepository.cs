using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Repositories.Interfaces;

namespace VaccineRecording.Data.Repositories
{
    public class PatientRepository : 
        Repository<VaccineRecordingContext, Patient>, 
        IPatientRepository
    {
        public PatientRepository(VaccineRecordingContext context) : base(context)
        {
        }

        public List<Patient> FindPatients(string? name, string? idNo, DateTime? dateOfBirth)
        {
            List<Patient> result = new List<Patient>();  

            if (!string.IsNullOrEmpty(name))
            {
                string[] names = name.Split(' ');                   // Split Full names into separate words

                result.AddRange(GetAllLikeName(name));              // Search for full name first

                foreach (string word in names)                      // Search for individual names
                {
                    result.AddRange(GetAllLikeName(word));
                }
            }

            if (!string.IsNullOrEmpty(idNo))
            {
                result.AddRange(GetAllByIdNo(idNo));                // Search by Id Number/Passport
            }

            if (dateOfBirth != null)
            {
                result.AddRange(GetAllByDOB(dateOfBirth.Value));    // Search by Date of Birth
            }

            return result;                                          // All Patients found that match Criteria are added to a single list to be returned.
        }

        // Noncase-sensitive name search
        public List<Patient> GetAllLikeName(string name)
        {
            return _context.Patients.Where(patient 
                => EF.Functions.Like(
                    patient.FirstName.ToLower(),
                    $"%{name.ToLower()}%"
                    ) ||
                    EF.Functions.Like(
                        patient.LastName.ToLower(),
                    $"%{name.ToLower()}%"
                    )
                ).ToList();
        }

        // Specific Date of Birth Search
        public List<Patient> GetAllByDOB(DateTime date)
        {
            return _context.Patients.Where(patient => 
                    patient.DateOfBirth == date                    
                ).ToList();
        }

        // Specific Id Number Search
        public List<Patient> GetAllByIdNo(string idNo)
        {
            return _context.Patients.Where(patient => 
                    patient.NationalId == idNo || patient.PassportNo == idNo                    
                ).ToList();
        }

        public void UpsertPatients(List<Patient> patients)
        {
            if(!patients.Any())
                return;

            foreach (Patient patient in patients)
            {
                if(Exists(patient.PatientId))
                    Update(patient);
                else
                    Insert(patient);
            }
        }

        public Patient GetById(int id)
        {
            Patient? result = _context.Patients.Where(patient => patient.PatientId == id).FirstOrDefault();

            return result == null ? result! : new Patient();
        }

        public void Update(Patient item)
        {
            _context.Patients.ExecuteUpdate(patient => 
                patient.SetProperty(p => p.FirstName, item.FirstName)
                    .SetProperty(p => p.LastName, item.LastName)
                    .SetProperty(p => p.DateOfBirth, item.DateOfBirth)
                    .SetProperty(p => p.SexId, item.SexId)
                    .SetProperty(p => p.ContactNumber, item.ContactNumber)
                    .SetProperty(p => p.EmailAddress, item.EmailAddress)
                    .SetProperty(p => p.NationalId, item.NationalId)
                    .SetProperty(p => p.PassportNo, item.PassportNo)
                    .SetProperty(p => p.ForeignNational, item.ForeignNational)
            );
        }

        public bool Exists(int id)
        {
            Patient? temp = _context.Patients.Where(patient => patient.PatientId == id).FirstOrDefault();
            return temp != null;
        }
    }
}
