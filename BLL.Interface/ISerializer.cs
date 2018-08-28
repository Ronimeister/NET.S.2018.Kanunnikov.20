using System.Collections.Generic;

namespace BLL.Interface
{
    public interface ISerializer<T>
    {
        void Persist(IEnumerable<T> collection);
    }
}
