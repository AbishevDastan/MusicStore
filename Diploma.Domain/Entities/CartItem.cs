using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain.Entities
{
    public class CartItem
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
