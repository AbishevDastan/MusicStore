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
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Category? Category { get; set; } 
        public int CategoryId { get; set; }
        public bool Featured { get; set; } = false;
        public decimal Price { get; set; }
    }
}
