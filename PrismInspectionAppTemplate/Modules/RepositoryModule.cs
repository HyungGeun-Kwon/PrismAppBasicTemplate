using Prism.Ioc;
using Prism.Modularity;
using PrismInspectionAppTemplate.Bootstrapper;
using PrismInspectionAppTemplate.Core.Names;
using PrismInspectionAppTemplate.Core.Service.Bootstrap;
using PrismInspectionAppTemplate.Core.Service.Setting;

namespace PrismInspectionAppTemplate.Modules
{
    public class RepositoryModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            bool isBootRegisterd = containerProvider.IsRegistered<IBootstrapManager>();
            if (isBootRegisterd)
            {
                var bootstrapManager = containerProvider.Resolve<IBootstrapManager>();
                bootstrapManager.AddBootstrap(BootstrapName.SETTING, containerProvider.Resolve<SettingBootstrapper>());
            }
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _ = containerRegistry.RegisterSingleton<ISettingRepository, SettingRepository>();
            _ = containerRegistry.RegisterSingleton<IBootstrapper, SettingBootstrapper>();
        }
    }
}
