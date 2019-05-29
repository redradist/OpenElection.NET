using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenVote.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigPage : ContentPage
    {
        public ConfigPage()
        {
            InitializeComponent();
        }

        public void OrganizationType_Tapped(object sender, ItemTappedEventArgs e)
        {
            Debug.WriteLine($"Organization Type is {e.Item}");
            ShowVotePage(e.Item);
        }

        protected async void ShowVotePage(object organization)
        {
            await Navigation.PushAsync(new VotePage(organization));
        }
    }
}
