using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Medifine.Models
{
    public class owner
    {
        [Key] public int Id { get; set; }
        //[ForeignKey] public int PID { get; set; }
        [Required][StringLength(100)][DisplayName("Owner's Name")] public string Name { get; set; }
        [Required][StringLength(20)][DisplayName("Phone Number")] public string PhoneNo { get; set; }
        [Required][EmailAddress] public string Email { get; set; }
        [Required][StringLength(150)] public string Address { get; set; }
        [Required][StringLength(12)] public string NIC { get; set; }
    }
}