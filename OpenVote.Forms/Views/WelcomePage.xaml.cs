using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OpenVote;

namespace OpenVote.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {

        public WelcomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(page: this, value: false);
            Device.StartTimer(TimeSpan.FromSeconds(Constants.WelcomeShowTime),
                              OnTimerTickAsync);
        }

        private bool OnTimerTickAsync()
        {
            Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);
            return false;
        }
    }
}