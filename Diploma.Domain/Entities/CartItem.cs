using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain.Entities
{
    public class CartItem
    {
        public int ItemId { get; set; }
        public int ItemTypeId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
