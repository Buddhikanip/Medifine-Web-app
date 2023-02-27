using System.ComponentModel.DataAnnotations;

namespace Medifine.Models
{
    public class pharmacy
    {
        [Key] public int PharmacyId { get; set; }
        [Required] public string PharmacyName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Phone_Number { get; set; }
        [Required] public string Pharmacy_License_Number { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Confirm_Password { get; set; }
    }
}
