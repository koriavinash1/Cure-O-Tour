using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Chat;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Calls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace heal_n_fun
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class contactus : Page
    {
        public contactus()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(patientside), null);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(tipspage), null);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(settingspage), null);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(helppage), null);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(email), null);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
           Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI("9962738722", "HealnFun");
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(homepage), null);
        }
    }
}
