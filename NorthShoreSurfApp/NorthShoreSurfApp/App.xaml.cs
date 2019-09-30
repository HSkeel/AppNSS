using NorthShoreSurfApp.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthShoreSurfApp
{
    public partial class App : Application
    {
        public static IFacebookService FacebookService { get; set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new RootTabbedPage();
        }

        public static void Init(IFacebookService facebookService)
        {
            FacebookService = facebookService;
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
