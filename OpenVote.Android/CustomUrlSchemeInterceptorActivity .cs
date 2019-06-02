using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

using OpenVote;
using OpenVote.Android;
using OpenVote.Forms;

namespace OpenVote.Android
{
    [Activity(Label = "CustomUrlSchemeInterceptorActivity",
              NoHistory = true,
              LaunchMode = LaunchMode.SingleTask)]
    [IntentFilter(new[] { Intent.ActionView },
                  Categories = new[] {
                      Intent.CategoryDefault,
                      Intent.CategoryBrowsable
                  },
                  DataSchemes = new[] {
                      Constants.GoogleCustomScheme
                  },
                  DataPath = Constants.GoogleCustomSchemePath)]
    public class CustomUrlSchemeInterceptorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Convert Android.Net.Url to Uri
            var uri = new Uri(Intent.Data.ToString());

            // Load redirectUrl page
            AuthenticationState.Authenticator.OnPageLoading(uri);

            var intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            StartActivity(intent);

            Finish();
        }
    }
}