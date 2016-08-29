using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogManager
{
    public class LogEntry
    {

        public DateTime entryTime { get; set; }

        public string logMessage { get; set; }


        public string hostPCName { get; set; }

        public string hostIP { get; set; }

    }
}
