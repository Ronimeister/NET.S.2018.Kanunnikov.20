using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IStorage<T>
    {
        void Save(IEnumerable<T> values);
    }
}
