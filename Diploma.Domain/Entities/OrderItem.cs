namespace Diploma.Domain.Entities
{
    public class OrderItem
    {
        public Item Item { get; set; } = new Item();
        public int ItemId { get; set; }
        public Order Order { get; set; } = new Order();
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
