namespace APBD_11.DTOs;

public class PatientDataResponse
{
    public PatientDto Patient { get; set; }
    public List<PrescriptionDto> Prescriptions { get; set; }
}
