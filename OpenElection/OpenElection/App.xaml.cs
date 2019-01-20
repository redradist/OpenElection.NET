using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OpenElection.Views;
using System.Collections.Generic;
using OpenElection.Shared;
using OpenElection.Shared.Organizations;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OpenElection
{
    public partial class App : Application
    {
        static public IList<IOrganization> Organizations = new List<IOrganization>
        {
            new Union() { Name = "<Union>"},
            new Village() { Name = "<Village>"},
            new City() { Name = "<City>"},
            new Goverment() { Name = "<Goverment>"},
            new Company() { Name = "<Company>"},
            new Country() { Name = "<Country>"},
            new Anonymous() { Name = "<Anonymous>"},
        };

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
