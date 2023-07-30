namespace Diploma.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        //public int OrderStatusId { get; set; }
        //public OrderStatus OrderStatus { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
