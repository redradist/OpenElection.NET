using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OpenVote.Views;
using System.Collections.Generic;
using OpenVote.Shared;
using OpenVote.Shared.Organizations;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OpenVote
{
    public partial class App : Application
    {
        public static IList<IOrganization> Organizations = new List<IOrganization>
        {
            new Union() { Name = "<Union>"},
            new Village() { Name = "<Village>"},
            new City() { Name = "<City>"},
            new Goverment() { Name = "<Goverment>"},
            new Company() { Name = "<Company>"},
            new Country() { Name = "<Country>"},
            new Anonymous() { Name = "<Anonymous>"},
        };

        public Peer peer = new Peer();
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
