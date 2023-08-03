namespace Diploma.DTO.Order
{
    public class ItemDetailsInOrder
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
