using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.DTO
{
    public class ItemVariantDTO
    {
        //public ItemDTO Item { get; set; }
        public int ItemId { get; set; }
        public ItemTypeDTO ItemType { get; set; }
        public int ItemTypeId { get; set; }
        public decimal Price { get; set; }
        public decimal InitialPrice { get; set; }
    }
}
