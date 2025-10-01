namespace GadgetCentral.DTO
{
    public class OrderReadDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } // safer
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
