namespace PrismInspectionAppTemplate.Core.Service.Setting
{
    public interface ISettingRepository
    {
        ISetting Setting { get; set; }
        T GetSetting<T>() where T : ISetting;
        void Load<T>() where T : class, ISetting, new();
        void Save<T>() where T : class, ISetting;
    }
}
