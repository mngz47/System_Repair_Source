using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows;

namespace System_Repair
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            frmStartup frmStartup = new frmStartup();

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (serial_code.Text.Equals(getSerial()))
            {

                System.Environment.Exit(1);

            }
            else
            {

                LockWorkStation();

            }


        }

        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LockWorkStation();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        private string getSerial()
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://raw.githubusercontent.com/mngz47/System_Repair/main/Serial.txt");
            // access req.Headers to get/set header values before calling GetResponse. 
            // req.CookieContainer allows you access cookies.

            var response = req.GetResponse();
            string webcontent;
            using (var strm = new StreamReader(response.GetResponseStream()))
            {
                webcontent = strm.ReadToEnd();
            }

            return webcontent;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
