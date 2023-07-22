namespace Diploma.DTO
{
    public class AddItemToCartDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
