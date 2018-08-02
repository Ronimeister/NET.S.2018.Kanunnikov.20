using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIResolver;
using ParserLib;
using Logger;
using Repository;
using Serializer;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardKernel kernel = new StandardKernel(new ConfigModule());
            IParser<Uri> parser = new ParserLib.UriParser(kernel.Get<ILogger>());
            IEnumerable<Uri> uris = parser.ParseFromRepository(kernel.Get<IRepository>());
            kernel.Get<ISerializer<Uri>>().Serialize(uris);
        }
    }
}
