using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using NorthShoreSurfApp;
using NorthShoreSurfApp.Droid;
using NorthShoreSurfApp.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

//[assembly: ExportRenderer(typeof(ExtendedTabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace NorthShoreSurfApp.Droid
{
    public class ExtendedTabbedPageRenderer : TabbedPageRenderer
    {
        private Xamarin.Forms.TabbedPage tabbedPage;
        private BottomNavigationView bottomNavigationView;
        private IMenuItem lastItemSelected;

        public ExtendedTabbedPageRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                tabbedPage = e.NewElement as CustomTabbedPage;
                bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
                bottomNavigationView.NavigationItemSelected += BottomNavigationView_NavigationItemSelected;
            }

            if (e.OldElement != null)
            {
                bottomNavigationView.NavigationItemSelected -= BottomNavigationView_NavigationItemSelected;
            }

        }

        //Remove tint color
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (bottomNavigationView != null)
            {
                bottomNavigationView.ItemIconTintList = null;
            }
        }

        void BottomNavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            
            var normalColor = tabbedPage.UnselectedTabColor;
            var selectedColor = tabbedPage.SelectedTabColor;

            if (lastItemSelected != null)
            {
                lastItemSelected.Icon.SetColorFilter(normalColor.ToAndroidColor(), PorterDuff.Mode.SrcIn);
            }

            if ($"{e.Item}" != "App")
            {
                //e.Item.Icon.SetColorFilter(selectedColor.ToAndroidColor(), PorterDuff.Mode.SrcIn);
                //lastItemSelected = e.Item;
            }
            this.OnNavigationItemSelected(e.Item);
        }
    }
}