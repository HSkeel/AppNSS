using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
using Newtonsoft.Json;
using NorthShoreSurfApp.Service;
using UIKit;

namespace NorthShoreSurfApp.iOS.Services
{
    public class IOSFacebookService : IFacebookService
    {
        #region Properties

        public bool LoggedIn => AccessToken.CurrentAccessToken != null;
        public UIViewController ViewController { get; set; }
        public FacebookResult FacebookResult { get; set; }
        public IFacebookLoginCallback FacebookLoginCallback { get; set; }
        public IFacebookDataCallback FacebookDataCallback { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Login to facebook
        /// </summary>
        /// <param name="callback"></param>
        public void LogIn(IFacebookLoginCallback callback)
        {
            this.FacebookLoginCallback = callback;

            new LoginManager().LogIn(FacebookService.Permissions, null, (result, error) =>
            {
                if (result.IsCancelled)
                {
                    FacebookLoginCallback.OnCancel();
                }
                else if (error != null)
                {
                    FacebookLoginCallback.OnError(error.ToString());
                }
                else
                {
                    FacebookLoginCallback.OnSuccess();
                }
            });
        }

        /// <summary>
        /// Log out from facebook
        /// </summary>
        public void LogOut()
        {
            new LoginManager().LogOut();
        }

        /// <summary>
        /// Get user data from facebook
        /// </summary>
        /// <param name="callback"></param>
        public void GetUserData(IFacebookDataCallback callback)
        {
            this.FacebookDataCallback = callback;

            var accessToken = AccessToken.CurrentAccessToken;

            FacebookResult = new FacebookResult();
            FacebookResult.Token = accessToken.TokenString;

            NSMutableDictionary keyValues = new NSMutableDictionary();
            keyValues.Add(new NSString("fields"), new NSString(FacebookService.Fields));

            GraphRequest graphRequest = new GraphRequest("me", keyValues, AccessToken.CurrentAccessToken.TokenString, null, HttpMethod.Get);
            GraphRequestConnection graphRequestConnection = new GraphRequestConnection();
            graphRequestConnection.AddRequest(graphRequest, (connection, result, error) =>
            {
                if (error != null)
                {
                    FacebookDataCallback.OnDataReceivedError(error.ToString());
                    return;
                }

                JsonConvert.PopulateObject(result.ToString(), FacebookResult);
                FacebookDataCallback.OnUserDataReceived(FacebookResult);
            });
        }

        #endregion

    }
}