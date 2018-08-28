using BLL.Concrete;
using System;
using System.IO;

namespace PL.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Stream stream = File.OpenRead(@"C:\Users\Алексей\Desktop\NET.S.2018.Kanunnikov.20\PL.Console\bin\Debug\input.txt"))
            {
                string xmlFile = @"C:\Users\Алексей\Desktop\NET.S.2018.Kanunnikov.20\PL.Console\bin\Debug\output.xml";

                var service = new DataTransferService<string, Uri>(new DataProvider(stream), new XMLStorage(xmlFile), new BLL.Concrete.UriParser(new UriValidator()));

                service.Transfer();
            }
        }
    }
}
