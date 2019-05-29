using System;

namespace EventEmitting
{
    public class EventEmitter : IEventEmitter
    {
        protected readonly EventListDictionary EventListDictionary = new EventListDictionary();

        public void Emit<T>(T value)
        {
            if (EventListDictionary.TryGetList<T>(out var eventList))
                foreach (var callBack in eventList)
                    callBack.Invoke(value);
        }

        public void Subscribe<T>(Action<T> callback)
        {
            var eventList = EventListDictionary.GetList<T>();
            eventList.Add(callback);
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            var eventList = EventListDictionary.GetList<T>();
            eventList.Remove(callback);
        }
    }
}