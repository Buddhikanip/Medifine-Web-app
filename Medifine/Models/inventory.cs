using System.ComponentModel.DataAnnotations;

namespace Medifine.Models
{
    public class inventory
    {
        [Key] public int Id { get; set; }
        [Required] public int PID { get; set; }
        [Required][StringLength(100)] public string DrugName { get; set; }
        [Required][StringLength(100)] public string Manufacturer { get; set; }
        [Required][StringLength(100)] public string Supplier { get; set; }
        [Required][StringLength(11)] public string NDC { get; set; }
        [Required] public DateTime ExpirationDate { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public decimal UnitPrice { get; set; }
    }
}