using System.ComponentModel.DataAnnotations;

namespace TechWorld.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
