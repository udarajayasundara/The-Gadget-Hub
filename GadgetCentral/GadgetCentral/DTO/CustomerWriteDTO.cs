using System.ComponentModel.DataAnnotations;

namespace GadgetCentral.DTO
{
    public class CustomerWriteDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }
    }

}
