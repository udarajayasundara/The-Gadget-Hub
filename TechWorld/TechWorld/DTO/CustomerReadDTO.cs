using System.ComponentModel.DataAnnotations;

namespace TechWorld.DTO
{
    public class CustomerReadDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

}
