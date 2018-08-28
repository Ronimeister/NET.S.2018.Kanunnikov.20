using System.Collections.Generic;

namespace BLL.Interface
{
    /// <summary>
    /// Interface for all data providers types
    /// </summary>
    /// <typeparam name="T">Output type</typeparam>
    public interface IDataProvider<out T>
    {
        /// <summary>
        /// Gets whole data from the storage
        /// </summary>
        /// <returns>Collection of data</returns>
        IEnumerable<T> GetData();
    }
}
