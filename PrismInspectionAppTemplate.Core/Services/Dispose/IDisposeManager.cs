using System;

namespace PrismInspectionAppTemplate.Core.Service.Dispose
{
    public interface IDisposeManager
    {
        void AddDisposeValue(IDisposable disposable);
        void DisposeResources();
    }
}
