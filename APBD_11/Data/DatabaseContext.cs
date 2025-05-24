using APBD_11.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_11.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().ToTable("Patient");
        modelBuilder.Entity<Doctor>().ToTable("Doctor");
        modelBuilder.Entity<Medicament>().ToTable("Medicament");
        modelBuilder.Entity<Prescription>().ToTable("Prescription");
        modelBuilder.Entity<PrescriptionMedicament>().ToTable("PrescriptionMedicament");
    }
}