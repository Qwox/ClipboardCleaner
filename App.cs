using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;

namespace ClipboardCleaner
{
    public class App : ApplicationContext
    {
        private const string NOTIFICATION_TAG = "cb-clean-tag";
        private const string NOTIFICATION_GROUP = "ClipboardCleaner";

        private readonly Font _regularFont = new Font(SystemFonts.MenuFont ?? Control.DefaultFont, FontStyle.Regular);
        private readonly Font _boldFont = new Font(SystemFonts.MenuFont ?? Control.DefaultFont, FontStyle.Bold);
        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _contextMenuStrip;
        private readonly ClipboardObserver? _cbo;
        private readonly System.Windows.Forms.Timer _timer;

        private int _currentSeconds;
        private uint _sequenceNumber = 1;

        public App()
        {
            Application.ApplicationExit += (object? sender, EventArgs e) => { OnAppExit(e); };

            if (!Settings.SettingsFileExists())
            {
                var systemLanguage = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                if (Localization.Instance.AvailableLanguages.Contains(systemLanguage) && Settings.AppSettings.Language != systemLanguage)
                {
                    Settings.AppSettings.Language = systemLanguage;
                }
            }

            Settings.Load();
            Localization.Instance.CultureInfo = new System.Globalization.CultureInfo(Settings.AppSettings.Language);

            CheckAutostart();

            _contextMenuStrip = new ContextMenuStrip();
            _contextMenuStrip.Items.Add(new ToolStripMenuItem(Localization.Instance.GetString("clearNow"), null, ClearNowMenuClickHandler, "clearNow") { Font = _regularFont });
            _contextMenuStrip.Items.Add(new ToolStripSeparator());
            _contextMenuStrip.Items.Add(new ToolStripMenuItem(Localization.Instance.GetString("settings"), null, SettingsMenuClickHandler, "settings"));
            _contextMenuStrip.Items.Add(new ToolStripMenuItem(Localization.Instance.GetString("about"), null, InfoMenuClickHandler, "about"));
            _contextMenuStrip.Items.Add(new ToolStripSeparator());
            _contextMenuStrip.Items.Add(new ToolStripMenuItem(Localization.Instance.GetString("exit"), null, (object? sender, EventArgs e) => { ExitThread(); }, "exit"));
            _contextMenuStrip.Opening += (object? sender, System.ComponentModel.CancelEventArgs e) => {
                if(sender is not null and ContextMenuStrip)
                {
                    var csmi = ((ContextMenuStrip)sender).Items.Find("clearNow", true).First();

                    if (ClipboardContainsData())
                    {
                        csmi.Font = _boldFont;
                    }
                    else
                    {
                        csmi.Font = _regularFont;
                    }
                }
            };
            
            _notifyIcon = new NotifyIcon
            {
                Icon = (SystemHelper.GetSystemTheme() == 0) ? Properties.Resources.TrayIcon_Dark : Properties.Resources.TrayIcon_Light,
                Text = Application.ProductName,
                Visible = true,
                ContextMenuStrip = _contextMenuStrip,
            };

            _cbo = new ClipboardObserver();
            _cbo.ClipboardChanged += ClipboardChanged;
            _cbo.AddClipboardListener();

            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += TimerTickHandler;
            _timer.Interval = 1000;

            _currentSeconds = Settings.AppSettings.ClearAfterSeconds;
        }

        private void OnAppExit(EventArgs e)
        {
            _cbo?.RemoveClipboardListener();
            _timer?.Dispose();
            _contextMenuStrip?.Dispose();
            _regularFont?.Dispose();
            _boldFont?.Dispose();

            if(_notifyIcon != null)
            {
                _notifyIcon.Visible = false;
                _notifyIcon.Dispose();
            }

            ToastNotificationManagerCompat.Uninstall();
        }

        private void ClearNowMenuClickHandler(object? sender, EventArgs e)
        {
            ClearClipboard();
        }

