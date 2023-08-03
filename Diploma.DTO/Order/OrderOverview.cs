namespace Diploma.DTO.Order
{
    public class OrderOverview
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Item { get; set; }
        public OrderStatus Status { get; set; }
    }
}
