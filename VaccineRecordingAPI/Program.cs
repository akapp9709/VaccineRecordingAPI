using Microsoft.EntityFrameworkCore;
using VaccineRecording.Data;
using VaccineRecording.Data.Repositories;
using VaccineRecording.Data.Repositories.Interfaces;
using VaccineRecording.Data.Services;
using VaccineRecording.Data.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContextFactory<VaccineRecordingContext>();

// Add Repositories to Dependency Pool
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IAdministrationsRepository, AdministrationsRepository>();

// Add Services to Dependency Pool
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IVaccineService, VaccineService>();
builder.Services.AddScoped<IBatchesService, BatchesService>();
builder.Services.AddScoped<IAdministrationsService, AdministrationService>();
builder.Services.AddScoped<IAuditingService, AuditingService>();

var app = builder.Build();

using (IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    VaccineRecordingContext context = serviceScope.ServiceProvider.GetService<VaccineRecordingContext>()!;
    var migrations = context.Database.GetPendingMigrations().ToList();

    context.Database.Migrate();
}

app.MapControllers();

app.Run();
