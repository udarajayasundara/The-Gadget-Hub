using System.ComponentModel.DataAnnotations;

namespace TheGadgetHub.DTO
{
    public class UserWriteDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Optional for login, required for registration

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string HashedPassword { get; set; }  // Plain text (hash it before saving)
    }
}
