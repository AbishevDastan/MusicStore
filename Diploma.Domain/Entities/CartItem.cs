 namespace Diploma.Domain.Entities
{
    public class CartItem
    {
        public int? UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
