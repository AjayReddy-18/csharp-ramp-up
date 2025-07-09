using Microsoft.Win32;
using System.Windows;

namespace SystemUtilityApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnReadVersionClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath))
                {
                    if (key != null)
                    {
                        object productName = key.GetValue("ProductName");
                        object releaseId = key.GetValue("ReleaseId");
                        object currentBuild = key.GetValue("CurrentBuild");

                        WindowsVersionText.Text = $"Product: {productName}\nRelease: {releaseId}\nBuild: {currentBuild}";
                    }
                    else
                    {
                        WindowsVersionText.Text = "Registry key not found.";
                    }
                }
            }
            catch (System.Exception ex)
            {
                WindowsVersionText.Text = $"Error: {ex.Message}";
            }
        }
    }
}
