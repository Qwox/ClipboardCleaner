using Microsoft.Win32;

namespace ClipboardCleaner
{
    public static class SystemHelper
    {
        public const string SYSTEM_THEME_ROOT_KEY = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize";
        public const string SYSTEM_THEME_KEY = "SystemUsesLightTheme";
        public const string AUTORUN_ROOT_KEY = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public const string APP_KEY = "ClipboardCleaner";

        public static int GetSystemTheme()
        {
            object? value = null;
            RegistryKey? subkey = null;
            try
            {
                subkey = Registry.CurrentUser.OpenSubKey(SYSTEM_THEME_ROOT_KEY, false);
                value = subkey?.GetValue(SYSTEM_THEME_KEY, 1);
            }
            catch (Exception) { }
            finally
            {
                subkey?.Close();
            }

            if (value != null)
            {
                return (int)value;
            }
            else
            {
                return 1;
            }
        }

        public static bool IsAutostart()
        {
            object? value = null;
            RegistryKey? subkey = null;
            try
            {
                subkey = Registry.CurrentUser.OpenSubKey(AUTORUN_ROOT_KEY, false);
                value = subkey?.GetValue(APP_KEY);
            }
            catch (Exception) { }
            finally
            {
                subkey?.Close();
            }

            return value != null;
        }

        public static string GetAutostartPath()
        {
            object? value = null;
            RegistryKey? subkey = null;
            try
            {
                subkey = Registry.CurrentUser.OpenSubKey(AUTORUN_ROOT_KEY, false);
                value = subkey?.GetValue(APP_KEY);
            }
            catch (Exception) { }
            finally
            {
                subkey?.Close();
            }
            string path = value?.ToString() ?? "";
            return path;
        }

        public static void SetAutostartPath(string path)
        {
            RegistryKey? subkey = null;
            try
            {
                subkey = Registry.CurrentUser.OpenSubKey(AUTORUN_ROOT_KEY, true);
                subkey?.SetValue(APP_KEY, path);
            }
            catch (Exception) { }
            finally
            {
                subkey?.Close();
            }
        }

        public static void CreateOrUpdateAutostart()
        {
            SetAutostartPath(Application.ExecutablePath);
        }

        public static void DeleteAutostart()
        {
            RegistryKey? subkey = null;
            try
            {
                subkey = Registry.CurrentUser.OpenSubKey(AUTORUN_ROOT_KEY, true);
                subkey?.DeleteValue(APP_KEY);
            }
            catch (Exception) { }
            finally
            {
                subkey?.Close();
            }
        }
    }
}
