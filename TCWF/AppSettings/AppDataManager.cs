using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace TCWF.AppSettings
{
    public class AppDataManager
    {
        private const string _settingsFilename = "setting.json";
        private AppData _settings;

        public AppDataManager()
        {
            LoadFromLocalFile();
        }

        private string FilePath => Path.Combine(Application.LocalUserAppDataPath, _settingsFilename);

        private void LoadFromLocalFile()
        {
            if (!Directory.Exists(Application.LocalUserAppDataPath))
            {
                Directory.CreateDirectory(Application.ExecutablePath);
            }
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }
            var settingsFromFile = JsonConvert.DeserializeObject<AppData>(File.ReadAllText(FilePath));
            if (settingsFromFile != null)
            {
                _settings = settingsFromFile;
            }
            else
            {
                _settings = new AppData();
            }
        }

        public void SetProperty(string appSetting, object value)
        {
            PropertyInfo property = _settings.GetType().GetProperty(appSetting);
            if (property.GetValue(_settings) != value)
            {
                property.SetValue(_settings, value);
                UpdateLocalFile();
            }
        }

        public object GetProperty(string appSetting)
        {
            PropertyInfo property = _settings.GetType().GetProperty(appSetting);
            return property.GetValue(_settings);
        }

        private void UpdateLocalFile()
        {
            string json = JsonConvert.SerializeObject(_settings);
            File.WriteAllText(FilePath, json);
        }
    }
}
