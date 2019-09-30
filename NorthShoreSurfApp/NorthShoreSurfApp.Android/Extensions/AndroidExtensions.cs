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

namespace NorthShoreSurfApp.Droid.Extensions
{
    public static class AndroidExtensions
    {
        /// <summary>
        /// Convert from Xamarin color to Android color
        /// </summary>
        /// <param name="xfColor"></param>
        /// <returns></returns>
        public static Android.Graphics.Color ToAndroidColor(this Xamarin.Forms.Color xfColor)
        {
            return new Android.Graphics.Color(
                (byte)(xfColor.R * 255),
                (byte)(xfColor.G * 255),
                (byte)(xfColor.B * 255),
                (byte)(xfColor.A * 255));
        }
    }
}