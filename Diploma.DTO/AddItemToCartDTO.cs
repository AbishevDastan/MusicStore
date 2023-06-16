using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.DTO
{
    public class AddItemToCartDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; } 
        public string Image { get; set; } 
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
