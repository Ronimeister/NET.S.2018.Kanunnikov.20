using Logger;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLib
{
    public class UriParser : IParser<Uri>
    {
        private readonly ILogger _logger;

        public UriParser(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} can't be equal to null!");
        }

        public Uri Parse(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath))
            {
                string exceptionMessage = $"{nameof(sourcePath)} can't be equal to null or empty!";
                _logger.Fatal(exceptionMessage);

                throw new ArgumentException(exceptionMessage);
            }

            return ParseUri(sourcePath);
        }

        public IEnumerable<Uri> ParseFromRepository(IRepository repository)
        {
            if (repository == null)
            {
                string exceptionMessage = $"{nameof(repository)} can't be equal to null!";
                _logger.Fatal(exceptionMessage);

                throw new ArgumentNullException(exceptionMessage);
            }

            return ParseRepositoryInner(repository);
        }

        private Uri ParseUri(string source)
        {
            try
            {
                return new Uri(source);
            }
            catch(UriFormatException)
            {
                //add logger
                return null;
            }
        }

        private IEnumerable<Uri> ParseRepositoryInner(IRepository repository)
        {
            IEnumerable<string> uris = repository.GetAll();
            foreach (string s in uris)
            {
                Uri uri = Parse(s);
                if (uri != null)
                {
                    yield return uri;
                }
            }
        }
    }
}
