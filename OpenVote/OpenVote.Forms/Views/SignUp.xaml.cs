using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenVote.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs eventArgs)
        {
            await DisplayAlert("Alert", "Login Button Clicked !!", "OK");
        }

        private void UserNameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check if user exists by checking in online
            Entry usernameEntry = FindByName("usernameEntry") as Entry;
            if (usernameEntry != null && !string.IsNullOrEmpty(usernameEntry.Text))
            {
                Entry passwordEntry = FindByName("passwordEntry") as Entry;
                if (passwordEntry != null)
                {
                    passwordEntry.IsEnabled = true;
                }
                Entry emailEntry = FindByName("emailEntry") as Entry;
                if (emailEntry != null)
                {
                    emailEntry.IsEnabled = true;
                }
            }
        }

        private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check if user exists by checking in online
            Entry passwordEntry = FindByName("passwordEntry") as Entry;
            if (passwordEntry != null && !string.IsNullOrEmpty(passwordEntry.Text))
            {

            }
        }

        private void EmailEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check if user exists by checking in online
            Entry emailEntry = FindByName("emailEntry") as Entry;
            if (emailEntry != null && !string.IsNullOrEmpty(emailEntry.Text))
            {

            }
        }
    }
}