namespace Diploma.DTO.Orders
{
    public class OrderDetails
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ItemDetailsInOrder> Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}
