using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismInspectionAppTemplate.Core.Events;
using PrismInspectionAppTemplate.Core.Names;
using PrismInspectionAppTemplate.Core.Service.Dispose;

namespace PrismInspectionAppTemplate.ViewModels
{
    public class MainViewModel : BindableBase
    {

        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDisposeManager _disposeManager;

        public ICommand LoadedCommand => new DelegateCommand(OnLoaded);
        public ICommand ClosingCommand => new DelegateCommand<CancelEventArgs>(OnClosing);
        public ICommand ClosedCommand => new DelegateCommand(OnClosed);

        private void OnLoaded()
        {
            SetDefaultRegion();
        }
        private void SetDefaultRegion()
        {
            _regionManager.RequestNavigate(RegionNames.MAIN, ViewNames.HOME);
            _regionManager.RequestNavigate(RegionNames.CONTROL, ViewNames.CONTROLBAR);
        }

        private void OnClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            _eventAggregator.GetEvent<MainWindowClosingEvent>().Publish();
            _disposeManager.DisposeResources();
        }

        private void OnClosed()
        {
            _eventAggregator.GetEvent<MainWindowClosedEvent>().Publish();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
