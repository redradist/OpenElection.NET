using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenVote.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OrganizationType_Tapped(object sender, ItemTappedEventArgs e)
        {
            Debug.WriteLine($"Organization Type is {e.Item}");
        }
    }
}
