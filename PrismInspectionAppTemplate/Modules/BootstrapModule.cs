using Prism.Ioc;
using Prism.Modularity;
using PrismInspectionAppTemplate.Core.Service.Bootstrap;

namespace PrismInspectionAppTemplate.Modules
{
    public class BootstrapModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _ = containerRegistry.RegisterSingleton<IBootstrapManager, BootstrapManager>();
        }
    }
}
