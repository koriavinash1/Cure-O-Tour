using Limilabs.Client.SMTP;
using Limilabs.Mail;
using Limilabs.Mail.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace heal_n_fun
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class patientprofile : Page
    {
        

        public patientprofile()
        {
            this.InitializeComponent();
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var pass = password.Password;
            var conpass = confirmpassword.Password;
            string contact = contactno.Text;
            int a = contact.Length;
            string name1 = name.Text;
            string email1 = email.Text;
            string username1 = username.Text;
            string line = line1.Text;
            string city1 = city.Text;
            string country1 = country.Text;
            string pin1 = pin.Text;
            string state1 = state.Text;
            int tempemail = 0, tempusername = 0, temppin = 0, tempstate = 0, tempcity = 0, tempcountry = 0, flag = 0, tempemail1 = 0, tempemail2 = 0;
            for (int i = 0; i < email1.Length; i++)//emailid verification
            {
                if (email1[i] == '@')
                    tempemail1 = 1;
                if (email1[i] == '.')
                    tempemail2 = 1;
                if (string.Compare(email1, " ", true) == 0)
                {
                    tempemail = 1;
                    break;
                }

            }
            // Need to compare the existing username in database with the present username..................................

            for (int i = 0; i < username1.Length; i++)//username verification
            {
                if (username1[i] == ' ')
                {
                    tempusername = 1;
                    break;
                }
            }

            for (int i = 0; i < state1.Length; i++)//city verification
            {
                if (city1[i] == ' ')
                {
                    temppin = 1;
                    break;
                }
            }
            for (int i = 0; i < state1.Length; i++)//state verification
            {
                if (state1[i] == ' ')
                {
                    tempstate = 1;
                    break;
                }
            }
            for (int i = 0; i < country1.Length; i++)//country verification
            {
                if (country1[i] == ' ')
                {
                    tempcountry = 1;
                    break;
                }
            }

            for (int i = 0; i < pin1.Length; i++)//pincode verification
            {
                if (pin1[i] < '0' || pin1[i] > '9')
                {
                    temppin = 1;
                    break;
                }
            }
            for (int i = 0; i < a; i++)//contact number verification
            {
                if (contact[i] < '0' || contact[i] > '9')
                {
                    flag = 1;
                    break;
                }
            }

            
            if (name.Text == " " || email.Text == " " || username.Text == " " || contactno.Text == " " || line1.Text == " " || pin.Text == " " || state.Text == " "|| name.Text == "" || email.Text == "" || username.Text == "" || contactno.Text == "" || line1.Text == "" || pin.Text == "" || state.Text == "")
            {
                MessageDialog msg = new MessageDialog("Fill entire profile and try again.");
                msg.ShowAsync();
            }
            else
            {
                if (pass != conpass)
                {
                    MessageDialog msg = new MessageDialog("Set password and Confirm password must be same. ");
                    msg.ShowAsync();
                }
                else
                {
                    if (flag == 1)
                    {
                        MessageDialog msg = new MessageDialog("Enter proper contact number.");
                        msg.ShowAsync();
                    }
                    else if (tempemail == 1 || tempemail1==0 || tempemail2==0)
                    {
                        MessageDialog msg = new MessageDialog("Enter proper emailid.");
                        msg.ShowAsync();
                    }
                    else if (tempusername == 1)
                    {
                        MessageDialog msg = new MessageDialog("Enter proper username.");
                        msg.ShowAsync();
                    }
                    else if (temppin == 1)
                    {
                        MessageDialog msg = new MessageDialog("Enter proper Pincode.");
                        msg.ShowAsync();
                    }
                    else if (tempstate == 1)
                    {
                        MessageDialog msg = new MessageDialog("Enter proper state details.");
                        msg.ShowAsync();
                    }

                    else
                    {
                        this.Frame.Navigate(typeof(mainpage1));
                        MessageDialog msg = new MessageDialog("Profile saved successfully.");
                        msg.ShowAsync();

                        MailBuilder myMail = new MailBuilder();
                        myMail.Html = "Welcome to Cure-o-Tour \n\n Your username is" + username.Text + "and your password is" + pass+ ".\n\n Cheers,\n Cure-o-Tour Team.";
                        myMail.Subject = "Welcome to Cure-o-Tour";
                        myMail.To.Add(new MailBox(email1));
                        myMail.From.Add(new MailBox("cureotour@gmail.com"));
                        IMail email = myMail.Create();
                        using (Smtp smtp = new Smtp())
                        {
                            await smtp.Connect("smtp.gmail.com", 25);
                            await smtp.UseBestLoginAsync("cureotour@gmail.com", "cour0tour");
                            await smtp.SendMessageAsync(email);
                            await smtp.CloseAsync();
                        }

                        //send sms to given contact number..................                                    
                    }
                }
            }
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(mainpage1), null);
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI cc = new CameraCaptureUI();
            cc.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            cc.PhotoSettings.CroppedAspectRatio = new Size(3, 4);
            cc.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;
            StorageFile sf = await cc.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (sf != null)
            {
                BitmapImage bmp = new BitmapImage();
                IRandomAccessStream rs = await sf.OpenAsync(FileAccessMode.Read);
                bmp.SetSource(rs);
                image1.Source = bmp;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(homepage), null);
        }
    }
}
  
