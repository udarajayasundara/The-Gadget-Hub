using System.ComponentModel.DataAnnotations;

namespace TheGadgetHub_Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
