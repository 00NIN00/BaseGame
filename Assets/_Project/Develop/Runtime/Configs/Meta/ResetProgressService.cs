using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.DataManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;

namespace _Project.Develop.Runtime.Configs.Meta
{
    public class ResetProgressService
    {
        private readonly PlayerDataProvider _playerDataProvider;

        public ResetProgressService(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;
        }

        public void ResetPlayerData()
        {
            Reset(_playerDataProvider);
        }
        
        private void Reset<TData>(DataProvider<TData> dataProvider) where TData : ISaveData
        {
            dataProvider.Reset();
        }
    }
}