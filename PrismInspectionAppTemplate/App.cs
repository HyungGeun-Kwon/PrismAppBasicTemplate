using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CvsService.Prism.Services;
using Prism.Ioc;
using PrismInspectionAppTemplate.Views;

namespace PrismInspectionAppTemplate
{
    public class App : PrismApplicationHelper
    {
        protected override Window CreateShell()
        {
            RunStartup();
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) { }
    }
}
