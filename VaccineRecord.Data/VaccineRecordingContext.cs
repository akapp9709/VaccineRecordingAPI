using Microsoft.EntityFrameworkCore;
using VaccineRecording.Data.Entities;

namespace VaccineRecording.Data
{
    public class VaccineRecordingContext: DbContext
    {
        #region DbSets
        public DbSet<Administration> Administration { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineBatch> VaccineBatches { get; set; }
        #endregion

        public string DbPath { get; }
        public VaccineRecordingContext() 
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = System.IO.Path.Join(path, "vaccine.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sex>().HasData(
                new Sex { SexId = 1, Description = "Male"},
                new Sex { SexId = 2, Description = "Female"}
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "support"}
            );

            modelBuilder.Entity<Vaccine>()
                .HasMany(v => v.VaccineBatches)
                .WithOne(b => b.BatchVaccine)
                .HasForeignKey(b => b.VaccineId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
