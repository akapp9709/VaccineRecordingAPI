using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Exceptions;
using VaccineRecording.Data.Repositories.Interfaces;
using VaccineRecording.Data.Services.Interfaces;

namespace VaccineRecording.Data.Services
{
    public class AdministrationService : IAdministrationsService
    {
        private IAdministrationsRepository _administrationsRepository;
        private VaccineRecordingContext _context;

        public AdministrationService(
            IAdministrationsRepository administrationsRepository,
            VaccineRecordingContext context)
        {
            _administrationsRepository = administrationsRepository;
            _context = context;
        }

        public List<Administration> GetAdministrations(string from, string to)
        {
            DateTime fromDate, toDate;
            if (!TryParseIsoDate(from, out fromDate))
                throw new BadRequestException($"String {from} must be in the format YYY-MM-DD");

            if (!TryParseIsoDate(to, out toDate))
                throw new BadRequestException($"String {to} must be in the format YYY-MM-DD");


            List<Administration> administrations = _context.Administration
                .Include(a => a.AdministrationVaccine)
                .Where(a => a.AdministeredOn > fromDate &&
                    a.AdministeredOn < toDate).ToList();

            return administrations;
        }

        public List<Administration> GetOverdueVaccinations(string asof)
        {
            List<Administration> administrations = _context.Administration
                .Include(a => a.AdministrationVaccine)
                .Where(a => a.AdministeredOn.AddDays((double)a.AdministrationVaccine.DoseIntervalDays.Value) > DateTime.Now).ToList();

            return administrations;
        }

        public void InsertAdministration(Administration administration)
        {
            using IDbContextTransaction transaction = _context.Database.BeginTransaction();

            try
            {
                EntityEntry<Administration> entry = _context.Administration.Add(administration);
                _context.SaveChanges();

                Administration admin = entry.Entity;

                _context.AuditLogs.Add(new AuditLog
                {
                    EntityName = "Administration",
                    EntityId = admin.AdministrationId,
                    Action = "INSERT",
                    ChangedBy = admin.AdministeredBy,
                    ChangeUtc = DateTime.Now,
                    ChangeSummary = $"New dose (No.: {admin.DoseNo}) for patient ({admin.PatientId}) for Vaccine ({admin.VaccineId})"
                });

                _context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                return;
            }
            
        }

        private bool TryParseIsoDate(string input, out DateTime result)
        {
            return DateTime.TryParseExact(
                input,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
                out result
            );
        }
    }
}
