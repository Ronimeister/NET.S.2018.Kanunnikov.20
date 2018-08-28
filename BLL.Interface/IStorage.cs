using System.Collections.Generic;

namespace BLL.Interface
{
    /// <summary>
    /// Interface for all storage types
    /// </summary>
    /// <typeparam name="T">Type of storage elements</typeparam>
    public interface IStorage<T>
    {
        /// <summary>
        /// Save changes in storage
        /// </summary>
        /// <param name="values">Changed elements</param>
        void Save(IEnumerable<T> values);
    }
}
