using System;
using System.Collections.Generic;
using System.IO;
using BLL.Interface;

namespace BLL.Concrete
{
    public class DataProvider : IDataProvider<string>
    {
        private readonly Stream _stream;

        public DataProvider(Stream stream)
        {
            _stream = stream ?? throw new ArgumentNullException($"{nameof(stream)} can't be equal to null!");
        }
        
        public IEnumerable<string> GetData()
        {
            List<string> result = new List<string>();

            using (StreamReader sr = new StreamReader(_stream))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}
