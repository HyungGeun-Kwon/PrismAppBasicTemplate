using System.Xml.Serialization;
using Prism.Mvvm;
using PrismInspectionAppTemplate.Core.Service.Setting;

namespace PrismInspectionAppTemplate.Core.Setting
{
    public class AppSetting : BindableBase, ISetting
    {
        private WindowSetting _windowSetting = new WindowSetting();

        [XmlElement]
        public WindowSetting WindowSetting { get => _windowSetting; set => SetProperty(ref _windowSetting, value); }

        public AppSetting() { }

        public void LoadComplete()
        {
        }

        public void BeforeSaving()
        {
        }
    }
}
