using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain
{
    public class ResponseFromServer<T>
    {
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
    }
}
