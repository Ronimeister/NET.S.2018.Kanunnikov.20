using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FileRepository : IRepository
    {
        private readonly string _filepath;

        public FileRepository(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"{nameof(filePath)} can't be equal to null or epmty!");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File {filePath} doesn't found!");
            }

            _filepath = filePath;
        }

        public IEnumerable<string> GetAll()
            => File.ReadLines(_filepath);
    }
}