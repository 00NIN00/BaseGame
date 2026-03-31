using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.DataManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;

namespace _Project.Develop.Runtime.Configs.Meta
{
    public class ResetProgressService
    {
        private readonly DIContainer _container;

        public ResetProgressService(DIContainer container)
        {
            _container = container;
        }

        public void ResetPlayerData()
        {
            PlayerDataProvider playerDataProvider = _container.Resolve<PlayerDataProvider>(); 
            
            Reset(playerDataProvider);
        }
        
        private void Reset<TData>(DataProvider<TData> dataProvider) where TData : ISaveData
        {
            dataProvider.Reset();
        }
    }
}