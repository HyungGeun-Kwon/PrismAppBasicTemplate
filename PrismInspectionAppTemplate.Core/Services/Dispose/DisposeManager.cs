using System;
using System.Collections.Generic;

namespace PrismInspectionAppTemplate.Core.Service.Dispose
{
    public class DisposeManager : IDisposeManager
    {
        private object _lockObj = new object();
        private readonly List<IDisposable> _disposeValues = new List<IDisposable>();

        public DisposeManager()
        {

        }

        public void AddDisposeValue(IDisposable disposable)
        {
            lock (_lockObj)
            {
                _disposeValues.Add(disposable);
            }
        }
        public void DisposeResources()
        {
            lock (_lockObj)
            {
                for (int i = 0; i < _disposeValues.Count; i++)
                {
                    _disposeValues[i]?.Dispose();
                }
                _disposeValues.Clear();
            }
        }
    }
}
