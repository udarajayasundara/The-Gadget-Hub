using System.ComponentModel.DataAnnotations;

namespace TechWorld.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.00, 9999999.99, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Range(0, 10000000, ErrorMessage = "Stock quantity must be between 0 and 10,000,000.")]
        public int Stock { get; set; }

        public string? Description { get; set; }

        [Required]
        public int DeliverTime { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
