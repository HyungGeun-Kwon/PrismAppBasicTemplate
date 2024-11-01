using System.Xml.Serialization;
using CvsService.UI.Windows.Enums;
using Prism.Mvvm;

namespace PrismInspectionAppTemplate.Core.Setting
{
    public class WindowSetting : BindableBase
    {
        private EWindowTheme _theme = EWindowTheme.Dark;

        [XmlElement]
        public EWindowTheme Theme { get => _theme; set => SetProperty(ref _theme, value); }

        public WindowSetting() { }
    }
}
