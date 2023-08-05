namespace Diploma.DTO.Item
{
    public class ItemDetailsForStatistics
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int SoldQuantity { get; set; }
    }
}
