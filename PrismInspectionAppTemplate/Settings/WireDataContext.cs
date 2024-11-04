using CvsService.Prism.Interfaces;
using Prism.Mvvm;
using PrismInspectionAppTemplate.ControlBar.ViewModels;
using PrismInspectionAppTemplate.ControlBar.Views;
using PrismInspectionAppTemplate.Home.ViewModels;
using PrismInspectionAppTemplate.Home.Views;
using PrismInspectionAppTemplate.Setting.ViewModels;
using PrismInspectionAppTemplate.Setting.Views;
using PrismInspectionAppTemplate.ViewModels;
using PrismInspectionAppTemplate.Views;

namespace PrismInspectionAppTemplate.Settings
{
    public class WireDataContext : IViewViewModelWire
    {
        public void WireVVM()
        {
            // INFO : View  - ViewModel 연결
            ViewModelLocationProvider.Register<MainWindow, MainViewModel>();
            ViewModelLocationProvider.Register<SplashWindow, SplashViewModel>();
            ViewModelLocationProvider.Register<ControlBarView, ControlBarViewModel>();
            ViewModelLocationProvider.Register<HomeView, HomeViewModel>();
            ViewModelLocationProvider.Register<SettingView, SettingViewModel>();
        }
    }
}
