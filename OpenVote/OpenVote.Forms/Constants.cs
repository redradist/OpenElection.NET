using System.Runtime.Serialization;

namespace OpenVote
{
    public class Constants
    {
        public const string AppName = "Staffs.Mobile";
        public const double WelcomeShowTime = 3;

        #region FacebookSpecificConstants
        public const string FacebookClientId = "855321444832875";
        public const string FacebookUserInfoUrl = "https://graph.facebook.com/me?fields=id,name,picture,cover,birthday,email,hometown";
        public const string FacebookAuthorizeUrl = "https://m.facebook.com/dialog/oauth";
        public const string FacebookCustomRedirectUrl = "https://www.facebook.com/connect/login_success.html";
        #endregion

        #region GoogleSpecificConstants
        public const string GoogleClientId = "1029847892595-5rulqs59e50tq9h164bdqm3204j1vuko.apps.googleusercontent.com";
        public const string GoogleClientSecret = "Uis8QPAAvG17E5oLoe2JaFC1";
        public const string GoogleSignInScope = "profile email";
        public const string GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/v2/auth";
        public const string GoogleAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public const string GoogleCustomScheme = "com.googleusercontent.apps.1029847892595-5rulqs59e50tq9h164bdqm3204j1vuko";
        public const string GoogleCustomSchemePath = "/oauth2redirect";
        public const string GoogleCustomRedirectUrl = GoogleCustomScheme + ":" + GoogleCustomSchemePath;
        public const string GoogleUserInfoUrl = "https://www.googleapis.com/plus/v1/people/me";
        #endregion
    }
}
