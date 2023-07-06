using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Category? Category { get; set; } 
        public int CategoryId { get; set; }
        public bool Featured { get; set; } = false;
        public decimal Price { get; set; }
        //public bool IsVisible { get; set; } = true;
        //public bool IsRemoved { get; set; } = false;
        //[NotMapped]
        //public bool IsBeingEdited { get; set; } = false;
        //[NotMapped]
        //public bool IsNew { get; set; } = false;
    }
}
