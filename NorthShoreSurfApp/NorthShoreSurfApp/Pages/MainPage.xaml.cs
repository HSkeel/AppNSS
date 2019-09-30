using NorthShoreSurfApp.Service;
using NorthShoreSurfApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NorthShoreSurfApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage, IFacebookLoginCallback, IFacebookDataCallback
    {
        private MSWService mswService;

        public MainPage()
        {
            InitializeComponent();

            mswService = new MSWService();

            citBtnFacebookLogin.Button.Clicked += button_Clicked;
            btnFacebookLogout.Clicked += button_Clicked;
            //wvWebcam.Source = "http://stream.waves4you.com/flowstream.aspx?stream=ngrp:klitmoeller_all&vw=712";
        }

        protected override void OnAppearing()
        {
            //Task.Run(() =>
            //{
            //    var list = mswService.GetForecastAsync().Result;
            //
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        DisplayAlert("Hej", list.FirstOrDefault().Wind.CompassDirection, "Luk");
            //    });
            //});
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            if (sender == citBtnFacebookLogin.Button)
            {
                App.FacebookService.LogIn(this);
            }
            else if (sender == btnFacebookLogout)
            {
                App.FacebookService.LogOut();
            }
        }

        public void OnCancel()
        {
            
        }

        public void OnError(string error)
        {
            
        }

        public void OnSuccess(FacebookResult facebookResult)
        {
            
        }

        public void OnSuccess()
        {
            App.FacebookService.GetUserData(this);
        }

        public void OnDataReceivedError(string error)
        {
            
        }

        public void OnUserDataReceived(FacebookResult facebookResult)
        {
            DisplayAlert("Hej", facebookResult.Name, "Luk");
        }
    }
}
