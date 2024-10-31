using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CvsService.Prism.Interfaces;
using Microsoft.Xaml.Behaviors.Media;
using Prism.Commands;
using Prism.Mvvm;
using PrismInspectionAppTemplate.Core.Service.Bootstrap;

namespace PrismInspectionAppTemplate.ViewModels
{
    public class StartupViewModel : BindableBase, IStartupViewModel
    {
        private IBootstrapManager _bootstrapManager;

        private string _message;
        public string Message { get => _message; set => SetProperty(ref _message, value); }

        private int _progressValue;
        public int ProgressValue { get => _progressValue; set => SetProperty(ref _progressValue, value); }

        public ICommand LoadedCommand => new DelegateCommand(async () => await OnLoaded());
        public ICommand ClosingCommand => new DelegateCommand(OnClosing);

        public event EventHandler WindowLoadedCompleted;

        public StartupViewModel(IBootstrapManager bootstrapManager)
        {
            _bootstrapManager = bootstrapManager;
        }

        private Task OnLoaded()
        {
            _bootstrapManager.BootstrapperCompletedEvent += OnBootstrapperCompleted;
            _bootstrapManager.AllBootstrappersCompletedEvent += OnAllBootstrappersCompleted;

            return _bootstrapManager.InitializeAllAsync();
        }

        private void OnClosing()
        {
            _bootstrapManager.StopInitialize();
        }

        private void OnBootstrapperCompleted(object sender, BootstrapperInfo e)
        {
            Message = e.Title;
            ProgressValue = e.ProgressPercent;
        }

        private void OnAllBootstrappersCompleted(object sender, EventArgs e)
        {
            _bootstrapManager.BootstrapperCompletedEvent -= OnBootstrapperCompleted;
            _bootstrapManager.AllBootstrappersCompletedEvent -= OnAllBootstrappersCompleted;
            WindowLoadedCompleted?.Invoke(this, e);
        }
    }
}
