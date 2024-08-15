using System;

namespace Utilities
{
    public class Observable<T> : IObservable<T>
    {
        public event Action<T> Changed;

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                Changed?.Invoke(_value);
            }
        }

        public Observable()
        {
        }

        public Observable(
            T value)
        {
            _value = value;
        }
    }
}