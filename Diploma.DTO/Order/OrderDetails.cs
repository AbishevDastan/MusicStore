namespace Diploma.DTO.Order
{
    public class OrderDetails
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ItemDetailsInOrder> Items { get; set; } = new List<ItemDetailsInOrder>();
    }
}
