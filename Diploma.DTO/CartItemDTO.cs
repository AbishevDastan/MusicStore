namespace Diploma.DTO
{
    public class CartItemDto
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
