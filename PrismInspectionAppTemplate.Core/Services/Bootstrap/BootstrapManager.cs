using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrismInspectionAppTemplate.Core.Service.Bootstrap
{
    public class BootstrapManager : IBootstrapManager, IDisposable
    {
        private object _lockObj = new object();
        private bool _isContinueInitialize = true;
        private Dictionary<string, IBootstrapper> _bootstrappers;

        public bool IsFail { get; private set; } = false;

        public event EventHandler<Exception> BootstrapperInitExceptionEvent;
        public event EventHandler<BootstrapperInfo> BootstrapperCompletedEvent;
        public event EventHandler AllBootstrappersCompletedEvent;

        public BootstrapManager()
        {
            _bootstrappers = new Dictionary<string, IBootstrapper>();
        }
        public void AddBootstrap(string key, IBootstrapper bootstrapper)
        {
            lock (_lockObj) { _bootstrappers.Add(key, bootstrapper); }
        }

        public void RemoveBootstrap(string key)
        {
            lock (_lockObj) { _bootstrappers.Remove(key); }
        }

        public Task InitializeAllAsync(bool stopOnError = false)
        {
            IsFail = false;
            return Task.Run(() =>
            {
                lock (_lockObj)
                {
                    int i = 0;
                    foreach (var key in _bootstrappers.Keys)
                    {
                        if (!_isContinueInitialize) break;
                        try
                        {
                            InitBootstrapper(key);
                            _bootstrappers[key].BootstrapperInfo.SetProgressPercent(_bootstrappers.Count, i);
                            BootstrapperCompletedEvent?.Invoke(this, _bootstrappers[key].BootstrapperInfo);
                            i++;
                        }
                        catch (Exception ex)
                        {
                            IsFail = true;
                            BootstrapperInitExceptionEvent?.Invoke(this, ex);
                            if (stopOnError) { break; }
                        }
                    }
                    AllBootstrappersCompletedEvent?.Invoke(this, EventArgs.Empty);
                }
            });
        }

        public void InitBootstrapper(string key)
        {
            _bootstrappers[key].Initialize();
        }

        public void StopInitialize()
        {
            _isContinueInitialize = false;
        }

        public void Dispose()
        {
            _bootstrappers.Clear();
        }
    }

}
