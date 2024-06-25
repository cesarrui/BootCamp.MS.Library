using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Domain.Models
{
    public class Result<T>
    {
        public string Message { get; set; } = "Request succes";
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}
