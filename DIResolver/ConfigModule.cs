using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using Ninject;
using Repository;
using Serializer;

namespace DIResolver
{
    public class ConfigModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<FileLogger>().WithConstructorArgument("Parser");
            Bind<IRepository>().To<FileRepository>().WithConstructorArgument(@"C:\Users\Алексей\source\repos\NET.S.2018.Kanunnikov.20\ConsoleUI\bin\Debug\input.txt");
            Bind<ISerializer<Uri>>().To<UriSerializer>().WithConstructorArgument(@"C:\Users\Алексей\source\repos\NET.S.2018.Kanunnikov.20\ConsoleUI\bin\Debug\output.xml");
        }
    }
}
