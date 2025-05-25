namespace APBD_11.DTOs;

public class PrescriptionDto
{
    public int PrescriptionId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public DoctorDto Doctor { get; set; }
    public List<MedicamentDto> Medicaments { get; set; }
}

public class MedicamentDto
{
    public int MedicamentId { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}

public class DoctorDto
{
    public int DoctorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}