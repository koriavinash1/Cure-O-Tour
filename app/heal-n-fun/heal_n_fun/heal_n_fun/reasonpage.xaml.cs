
using Reasonpage;
using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace heal_n_fun
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class reasonpage : Page
    {
        public reasonpage()
        {
            this.InitializeComponent();
        }
   

        private void Reason_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var matchingReasons = ReasonSampleDataSource.GetMatchingReasons(sender.Text);

                sender.ItemsSource = matchingReasons.ToList();
            }

        }

        private void Reason_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                SelectReason(args.ChosenSuggestion as Reason);
            }
            else
            {
                var matchingReasons = ReasonSampleDataSource.GetMatchingReasons(args.QueryText);
                if (matchingReasons.Count() >= 1)
                {
                    SelectReason(matchingReasons.FirstOrDefault());
                }
                else
                {
                    NoResults.Visibility = Visibility.Visible;
                }
            }
        }

        private void Reason_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var reason = args.SelectedItem as Reason;
            sender.Text = string.Format("{0}", reason.fullreason);
        }


        private void SelectReason(Reason reason)
        {
            if (reason != null)
            {
                ReasonDetails.Visibility = Visibility.Visible;
                Reason.Text = reason.fullreason;
            }
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("1.AIIMS (NewDelhi,India) best place for this treatment.\n2.Manipal (Banglore,India)\n3.Kims (Karnataka,India)\n4.abcd (abcd,efgh)\n5.efgh (efgh,ijkl)");
            msg.ShowAsync();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(reason), null);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(homepage), null);
        }
    }
}
