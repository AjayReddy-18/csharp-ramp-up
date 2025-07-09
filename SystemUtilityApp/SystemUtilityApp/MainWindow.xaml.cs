using System.Management;
using System.IO;
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

        private void OnGetSystemInfoClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string osCaption = string.Empty;
                string totalMemory = string.Empty;
                string freeSpace = string.Empty;

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject mo in searcher.Get())
                    {
                        osCaption = mo["Caption"]?.ToString();
                        break;
                    }
                }

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem"))
                {
                    foreach (ManagementObject mo in searcher.Get())
                    {
                        if (mo["TotalPhysicalMemory"] != null)
                        {
                            double memBytes = Convert.ToDouble(mo["TotalPhysicalMemory"]);
                            totalMemory = $"{memBytes / (1024 * 1024 * 1024):F2} GB";
                        }
                        break;
                    }
                }

                DriveInfo driveC = new DriveInfo("C");
                if (driveC.IsReady)
                {
                    double freeBytes = driveC.AvailableFreeSpace;
                    freeSpace = $"{freeBytes / (1024 * 1024 * 1024):F2} GB";
                }

                SystemInfoText.Text = $"OS: {osCaption}\nTotal RAM: {totalMemory}\nFree Space (C:\\): {freeSpace}";
            }
            catch (Exception ex)
            {
                SystemInfoText.Text = $"Error: {ex.Message}";
            }
        }

    }
}
