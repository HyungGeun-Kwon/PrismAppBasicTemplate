using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using PrismInspectionAppTemplate.ControlBar.Views;
using PrismInspectionAppTemplate.Core.Names;
using PrismInspectionAppTemplate.Home.Views;
using PrismInspectionAppTemplate.Setting.Views;

namespace PrismInspectionAppTemplate.Modules
{
    public class ViewModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // INFO : Region영역에 사용할 UserControl View 선언

            containerRegistry.RegisterForNavigation<ControlBarView>(ViewNames.CONTROLBAR);
            containerRegistry.RegisterForNavigation<HomeView>(ViewNames.HOME);
            containerRegistry.RegisterForNavigation<SettingView>(ViewNames.SETTING);
        }
    }
}
