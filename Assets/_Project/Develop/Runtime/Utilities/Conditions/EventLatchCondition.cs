using System;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Utilities.Conditions
{
    public class EventLatchCondition<T> : ICondition, IDisposable
    {
        private bool _wasTriggered;
        private readonly IDisposable _subscription;

        public EventLatchCondition(ReactiveEvent<T> source)
        {
            _subscription = source.Subscribe(_ => _wasTriggered = true);
        }

        public bool Evaluate()
        {
            if (_wasTriggered == false)
                return false;

            _wasTriggered = false;
            return true;
        }

        public void Dispose() => _subscription.Dispose();
    }
}