namespace Diploma.Domain.Entities
{
    public class OrderItem
    {
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
