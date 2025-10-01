using System.ComponentModel.DataAnnotations;

namespace TheGadgetHub.DTO
{
    public class GlobalProductCatlogReadDTO
    {
        public int Id { get; set; }

        public int TechWorldProductId { get; set; }

        public int GadgetCentralProductId { get; set; }

        public int ElectroComProductId { get; set; }
    }
}
