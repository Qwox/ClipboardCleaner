using System.Resources;
using System.Globalization;

namespace ClipboardCleaner
{
    public class Localization
    {
        private static readonly Localization _instance = new Localization();
        private ResourceManager ResourceManager { get; } = new ResourceManager("ClipboardCleaner.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        public CultureInfo CultureInfo { get; set; } = new CultureInfo("en");
        public string[] AvailableLanguages { get; } = { "en", "de"};

        static Localization() { }
        private Localization() { }

        public static Localization Instance
        {
            get
            {
                return _instance;
            }
        }
        public string GetString(string name)
        {
            return ResourceManager.GetString(name, CultureInfo) ?? "";
        }
    }
}
