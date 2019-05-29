using System;
using System.Collections.Generic;

namespace EventEmitting
{
    public class EventListDictionary
    {
        protected Dictionary<Type, object> CallbacksDictionary = new Dictionary<Type, object>();

        public bool TryGetList<T>(out EventList<T> eventsList)
        {
            var eventType = typeof(T);

            if (CallbacksDictionary.TryGetValue(eventType, out var obj))
            {
                eventsList = (EventList<T>)obj;
                return true;
            }

            eventsList = null;
            return false;
        }

        public EventList<T> GetList<T>()
        {
            var eventType = typeof(T);

            if (CallbacksDictionary.TryGetValue(eventType, out var obj))
                return (EventList<T>)obj;

            var list = new EventList<T>();
            CallbacksDictionary.Add(eventType, list);
            return list;
        }
    }
}