        private void CheckAutostart()
        {
            var isAutostart = SystemHelper.IsAutostart();

            if (!Settings.AppSettings.Autorun && !isAutostart)
                return;

            if(Settings.AppSettings.Autorun && isAutostart)
            {
                try
                {
                    var path = SystemHelper.GetAutostartPath();
                    if (!string.IsNullOrWhiteSpace(path) && !string.Equals(Path.GetFullPath(Application.ExecutablePath), Path.GetFullPath(path), StringComparison.OrdinalIgnoreCase))
                    {
                        SystemHelper.CreateOrUpdateAutostart();
                    }
                }
                catch (Exception) { }
            }
            else if (Settings.AppSettings.Autorun && !isAutostart)
            {
                SystemHelper.CreateOrUpdateAutostart();
            }
            else if (!Settings.AppSettings.Autorun && isAutostart)
            {
                SystemHelper.DeleteAutostart();
            }
        }

        private void SettingsMenuClickHandler(object? sender, EventArgs e)
        {
            var form = new SettingsForm();
            var result = form.ShowDialog();
            bool needsRestart = form.LanguageChanged;
            form.Dispose();

            if(result == DialogResult.OK)
            {
                CheckAutostart();

                if(needsRestart)
                    Application.Restart();
            }
        }

        private void InfoMenuClickHandler(object? sender, EventArgs e)
        {
            var form = new AboutForm();
            _ = form.ShowDialog();
            form.Dispose();
        }

        private void TimerTickHandler(object? sender, EventArgs e)
        {
            if(!_timer.Enabled)
                return;

            --_currentSeconds;
            if(_currentSeconds <= 0 && _timer.Enabled)
            {
                ClearClipboard();
            }
            else if(_currentSeconds > 0 && _timer.Enabled)
            {
                var progressValue = (1f / Settings.AppSettings.ClearAfterSeconds) * _currentSeconds;
                UpdateNotification(progressValue);
            }
        }

        private void ShowNotification()
        {
            ToastNotificationManagerCompat.History.Clear();

            if (!Settings.AppSettings.ShowNotifications)
                return;

            var content = new ToastContentBuilder()
                .AddVisualChild(new AdaptiveText()
                {
                    Text = new BindableString("titleValue")
                })
                .AddVisualChild(new AdaptiveText()
                {
                    Text = new BindableString("textValue")
                });

            if (Settings.AppSettings.ShowNotificationProgress && Settings.AppSettings.AutomaticClearing)
            {
                content.AddVisualChild(new AdaptiveProgressBar()
                {
                    Title = "",
                    Value = new BindableProgressBarValue("progressValue"),
                    ValueStringOverride = new BindableString("progressValueString"),
                    Status = Localization.Instance.GetString("notifClearIn")
                });
            }

            content.SetToastDuration(Settings.AppSettings.AutomaticClearing ? ToastDuration.Long : ToastDuration.Short)
                .GetToastContent();

            var expirationTime = DateTime.Now.AddSeconds(3);
            if(Settings.AppSettings.AutomaticClearing && Settings.AppSettings.ShowNotificationProgress)
            {
                expirationTime = DateTime.Now.AddSeconds(Settings.AppSettings.ClearAfterSeconds + 3);
            }
            
            var toast = new ToastNotification(content.GetXml())
            {
                Tag = NOTIFICATION_TAG,
                Group = NOTIFICATION_GROUP,
                ExpirationTime = expirationTime,
                Data = new NotificationData()
            };
            toast.Data.Values["titleValue"] = Localization.Instance.GetString("notifTitle");
            toast.Data.Values["textValue"] = Settings.AppSettings.AutomaticClearing ? string.Format(Localization.Instance.GetString("notifText"), Settings.AppSettings.ClearAfterSeconds) : "";

            if (Settings.AppSettings.ShowNotificationProgress && Settings.AppSettings.AutomaticClearing)
            {
                toast.Data.Values["progressValue"] = "1";
                toast.Data.Values["progressValueString"] = string.Format("{0:D} {1}", _currentSeconds, Localization.Instance.GetString("notifSeconds"));
            }

            toast.Data.SequenceNumber = _sequenceNumber++;

            ToastNotificationManagerCompat.CreateToastNotifier().Show(toast);
        }

