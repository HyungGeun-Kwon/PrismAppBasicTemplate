using Prism.Ioc;
using PrismInspectionAppTemplate.Core.Service.Bootstrap;
using PrismInspectionAppTemplate.Core.Service.Setting;
using PrismInspectionAppTemplate.Core.Setting;

namespace PrismInspectionAppTemplate.Bootstrapper
{
    public class SettingBootstrapper : IBootstrapper
    {
        private readonly IContainerProvider _container;
        public BootstrapperInfo BootstrapperInfo { get; }

        public SettingBootstrapper(IContainerProvider container)
        {
            _container = container;
             BootstrapperInfo = new BootstrapperInfo("Setting");
        }
        public void Initialize()
        {
            var settingRepo = _container.Resolve<ISettingRepository>();
            settingRepo.Load<AppSetting>();
            settingRepo.Save<AppSetting>(); // 맨 처음 생성하는 경우 대비
        }
    }
}
