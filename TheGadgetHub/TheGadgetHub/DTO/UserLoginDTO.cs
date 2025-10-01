using System.ComponentModel.DataAnnotations;

namespace TheGadgetHub.DTO
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string HashedPassword { get; set; }
    }
}
