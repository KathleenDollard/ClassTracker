using System.Collections.Generic;

namespace CSharp7Demo
{
    public interface ISeedData<T>
        where T:class
    {
        IDictionary<int, T> GetData();
    }
}
