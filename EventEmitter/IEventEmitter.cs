using System;

namespace EventEmitting
{
    public interface IEventEmitter
    {
        void Emit<T>(T value);
        void Subscribe<T>(Action<T> callback);
        void Unsubscribe<T>(Action<T> callback);
    }
}