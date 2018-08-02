using Repository;
using System.Collections.Generic;

namespace ParserLib
{
    public interface IParser <T>
    {
        T Parse(string sourcePath);
        IEnumerable<T> ParseFromRepository(IRepository repository);
    }
}
