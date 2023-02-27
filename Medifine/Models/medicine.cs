using System.ComponentModel.DataAnnotations;

namespace Medifine.Models
{
    public class medicine
    {
        [Key] public int Id { get; set; }
        [Required]public string Name { get; set; }

    }
}
