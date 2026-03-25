using System;

namespace _Project.Develop.Runtime.Utilities.Reactive
{
    public interface IReadOnlyReactiveValue<T>
    {
        T Value { get; }
        
        IDisposable Subscribe(Action<T, T> action);
    }
}