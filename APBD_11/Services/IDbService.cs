using APBD_11.DTOs;

namespace APBD_11.Services;

public interface IDbService
{
    Task AddPrescriptionAsync(AddPrescriptionRequest request);
    Task<PatientDataResponse?> GetPatientDetailsAsync(int patientId);
}