using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Prism.Mvvm;

namespace PrismInspectionAppTemplate.Core.Service.Setting
{

    public class SettingRepository : BindableBase, ISettingRepository
    {
        private string _folderPath;
        private string _settingFullPath;

        private ISetting _setting;
        public ISetting Setting { get => _setting; set => SetProperty(ref _setting, value); }

        public SettingRepository()
        {
            _folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Assembly.GetEntryAssembly().GetName().Name, "SettingFile");
            _settingFullPath = Path.Combine(_folderPath, "AppSetting.xml");
        }

        public SettingRepository(string settingFullPath)
        {
            _folderPath = Path.GetDirectoryName(settingFullPath);
            _settingFullPath = settingFullPath;
        }
        public T GetSetting<T>() where T : ISetting
        {
            if (Setting is T setting)
            {
                return setting;
            }
            throw new InvalidOperationException($"The current setting is not of type {typeof(T).Name}.");
        }
        public void Load<T>() where T : class, ISetting, new()
        {
            Setting = LoadXml<T>(_settingFullPath);
            Setting.LoadComplete();
        }
        public void Save<T>() where T : class, ISetting
        {
            Setting.BeforeSaving();
            SaveXml<T>();
        }
        private T LoadXml<T>(string fileFullPath) where T : class, new()
        {
            return File.Exists(fileFullPath) ? PopulateSetting<T>(fileFullPath) : new T();
        }
        private T PopulateSetting<T>(string fileFullPath)
        {
            T reVal;
            var ser = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(fileFullPath))
            {
                reVal = (T)ser.Deserialize(reader);
            }

            return reVal;
        }
        private void SaveXml<T>() where T : class
        {
            if (!Directory.Exists(_folderPath)) { _ = Directory.CreateDirectory(_folderPath); }

            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (StreamWriter sw = new StreamWriter(_settingFullPath))
            {
                ser.Serialize(sw, Setting);
            }
        }
    }
}
