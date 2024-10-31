using Prism.Ioc;
using Prism.Modularity;
using PrismInspectionAppTemplate.Core.Service.Dispose;

namespace PrismInspectionAppTemplate.Modules
{
    public class DisposeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _ = containerRegistry.RegisterSingleton<IDisposeManager, DisposeManager>();
        }
    }
}
