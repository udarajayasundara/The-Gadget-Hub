using System.ComponentModel.DataAnnotations;

namespace TheGadgetHub_Web.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string HashedPassword { get; set; }
    }
}
