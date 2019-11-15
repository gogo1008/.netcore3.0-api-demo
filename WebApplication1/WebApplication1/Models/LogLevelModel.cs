using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class LogLevelModel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }

        //     "LogLevel": {
        //  "Default": "Debug",
        //  "System": "Information",
        //  "Microsoft": "Information"
        //}
    }
}
