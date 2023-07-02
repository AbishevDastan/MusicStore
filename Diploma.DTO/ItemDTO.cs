using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.DTO
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        /*public CategoryDTO? Category { get; set; }*/ // CategoryModel
        public string CategoryUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool Featured { get; set; } = false;
        public decimal Price { get; set; }
    }
}
