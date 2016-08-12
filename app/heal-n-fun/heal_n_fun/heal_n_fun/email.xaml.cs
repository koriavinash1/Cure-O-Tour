using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Limilabs.Client.SMTP;
using Limilabs.Mail;
using Limilabs.Mail.Headers;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace heal_n_fun
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class email : Page
    {
        public email()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(homepage), null);
        }



        private async void button_Click_1(object sender, RoutedEventArgs e)
        {

            MailBuilder myMail = new MailBuilder();
            myMail.Html = "From: " + id.Text + "\nMessage: " + textBox.Text;
            myMail.Subject = "Customer Suggestions/ Feedback";
            myMail.To.Add(new MailBox("courotour@gmail.com"));
            myMail.From.Add(new MailBox("healnfun@gmail.com"));
            IMail email = myMail.Create();
            using (Smtp smtp = new Smtp())
            {
                await smtp.Connect("smtp.gmail.com", 25);
                await smtp.UseBestLoginAsync("healnfun@gmail.com", "!@#healNfun123");
                await smtp.SendMessageAsync(email);
                await smtp.CloseAsync();

            }

            MessageDialog msg = new MessageDialog("Your response has been recorded. Thank you!");
            msg.ShowAsync();
            textBox.Text = "";
            id.Text = "";

        }
    }
}


