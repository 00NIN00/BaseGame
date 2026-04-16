using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.DataManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;

namespace _Project.Develop.Runtime.Configs.Meta
{
    public class ResetProgressService
    {
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public ResetProgressService(PlayerDataProvider playerDataProvider, ICoroutinesPerformer coroutinesPerformer)
        {
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void ResetPlayerData()
        {
            Reset(_playerDataProvider);
        }
        
        private void Reset<TData>(DataProvider<TData> dataProvider) where TData : ISaveData
        {
            dataProvider.Reset();
            _coroutinesPerformer.StartPerform(dataProvider.Save());
        }
    }
}