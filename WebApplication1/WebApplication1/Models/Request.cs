using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime DT { get; set; }
        public string MiddlewareActivation { get; set; }
        public string Value { get; set; }
    }
}
