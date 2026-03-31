using System.Collections.Generic;
using System.Linq;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.DataManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Features
{
    public class OutcomesCounterService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly Dictionary<OutcomesType, int> _counter;
        private readonly DIContainer _container;

        public OutcomesCounterService(Dictionary<OutcomesType, int> counter, PlayerDataProvider playerDataProvider, DIContainer container)
        {
           _container = container;
            _counter = new(counter);
            
            playerDataProvider.RegisterReader(this);
            playerDataProvider.RegisterWriter(this);
        }
        
        public IReadOnlyList<OutcomesType> AvailableOutcomes => _counter.Keys.ToList();
        
        public int GetCount(OutcomesType type) => _counter[type];

        public void AddWinner() 
            => AddOutcome(OutcomesType.Win);
        
        public void AddDefeated() 
            => AddOutcome(OutcomesType.Defeat);

        private void AddOutcome(OutcomesType type)
        {
            _counter[type]++;
            _container.Resolve<ICoroutinesPerformer>().StartPerform(_container.Resolve<PlayerDataProvider>().Save());
        }

        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<OutcomesType, int> count in data.Counter)
            {
                if (_counter.ContainsKey(count.Key))
                    _counter[count.Key] = count.Value;
                else
                    _counter.Add(count.Key, count.Value);
            }
        }

        public void WriteTo(PlayerData data)
        {
            foreach (KeyValuePair<OutcomesType, int> count in _counter)
            {
                if (data.Counter.ContainsKey(count.Key))
                    data.Counter[count.Key] = count.Value;
                else
                    data.Counter.Add(count.Key, count.Value);
            }
        }
    }
}
