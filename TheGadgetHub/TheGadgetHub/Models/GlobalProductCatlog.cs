using System.ComponentModel.DataAnnotations;

namespace TheGadgetHub.Models
{
    public class GlobalProductCatlog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TechWorldProductId { get; set; }

        [Required]
        public int GadgetCentralProductId { get; set; }

        [Required]
        public int ElectroComProductId { get; set; }
    }
}
