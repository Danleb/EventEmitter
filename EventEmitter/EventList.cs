using System;
using System.Collections.Generic;

namespace EventEmitting
{
    public class EventList<T> : List<Action<T>> { }
}