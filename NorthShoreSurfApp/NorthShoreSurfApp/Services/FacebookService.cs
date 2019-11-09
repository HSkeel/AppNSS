using System;
using System.Collections.Generic;
using System.Text;

namespace NorthShoreSurfApp
{
    public interface IFacebookService
    {
        void LogIn(IFacebookLoginCallback callback);
        void LogOut();
        void GetUserData(IFacebookDataCallback callback);
        bool LoggedIn { get; }
    }

    public interface IFacebookLoginCallback
    {
        void OnCancel();
        void OnError(String error);
        void OnSuccess();
    }

    public interface IFacebookDataCallback
    {
        void OnDataReceivedError(String error);
        void OnUserDataReceived(FacebookResult facebookResult);
    }

    public class FacebookResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }

    public class FacebookService
    {
        public static string[] Permissions { get => new string[] { "public_profile", "email" }; }
        public static string Fields { get => "id,name,email"; }

    }
}
