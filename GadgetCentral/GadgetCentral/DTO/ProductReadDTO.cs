namespace GadgetCentral.DTO
{
    public class ProductReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public int DeliverTime { get; set; }
    }

}
