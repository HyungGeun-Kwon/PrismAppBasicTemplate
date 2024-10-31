using System;
using System.Threading.Tasks;

namespace PrismInspectionAppTemplate.Core.Service.Bootstrap
{
    public interface IBootstrapManager
    {
        bool IsFail { get; }

        event EventHandler<BootstrapperInfo> BootstrapperCompletedEvent;
        event EventHandler<Exception> BootstrapperInitExceptionEvent;
        event EventHandler AllBootstrappersCompletedEvent;

        void AddBootstrap(string key, IBootstrapper bootstrapper);
        void RemoveBootstrap(string key);
        void InitBootstrapper(string key);
        Task InitializeAllAsync(bool stopOnError = false);
        void StopInitialize();
    }

}
