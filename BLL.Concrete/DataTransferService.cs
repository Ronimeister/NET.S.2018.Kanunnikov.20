using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;

namespace BLL.Concrete
{
    public class DataTransferService <TSource, TResult> : IDataService
    {
        private readonly IDataProvider<TSource> _provider;
        private readonly IStorage<TResult> _storage;
        private readonly IParser<TResult, TSource> _parser;
        private readonly ILogger _logger = new NLogLogger();

        public DataTransferService(IDataProvider<TSource> provider, IStorage<TResult> storage, IParser<TResult, TSource> parser)
        {
            _provider = provider ?? throw new ArgumentNullException($"{nameof(provider)} can't be equal to null!");
            _storage = storage ?? throw new ArgumentNullException($"{nameof(storage)} can't be equal to null!");
            _parser = parser ?? throw new ArgumentNullException($"{nameof(parser)} can't be equal to null!");
        }

        public void Transfer()
        {
            IEnumerable<TSource> providerData = _provider.GetData();
            List<TResult> storageData = new List<TResult>();

            foreach (var i in providerData)
            {
                try
                {
                    storageData.Add(_parser.Parse(i));
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message);
                }
            }

            _storage.Save(storageData);
        }
    }
}
