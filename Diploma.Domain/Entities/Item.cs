using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category? Category { get; set; } // CategoryModel
        public int CategoryId { get; set; }
        public List<ItemVariant> Variants { get; set; } = new List<ItemVariant>();
        public bool Featured { get; set; } = false;
    }
}
