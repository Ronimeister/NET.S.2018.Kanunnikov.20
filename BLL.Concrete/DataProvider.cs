using System;
using System.Collections.Generic;
using System.IO;
using BLL.Interface;

namespace BLL.Concrete
{
    /// <summary>
    /// Class that implements data provider functionality
    /// </summary>
    public class DataProvider : IDataProvider<string>
    {
        #region Readonly fields
        private readonly Stream _stream;
        #endregion

        #region .ctors
        /// <summary>
        /// .ctor for <see cref="DataProvider"/> class
        /// </summary>
        /// <param name="stream">Input stream for data provider file</param>
        /// <exception cref="ArgumentNullException">Throws when <param name="stream"></param> is equal to null</exception>
        public DataProvider(Stream stream)
        {
            _stream = stream ?? throw new ArgumentNullException($"{nameof(stream)} can't be equal to null!");
        }
        #endregion

        #region Public API
        /// <summary>
        /// Gets whole data from the storage
        /// </summary>
        /// <returns>Collection of data</returns>
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
        #endregion
    }
}
