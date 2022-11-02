namespace ClipboardCleaner
{
    public partial class AboutForm : Form
    {
        private const int _copyrightFrom = 2022;
        private readonly string _copyrightTo = _copyrightFrom < DateTime.Now.Year ? $"-{DateTime.Now.Year}" : "";
        private const string _websiteLink = "https://github.com/Qwox/ClipboardCleaner/";
        private const string _iconsLink= "https://icons8.com/";
        public AboutForm()
        {
            InitializeComponent();

            appNameLabel.Text = Application.ProductName;
            versionLabel.Text = $"v{Application.ProductVersion}";
            copyrightLabel.Text = $"© {_copyrightFrom}{_copyrightTo} Qwox";
            websiteLinkLabel.Text = _websiteLink;
            iconsByLinkLabel.Text = _iconsLink;
        }

        private void WebsiteLinkClickedHandler(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo(_websiteLink) { UseShellExecute = true };
            System.Diagnostics.Process.Start(psi);
        }

        private void IconsLinkClickedHandler(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo(_iconsLink) { UseShellExecute = true };
            System.Diagnostics.Process.Start(psi);
        }
    }
}
