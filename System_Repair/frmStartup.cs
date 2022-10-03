using Microsoft.Win32;


namespace System_Repair
{
    public partial class frmStartup : MainWindow
    {
        // The path to the key where Windows looks for startup applications
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        string path = System.Reflection.Assembly.GetExecutingAssembly().Location;


        public frmStartup()
        {
            InitializeComponent();
            // Check to see the current state (running at startup or not)
            if (rkApp.GetValue("System_Repair") == null)
            {
                // The value doesn't exist, the application is not set to run at startup
               

                rkApp.DeleteValue("System_Repair", false);
            }
            else
            {
                // The value exists, the application is set to run at startup
             
                rkApp.SetValue("System_Repair", path);
            }
        }
    }
}