using System.ComponentModel.DataAnnotations;

namespace TheGadgetHub.DTO
{
    public class OrderWriteDTO
    {
        [Required]
        public DateTime Date { get; set; }

        public decimal Discount { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        public List<int> ProductIds { get; set; } = new();
    }
}
