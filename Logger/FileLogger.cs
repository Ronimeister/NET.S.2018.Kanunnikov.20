using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class FileLogger : ILogger
    {
        public void Fatal(string message)
        {
            Console.WriteLine("Fatal: " + message);
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            Console.WriteLine("Warn: " + message);
        }
    }
}
