using APBD_11.Data;
using APBD_11.DTOs;
using APBD_11.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_11.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context) => _context = context;
    
    public async Task AddPrescriptionAsync(AddPrescriptionRequest request)
    {
        if (request.Medicaments.Count > 10)
                throw new ArgumentException("Prescription cannot contain more than 10 medications.");
        if (request.DueDate < request.Date)
                throw new ArgumentException("Due date cannot be earlier than date.");

        var doctor = await _context.Doctors.FindAsync(request.DoctorId);
        if (doctor == null)
            throw new ArgumentException("Doctor does not exist.");

        var patient = _context.Patients.FirstOrDefault(p => p.FirstName == request.Patient.FirstName
                                                            && p.LastName == request.Patient.LastName
                                                            && p.DateOfBirth == request.Patient.DateOfBirth);
        
        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                DateOfBirth = request.Patient.DateOfBirth
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }
        
        var existingPrescription = await _context.Prescriptions.Include(p => p.PrescriptionMedicaments)
            .FirstOrDefaultAsync(p => 
                p.PatientId == patient.PatientId &&
                p.DoctorId == doctor.DoctorId && 
                p.Date == request.Date && 
                p.DueDate == request.DueDate);
        
        if (existingPrescription != null)
            throw new ArgumentException("Prescription already exists.");
        
        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            DoctorId = doctor.DoctorId,
            PatientId = patient.PatientId,
            PrescriptionMedicaments = new List<PrescriptionMedicament>()
        };

        foreach (var medic in request.Medicaments)
        {
            var medicament = await _context.Medicaments.FindAsync(medic.MedicamentId);
            if (medicament == null)
                throw new ArgumentException($"Medicament {medic.MedicamentId} does not exist.");
            
            prescription.PrescriptionMedicaments.Add(new PrescriptionMedicament
            {
                PrescriptionId = prescription.PrescriptionId,
                MedicamentId = medic.MedicamentId,
                Dose = medic.Dose,
                Details = medic.Description
            });
        }
        
        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task<PatientDataResponse?> GetPatientDetailsAsync(int patientId)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.PrescriptionMedicaments)
                    .ThenInclude(pm => pm.Medicament)
            .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.Doctor)
            .FirstOrDefaultAsync(p => p.PatientId == patientId);

        if (patient == null) return null;

        return new PatientDataResponse
        {
            Patient = new PatientDto
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth
            },
            Prescriptions = patient.Prescriptions
                .OrderBy(p => p.DueDate)
                .Select(p => new PrescriptionDto
                    {
                        PrescriptionId = p.PrescriptionId,
                        Date = p.Date,
                        DueDate = p.DueDate,
                        Doctor = new DoctorDto()
                        {
                            DoctorId = p.Doctor.DoctorId,
                            FirstName = p.Doctor.FirstName,
                            LastName = p.Doctor.LastName
                        },
                        Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentDto
                        {
                            MedicamentId = pm.MedicamentId,
                            Dose = pm.Dose,
                            Description = pm.Medicament.Description
                        }).ToList()
                    }
                ).ToList()
        };
    }
}