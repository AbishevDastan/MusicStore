using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
