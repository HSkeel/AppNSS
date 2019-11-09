using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Newtonsoft.Json;
using NorthShoreSurfApp.Droid.Service;
using Org.Json;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

namespace NorthShoreSurfApp.Droid.Service
{
    public class AndroidFacebookService : Java.Lang.Object, IFacebookService, IFacebookCallback, GraphRequest.IGraphJSONObjectCallback
    {
        /*****************************************************************/
        // PROPERTIES
        /*****************************************************************/
        #region Properties

        private Activity Activity { get; set; }
        public ICallbackManager CallbackManager { get; set; }
        private FacebookResult FacebookResult { get; set; }

        public bool LoggedIn => AccessToken.CurrentAccessToken != null;

        public IFacebookLoginCallback FacebookLoginCallback { get; set; }
        public IFacebookDataCallback FacebookDataCallback { get; set; }

        #endregion

        /*****************************************************************/
        // CONSTRUCTOR
        /*****************************************************************/
        #region Constructor

        public AndroidFacebookService()
        {
            Activity = MainActivity.Instance;
            // Create callback manager using CallbackManagerFactory
            CallbackManager = CallbackManagerFactory.Create();
            LoginManager.Instance.RegisterCallback(CallbackManager, this);
        }

        #endregion

        /*****************************************************************/
        // METHODS
        /*****************************************************************/
        #region Methods

        /// <summary>
        /// Log into facebook
        /// </summary>
        /// <param name="callback"></param>
        public void LogIn(IFacebookLoginCallback callback)
        {
            FacebookLoginCallback = callback;
            if (!LoggedIn)
                LoginManager.Instance.LogInWithReadPermissions(Activity, FacebookService.Permissions);
            else
                FacebookLoginCallback.OnSuccess();
        }

        /// <summary>
        /// Log out from facebook
        /// </summary>
        public void LogOut()
        {
            LoginManager.Instance.LogOut();
        }

        /// <summary>
        /// Get user data from facebook
        /// </summary>
        /// <param name="callback"></param>
        public void GetUserData(IFacebookDataCallback callback)
        {
            FacebookDataCallback = callback;

            AccessToken accessToken = AccessToken.CurrentAccessToken;

            FacebookResult = new FacebookResult();
            FacebookResult.Token = accessToken.Token;

            Bundle parameters = new Bundle();
            parameters.PutString("fields", FacebookService.Fields);

            GraphRequest graphRequest = GraphRequest.NewMeRequest(accessToken, this);
            graphRequest.Parameters = parameters;
            graphRequest.ExecuteAsync();
        }

        #endregion

        /*****************************************************************/
        // INTERFACE METHODS
        /*****************************************************************/
        #region Interface methods

        /// <summary>
        /// Facebook login has been cancelled
        /// </summary>
        public void OnCancel()
        {
            FacebookLoginCallback.OnCancel();
        }

        /// <summary>
        /// Error when logging in with facebook
        /// </summary>
        /// <param name="error">String error message</param>
        public void OnError(FacebookException error)
        {
            FacebookLoginCallback.OnError(error.Message);
        }

        /// <summary>
        /// Success when logging in with facebook
        /// </summary>
        /// <param name="result">Login result</param>
        public void OnSuccess(Java.Lang.Object result)
        {
            FacebookLoginCallback.OnSuccess();
        }

        /// <summary>
        /// Has got user data from facebook
        /// </summary>
        /// <param name="object">JSON data object</param>
        /// <param name="response">Response</param>
        public void OnCompleted(JSONObject @object, GraphResponse response)
        {
            if (@object != null)
                JsonConvert.PopulateObject(@object.ToString(), FacebookResult);
            FacebookDataCallback?.OnUserDataReceived(FacebookResult);
        }

        #endregion
    }
}