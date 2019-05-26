using System.Runtime.Serialization;

namespace OpenVote
{
    public class Constants
    {
        public const string AppName = "OpenVote.Mobile";

        #region FacebookSpecificConstants
        public const string FacebookUserInfoUrl = "https://graph.facebook.com/me?fields=id,name,picture,cover,birthday,email,hometown";
        #endregion

        #region GoogleSpecificConstants
        public const string GoogleClientId = "922608380000-rrn32dq4r6lputju598l4aub184geur1.apps.googleusercontent.com";
        public const string GoogleClientSecret = "OlpvvPNIFQDxWTMRoP2NwyI2";
        public const string GoogleSignInScope = "profile email";
        public const string GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/v2/auth";
        public const string GoogleAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public const string GoogleCustomScheme = "com.googleusercontent.apps.922608380000-rrn32dq4r6lputju598l4aub184geur1";
        public const string GoogleCustomSchemePath = "/oauth2redirect";
        public const string GoogleCustomRedirectUrl = GoogleCustomScheme + ":" + GoogleCustomSchemePath;
        public const string GoogleUserInfoUrl = "https://www.googleapis.com/plus/v1/people/me";
        #endregion
    }
}
