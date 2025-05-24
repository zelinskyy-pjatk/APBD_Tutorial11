using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_11.Models;

[Table("Patient")]
public class Patient
{
    [Key]
    public int PatientId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
}