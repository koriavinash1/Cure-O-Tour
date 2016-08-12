using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace heal_n_fun
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Patientlogin : Page
    {
        public Patientlogin()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int flag = 1, i = 0;
            // while (DataU[i] != DataU[DataU.count - 1]) { DataU is patient username,DataE is patient Email coloumn
            //if (DataU[i] == textBox.Text||DataE[i]==textBox.Text)
            //{
            //    flag = 1;
            //    break;
            //}
            //else
            //   flag=0;
            //   i++;
            //}           
            //if (flag == 0)
            //{
            //    if (DataU[i] == DataU[DataU.count - 1]||DataE[i]==DataE[DataE.count-1])
            //   {
            //       flag == 1;
            //       break;
            //   }
            //    else
            //        flag = 0;
            //}
           //upload this flag value in temp database within the system or on drive..........important
           //need to access it different cs files
            if (flag==1)
            {

               // flagData=1;
               // await App.MobileService.GetTable<abcd>().UpdateAsync(flagData);
                this.Frame.Navigate(typeof(mainpage1), null);
            }
            else
            {
                MessageDialog msg = new MessageDialog("User does not exist, First Signin & try again.");
                msg.ShowAsync();
                textBox.Text = "";
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(loginoptions), null);
        }
    }
}
