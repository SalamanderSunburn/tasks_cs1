﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Taisiya
{
    interface IPriorityQueue<T>
    {
        void Enqueue(T val, int priority);
        T Dequeue();
        T First();
        T First(int priority);
        T Last();
        T Last(int priority);
        int Count { get; }
        int GetCount(int priority);
    }
}
