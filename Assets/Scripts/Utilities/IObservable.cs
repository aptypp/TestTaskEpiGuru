using System;

namespace Utilities
{
    public interface IObservable<out T>
    {
        event Action<T> Changed;

        T Value { get; }
    }
}