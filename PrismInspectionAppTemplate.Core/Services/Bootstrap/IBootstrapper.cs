namespace PrismInspectionAppTemplate.Core.Service.Bootstrap
{
    public interface IBootstrapper
    {
        BootstrapperInfo BootstrapperInfo { get; }
        void Initialize();
    }
}
