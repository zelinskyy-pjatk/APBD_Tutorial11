namespace APBD_11.DTOs;

public class AddPrescriptionRequest
{
    public PatientDto Patient { get; set; }
    public int DoctorId { get; set; }
    public List<MedicamentPrescriptionDto> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}

public class MedicamentPrescriptionDto
{
    public int MedicamentId { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
}