        private void UpdateNotification(float progressValue)
        {
            if (!Settings.AppSettings.ShowNotifications || !Settings.AppSettings.ShowNotificationProgress)
                return;

            var data = new NotificationData();
            data.Values["progressValue"] = progressValue.ToString();
            data.Values["progressValueString"] = string.Format("{0:D} {1}", _currentSeconds, _currentSeconds == 1 ? Localization.Instance.GetString("notifSecond") : Localization.Instance.GetString("notifSeconds"));
            data.SequenceNumber = _sequenceNumber++;

            ToastNotificationManagerCompat.CreateToastNotifier().Update(data, NOTIFICATION_TAG, NOTIFICATION_GROUP);
        }

        private void ShowCompletedNotification()
        {
            ToastNotificationManagerCompat.History.Clear();

            if (!Settings.AppSettings.ShowNotifications)
                return;

            var content = new ToastContentBuilder()
                .AddVisualChild(new AdaptiveText()
                {
                    Text = new BindableString("titleValue")
                })
                .AddVisualChild(new AdaptiveText()
                {
                    Text = new BindableString("textValue")
                })
                .SetToastDuration(ToastDuration.Short)
                .GetToastContent();

            var toast = new ToastNotification(content.GetXml())
            {
                Tag = NOTIFICATION_TAG,
                Group = NOTIFICATION_GROUP,
                ExpirationTime = DateTime.Now.AddSeconds(1),
                Data = new NotificationData()
            };
            toast.Data.Values["titleValue"] = Localization.Instance.GetString("notifEmptiedTitle");
            toast.Data.Values["textValue"] = Localization.Instance.GetString("notifEmptiedText");

            toast.Data.SequenceNumber = _sequenceNumber++;

            ToastNotificationManagerCompat.CreateToastNotifier().Show(toast);
        }

        private bool ClipboardContainsData()
        {
            if (Clipboard.ContainsData(DataFormats.Bitmap)
                || Clipboard.ContainsData(DataFormats.CommaSeparatedValue)
                || Clipboard.ContainsData(DataFormats.Dib)
                || Clipboard.ContainsData(DataFormats.Dif)
                || Clipboard.ContainsData(DataFormats.EnhancedMetafile)
                || Clipboard.ContainsData(DataFormats.FileDrop)
                || Clipboard.ContainsData(DataFormats.Html)
                || Clipboard.ContainsData(DataFormats.Locale)
                || Clipboard.ContainsData(DataFormats.MetafilePict)
                || Clipboard.ContainsData(DataFormats.OemText)
                || Clipboard.ContainsData(DataFormats.Palette)
                || Clipboard.ContainsData(DataFormats.PenData)
                || Clipboard.ContainsData(DataFormats.Riff)
                || Clipboard.ContainsData(DataFormats.Rtf)
                || Clipboard.ContainsData(DataFormats.Serializable)
                || Clipboard.ContainsData(DataFormats.StringFormat)
                || Clipboard.ContainsData(DataFormats.SymbolicLink)
                || Clipboard.ContainsData(DataFormats.Tiff)
                || Clipboard.ContainsData(DataFormats.Text)
                || Clipboard.ContainsData(DataFormats.UnicodeText)
                || Clipboard.ContainsData(DataFormats.WaveAudio))
            {
                return true;
            }

            return false;
        }

        private void ClipboardChanged()
        {
            if(_timer.Enabled)
            {
                _timer.Stop();
            }

            if (ClipboardContainsData())
            {
                if(Clipboard.ContainsData(DataFormats.FileDrop) && Settings.AppSettings.AutomaticClearing)
                {
                    var fileList = Clipboard.GetFileDropList();

                    foreach(var file in fileList)
                    {
                        if(!Directory.Exists(Path.GetDirectoryName(file)))
                        {
                            return;
                        }
                        else if(File.Exists(file))
                        {
                            if (new FileInfo(file).Length > Settings.AppSettings.MaxFileSizeMB * 1024 * 1024)
                            {
                                return;
                            }
                        }
                    }
                }

                if (Settings.AppSettings.AutomaticClearing)
                {
                    _currentSeconds = Settings.AppSettings.ClearAfterSeconds;
                    _timer.Start();
                }

                ShowNotification();
            }
        }

        private void ClearClipboard()
        {
            if (!ClipboardContainsData())
                return;

            if(_timer.Enabled)
            {
                _timer.Stop();
            }

            Clipboard.Clear();
            ShowCompletedNotification();
        }
    }
}
