using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismInspectionAppTemplate.Modules;
using PrismInspectionAppTemplate.Settings;
using PrismInspectionAppTemplate.ViewModels;
using PrismInspectionAppTemplate.Views;

namespace PrismInspectionAppTemplate
{
    public class Starter
    {
        [STAThread]
        public static void Main()
        {
            _ = new App()
                .WireViewViewModuel<WireDataContext>()
                .AddInversionModule<BootstrapModule>()
                .AddInversionModule<DisposeModule>()
                .AddInversionModule<RepositoryModule>()
                .ActivateStartupWindow<StartupWindow, StartupViewModel>()
                .Run();
        }
    }
}
