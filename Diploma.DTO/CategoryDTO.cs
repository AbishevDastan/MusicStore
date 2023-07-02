using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;
        public bool IsRemoved { get; set; } = false;
        [NotMapped]
        public bool IsBeingEdited { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
