using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using PrismInspectionAppTemplate.Core.Events;
using PrismInspectionAppTemplate.Core.Service.Setting;
using PrismInspectionAppTemplate.Core.Setting;

namespace PrismInspectionAppTemplate.Setting.ViewModels
{
    public class SettingViewModel : BindableBase, INavigationAware
    {
        private const string SAVE_CHECK_MESSAGE = "Would you like to save the settings?";

        private ISettingRepository _settingRepo;
        public ISettingRepository SettingRepo { get => _settingRepo; set => SetProperty(ref _settingRepo, value); }
        public SettingViewModel(IContainerProvider containerProvider)
        {
            SettingRepo = containerProvider.Resolve<ISettingRepository>();

            IEventAggregator ea = containerProvider.Resolve<IEventAggregator>();

            _ = ea.GetEvent<MainWindowClosingEvent>().Subscribe(() => SaveCheck());
        }

        private void SaveCheck()
        {
            if (MessageBox.Show(SAVE_CHECK_MESSAGE, "", MessageBoxButton.YesNo) == MessageBoxResult.Yes) { _settingRepo.Save<AppSetting>(); }
            else { _settingRepo.Load<AppSetting>(); }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        public void OnNavigatedTo(NavigationContext navigationContext) { }
        public void OnNavigatedFrom(NavigationContext navigationContext) => SaveCheck();
    }
}
