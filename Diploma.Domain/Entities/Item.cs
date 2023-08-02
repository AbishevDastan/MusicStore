using Diploma.DTO;

namespace Diploma.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public ItemStockStatus StockStatus { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
