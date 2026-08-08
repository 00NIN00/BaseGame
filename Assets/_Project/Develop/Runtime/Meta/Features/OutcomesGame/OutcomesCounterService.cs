using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.DataManagement;
using System.Collections.Generic;
using System.Linq;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Meta.Features.OutcomesGame
{
    public class OutcomesCounterService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly Dictionary<OutcomesType, ReactiveVariable<int>> _counter;

        public OutcomesCounterService(
            Dictionary<OutcomesType, ReactiveVariable<int>> counter,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _counter = new(counter);
            
            _playerDataProvider.RegisterReader(this);
            _playerDataProvider.RegisterWriter(this);
        }
        
        public IReadOnlyList<OutcomesType> AvailableOutcomes => _counter.Keys.ToList();
        
        public IReadOnlyReactiveValue<int> GetOutcomes(OutcomesType type) => _counter[type];

        public void AddOutcome(OutcomesType type)
        {
            _counter[type].Value++;
            Save();
        }

        public void Reset()
        {
            foreach (var key in _counter.Keys.ToList())
                _counter[key].Value = 0;

            Save();
        }

        private void Save()
            => _coroutinesPerformer.StartPerform(_playerDataProvider.Save());

        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<OutcomesType, int> count in data.Counter)
            {
                if (_counter.ContainsKey(count.Key))
                    _counter[count.Key].Value = count.Value;
                else
                    _counter.Add(count.Key, new ReactiveVariable<int>(count.Value));
            }
        }

        public void WriteTo(PlayerData data)
        {
            foreach (KeyValuePair<OutcomesType, ReactiveVariable<int>> count in _counter)
            {
                if (data.Counter.ContainsKey(count.Key))
                    data.Counter[count.Key] = count.Value.Value;
                else
                    data.Counter.Add(count.Key, count.Value.Value);
            }
        }
    }
}
