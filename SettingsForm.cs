using System.Globalization;


namespace ClipboardCleaner
{
    public partial class SettingsForm : Form
    {
        public bool LanguageChanged { get; private set; } = false;
        public SettingsForm()
        {
            InitializeComponent();

            Text = $"{Application.ProductName} - {Localization.Instance.GetString("settings")}";
            generalGroupBox.Text = Localization.Instance.GetString("generalGroupBox");
            languageLabel.Text = Localization.Instance.GetString("languageLabel");
            autorunCheckBox.Text = Localization.Instance.GetString("autorunCheckBox");
            clipboardGroupBox.Text = Localization.Instance.GetString("clipboardGroupBox");
            automaticClearingCheckBox.Text = Localization.Instance.GetString("automaticClearingCheckBox");
            clearAfterLabel.Text = Localization.Instance.GetString("clearAfterLabel");
            secondsLabel.Text = Localization.Instance.GetString("secondsLabel");
            notificationGroupBox.Text = Localization.Instance.GetString("notificationGroupBox");
            showNotificationCheckBox.Text = Localization.Instance.GetString("showNotificationCheckBox");
            showNotificationProgressCheckBox.Text = Localization.Instance.GetString("showNotificationProgressCheckBox");
            saveButton.Text = Localization.Instance.GetString("saveButton");
            cancelButton.Text = Localization.Instance.GetString("cancelButton");

            foreach (var language in Localization.Instance.AvailableLanguages)
            {
                languageComboBox.Items.Add(new CultureInfo(language).NativeName);
            }

            languageComboBox.SelectedIndex = Array.IndexOf(Localization.Instance.AvailableLanguages, Settings.AppSettings.Language);
            autorunCheckBox.Checked = Settings.AppSettings.Autorun;
            automaticClearingCheckBox.Checked = Settings.AppSettings.AutomaticClearing;
            timeToClearNumericUpDown.Value = Settings.AppSettings.ClearAfterSeconds;
            showNotificationCheckBox.Checked = Settings.AppSettings.ShowNotifications;
            showNotificationProgressCheckBox.Checked = Settings.AppSettings.ShowNotificationProgress;
        }

        private void SaveButtonClickHandler(object sender, EventArgs e)
        {
            if (Settings.AppSettings.Language != Localization.Instance.AvailableLanguages[languageComboBox.SelectedIndex])
                LanguageChanged = true;

            Settings.AppSettings.Language = Localization.Instance.AvailableLanguages[languageComboBox.SelectedIndex];
            Settings.AppSettings.Autorun = autorunCheckBox.Checked;
            Settings.AppSettings.AutomaticClearing = automaticClearingCheckBox.Checked;
            Settings.AppSettings.ClearAfterSeconds = (int)timeToClearNumericUpDown.Value;
            Settings.AppSettings.ShowNotifications = showNotificationCheckBox.Checked;
            Settings.AppSettings.ShowNotificationProgress = showNotificationProgressCheckBox.Checked;

            Settings.Save();
        }
    }
}
