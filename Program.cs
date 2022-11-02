namespace ClipboardCleaner
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using Mutex mutex = new Mutex(true, Application.ProductName, out bool singleInstance);
            if (!singleInstance)
            {
                MessageBox.Show($"{Application.ProductName} is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new App());
        }
    }
}