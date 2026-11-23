using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCsharp01
{
    public interface IRepository<T>
    {
        void Adds(T item);
        T Get();
    }
}
