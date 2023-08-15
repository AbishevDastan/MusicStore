namespace Diploma.DTO.Wishlist
{
    public class AddItemToWishlistDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
