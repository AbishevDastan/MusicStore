﻿namespace Diploma.DTO
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        /*public CategoryDTO? Category { get; set; }*/ // CategoryModel
        //public string CategoryUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
