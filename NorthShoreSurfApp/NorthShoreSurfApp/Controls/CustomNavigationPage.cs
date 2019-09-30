using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NorthShoreSurfApp
{
    public class CustomNavigationPage : NavigationPage
    {
        public static readonly BindableProperty IconSelectedProperty = BindableProperty.Create("IconSelectedResource", typeof(string), typeof(CustomNavigationPage), null);
        public static readonly BindableProperty IconUnselectedProperty = BindableProperty.Create("IconUnselectedResource", typeof(string), typeof(CustomNavigationPage), null);

        public string IconSelectedResource
        {
            get { return (string)GetValue(IconSelectedProperty); }
            set { SetValue(IconSelectedProperty, value); }
        }

        public string IconUnselectedResource
        {
            get { return (string)GetValue(IconUnselectedProperty); }
            set { SetValue(IconUnselectedProperty, value); }
        }

        private void Init()
        {
            BarBackgroundColor = Color.FromHex("F0F0F0");
            BarTextColor = Color.Black;
        }

        public CustomNavigationPage(Page page) : base(page)
        {
            Init();
        }

        public CustomNavigationPage() : base()
        {
            Init();
        }

    }
}
