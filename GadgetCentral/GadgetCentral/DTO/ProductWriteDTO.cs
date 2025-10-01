using System.ComponentModel.DataAnnotations;

namespace GadgetCentral.DTO
{
    public class ProductWriteDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.00, 9999999.99, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Range(0, 10000000, ErrorMessage = "Stock quantity must be between 0 and 10,000,000.")]
        public int Stock { get; set; }

        public string? Description { get; set; }

        [Range(1, 365, ErrorMessage = "Deliver time must be at least 1 day.")]
        public int DeliverTime { get; set; }
    }

}
