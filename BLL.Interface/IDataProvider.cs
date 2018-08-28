using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IDataProvider<out T>
    {
        IEnumerable<T> GetData();
    }
}
