using System;
using System.Collections.Generic;
using BLL.Interface;

namespace BLL.Concrete
{
    /// <summary>
    /// Class than implements data transfer service functionality
    /// </summary>
    /// <typeparam name="TSource">Input values type</typeparam>
    /// <typeparam name="TResult">Output values type</typeparam>
    public class DataTransferService <TSource, TResult> : IDataService
    {
        #region Readonly fields
        private readonly IDataProvider<TSource> _provider;
        private readonly IStorage<TResult> _storage;
        private readonly IParser<TResult, TSource> _parser;
        private readonly ILogger _logger = new NLogLogger();
        #endregion

        #region .ctors
        /// <summary>
        /// .ctor for <see cref="DataTransferService{TSource,TResult}"/> class
        /// </summary>
        /// <param name="provider">Data provider></param>
        /// <param name="storage">Storage</param>
        /// <param name="parser">Parser</param>
        /// <exception cref="ArgumentNullException">Throws when:
        /// 1) <param name="provider"></param> is equal to null
        /// 2) <param name="storage"></param> is equal to null
        /// 3) <param name="parser"></param> is equal to null
        /// </exception>
        public DataTransferService(IDataProvider<TSource> provider, IStorage<TResult> storage, IParser<TResult, TSource> parser)
        {
            _provider = provider ?? throw new ArgumentNullException($"{nameof(provider)} can't be equal to null!");
            _storage = storage ?? throw new ArgumentNullException($"{nameof(storage)} can't be equal to null!");
            _parser = parser ?? throw new ArgumentNullException($"{nameof(parser)} can't be equal to null!");
        }
        #endregion

        #region Public API
        /// <summary>
        /// Transfer data of one storage to another with some changes
        /// </summary>
        /// <exception cref="Exception">Parser exception</exception>
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
        #endregion
    }
}
