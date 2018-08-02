using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    public interface ISerializer <T>
    {
        void Serialize(IEnumerable<T> collection);
    }
}
