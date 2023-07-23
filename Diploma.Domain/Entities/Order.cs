namespace Diploma.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public DateTime PlacedAt { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
