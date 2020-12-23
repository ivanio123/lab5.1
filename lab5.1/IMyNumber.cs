using System;
using System.Collections.Generic;
using System.Text;

namespace lab5._1
{
    interface IMyNumber<T> where T : IMyNumber<T>//параметризований інтерфейс  
    {
        T Add(T b);
        T Subtract(T b);
        T Multiply(T b);
        T Divide(T b);
    }
}
