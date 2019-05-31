using Android.App;
using Android.Content.PM;
using Android.OS;
using OpenVote.Forms;
using Xamarin.Auth;

namespace OpenVote.Android
{
    [Activity(Label = "OpenVote",
              Icon = "@mipmap/icon",
              Theme = "@style/MainTheme",
              MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            // NOTE(redra): Experimental feature with FastRenderers
            //global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, savedInstanceState);
            CustomTabsConfiguration.CustomTabsClosingMessage = null;
            LoadApplication(new App());
        }
    }
}