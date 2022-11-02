using Newtonsoft.Json;

namespace ClipboardCleaner
{
    public class AppSettings
    {
        public string Language { get; set; } = "en";
        public bool Autorun { get; set; } = true;
        public int ClearAfterSeconds { get; set; } = 30;
        public long MaxFileSizeMB { get; set; } = 50;
        public bool ShowNotifications { get; set; } = true;
        public bool ShowNotificationProgress { get; set; } = true;
        public bool AutomaticClearing { get; set; } = true;
    }

    public static class Settings
    {
        private static string _fileName = "settings.json";
        private static string _fullFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName);
        private static string _fullFilePath = Path.Combine(_fullFolderPath, _fileName);

        public static AppSettings AppSettings { get; private set; } = new AppSettings();

        public static void Load()
        {
            if(!File.Exists(_fullFilePath))
            {
                Save();
                return;
            }

            try
            {
                string file = File.ReadAllText(_fullFilePath);
                var appSettings = JsonConvert.DeserializeObject<AppSettings>(file);

                if (appSettings != null)
                    AppSettings = appSettings;
            }
            catch (Exception) { }
        }

        public static void Save()
        {
            if(!Directory.Exists(_fullFolderPath))
            {
                try
                {
                    Directory.CreateDirectory(_fullFolderPath);
                }
                catch (Exception) { return; }
            }

            try
            {
                var json = JsonConvert.SerializeObject(AppSettings, Formatting.Indented);
                File.WriteAllText(_fullFilePath, json);
            }
            catch (Exception) { return; }
        }

        public static bool SettingsFileExists()
        {
            return File.Exists(_fullFilePath);
        }
    }
}
