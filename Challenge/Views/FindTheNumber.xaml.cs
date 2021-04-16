using Challenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Challenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindTheNumber : ContentPage
    {

        FindTheNumberViewModel viewModel;
        public FindTheNumber()
        {
            InitializeComponent();
            BindingContext = viewModel = new FindTheNumberViewModel();
            error_message_label.IsVisible = false;
        }

        void OnNumberChanged(object sender, TextChangedEventArgs e)
        {
            if (!(number_entry is null) && number_entry.Text != ""){
                if (number_entry.Text.Contains("."))
                {
                    error_message_label.Text = "The number must be an integer!";
                    error_message_label.IsVisible = true;
                    send_button.IsEnabled= false;
                }
                else if (number_entry.Text.Contains("-"))
                {
                    error_message_label.Text = "The number is positive!";
                    error_message_label.IsVisible = true;
                    send_button.IsEnabled = false;
                }
                else if (Int32.Parse(number_entry.Text) < 1 || Int32.Parse(number_entry.Text) > 500000)
                {
                    error_message_label.Text = "The number is between 1 and 50000!";
                    error_message_label.IsVisible = true;
                    send_button.IsEnabled = false;
                }
                else
                {
                    error_message_label.Text = "";
                    error_message_label.IsVisible = false;
                    send_button.IsEnabled = true;
                }
            }
            else
            {
                error_message_label.Text = "";
                error_message_label.IsVisible = false;
                send_button.IsEnabled = false;
            }
        }

        void OnNumberSent(object sender, EventArgs e)
        {
            int number;
            if (!(number_entry is null) && !(number_entry.Text is null) && number_entry.Text.Trim() != "" && !number_entry.Text.Contains(".") && !number_entry.Text.Contains("-"))
            {
                number = Int32.Parse(number_entry.Text);
                send_button.IsEnabled = false;
                number_entry.Text = "";
                viewModel.SubmitNumber(number).ContinueWith((antecedent) =>
                {
                    send_button.IsEnabled = true;
                });
            }
        }
    }
}