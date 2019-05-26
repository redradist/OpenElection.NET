using System;
using System.Diagnostics;
using System.Security;

using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;

using OpenVote.Shared.Social;

namespace OpenVote
{
    public class AuthenticationState
    {
        public static OAuth2Authenticator Authenticator;
    }
}

namespace OpenVote.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private static SecureString _twitterConsumerKey = new SecureString();
        private static SecureString _twitterConsumerSecret = new SecureString();
        private static SecureString _facebookAppId = new SecureString();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void SignUpButton_Clicked(object sender, EventArgs eventArgs)
        {
            await DisplayAlert("Alert", "SignUp Button Clicked !!", "OK");
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
            }
        }

        private async void GoogleLoginEntry_Tapped(object sender, EventArgs e)
        {
            var accounts = await AccountStore.Create().FindAccountsForServiceAsync(Constants.AppName);
            foreach (var account in accounts)
            {
                Debug.WriteLine($"account is {account}");
                Debug.WriteLine($"account.Username is {account.Username}");
                if (account.Properties.ContainsKey("Username"))
                {
                    Debug.WriteLine($"account.Properties[\"Username\"] is {account.Properties["Username"]}");
                }
                if (account.Properties.ContainsKey("Password"))
                {
                    Debug.WriteLine($"account.Properties[\"Password\"] is {account.Properties["Password"]}");
                }
            }

            // Check if user exists by checking in online
            var authenticator = new OAuth2Authenticator
            (
                // NOTE(redra): Id and Secret of General Client
                clientId: Constants.GoogleClientId,
                clientSecret: Constants.GoogleClientSecret,
                // NOTE(redra): Id and Secret of Web Client
                //clientId: "922608380000-m54i3f0mej2k6add0n42cshh2pov2a1a.apps.googleusercontent.com",
                //clientSecret: "kxtuIx8JKnB_rppzmUvuT9ZS",
                scope: Constants.GoogleSignInScope,
                authorizeUrl: new Uri(Constants.GoogleAuthorizeUrl),
                accessTokenUrl: new Uri(Constants.GoogleAccessTokenUrl),
                redirectUrl: new Uri(Constants.GoogleCustomRedirectUrl),
                isUsingNativeUI: true
            );
            authenticator.Completed += GoogleLogin_Complete;
            authenticator.Error += GoogleLogin_Error;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        private async void GoogleLogin_Complete(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= GoogleLogin_Complete;
                authenticator.Error -= GoogleLogin_Error;
            }

            if (eventArgs.IsAuthenticated)
            {
                Debug.WriteLine("Authentication completed succesfully !!");

                try
                {
                    var account = eventArgs.Account;
                    var request = new OAuth2Request(
                        "GET",
                        new Uri(Constants.GoogleUserInfoUrl),
                        null,
                        account);
                    var response = await request.GetResponseAsync();
                    string googleUserJson = response?.GetResponseText();
                    if (response != null && googleUserJson != null)
                    {
                        var googleUser = JsonConvert.DeserializeObject<Shared.Social.Google.User>(googleUserJson);
                        account.Username = googleUser.DisplayName;
                        account.Properties["Id"] = googleUser.Id;
                        account.Properties["Picture"] = googleUser.Image.Url.ToString();
                    }

                    if (!string.IsNullOrEmpty(account.Username))
                    {
                        await AccountStore.Create().SaveAsync(account, Constants.AppName);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Fail($"Exception was caught {ex.ToString()}");
                }
            }
            else
            {
                Debug.Fail("Authentication is failed !!");
            }
        }

        void GoogleLogin_Error(object sender, AuthenticatorErrorEventArgs eventArgs)
        {
            Debug.Fail($"Authentication error: {eventArgs.Message}");

            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= GoogleLogin_Complete;
                authenticator.Error -= GoogleLogin_Error;
            }
        }

        private async void FacebookLoginEntry_Tapped(object sender, EventArgs e)
        {
            var accounts = await AccountStore.Create().FindAccountsForServiceAsync(Constants.AppName);
            foreach (var account in accounts)
            {
                Debug.WriteLine($"account is {account}");
                Debug.WriteLine($"account.Username is {account.Username}");
                if (account.Properties.ContainsKey("Username"))
                {
                    Debug.WriteLine($"account.Properties[\"Username\"] is {account.Properties["Username"]}");
                }
                if (account.Properties.ContainsKey("Password"))
                {
                    Debug.WriteLine($"account.Properties[\"Password\"] is {account.Properties["Password"]}");
                }
            }

            // Check if user exists by checking in online
            var authenticator = new OAuth2Authenticator
            (
                clientId: "363833957743396",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")
            );
            authenticator.Completed += FacebookLogin_Complete;
            authenticator.Error += FacebookLogin_Error;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        private async void FacebookLogin_Complete(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= FacebookLogin_Complete;
                authenticator.Error -= FacebookLogin_Error;
            }

            if (eventArgs.IsAuthenticated)
            {
                Debug.WriteLine("Authentication completed succesfully !!");

                try
                {
                    var account = eventArgs.Account;

                    var request = new OAuth2Request(
                        "GET",
                        new Uri(Constants.FacebookUserInfoUrl),
                        null,
                        account);
                    var response = await request.GetResponseAsync();
                    string facebookUserJson = response?.GetResponseText();
                    if (response != null && facebookUserJson != null)
                    {
                        var facebookUser = JsonConvert.DeserializeObject<FacebookUser>(facebookUserJson);
                        account.Username = facebookUser.Name;
                        account.Properties["Id"] = facebookUser.Id;
                        account.Properties["Picture"] = facebookUser.Picture.Data.Url;
                    }

                    if (!string.IsNullOrEmpty(account.Username))
                    {
                        await AccountStore.Create().SaveAsync(account, Constants.AppName);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Fail($"Exception was caught {ex.ToString()}");
                }
            }
            else
            {
                Debug.Fail("Authentication is failed !!");
            }
        }

        void FacebookLogin_Error(object sender, AuthenticatorErrorEventArgs eventArgs)
        {
            Debug.Fail($"Authentication error: {eventArgs.Message}");

            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= FacebookLogin_Complete;
                authenticator.Error -= FacebookLogin_Error;
            }
        }
    }
}