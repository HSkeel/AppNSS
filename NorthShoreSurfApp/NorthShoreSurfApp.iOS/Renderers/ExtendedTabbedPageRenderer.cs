using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using NorthShoreSurfApp;
using NorthShoreSurfApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace NorthShoreSurfApp.iOS
{
    public class ExtendedTabbedPageRenderer : TabbedRenderer
    {
        protected override Task<Tuple<UIImage, UIImage>> GetIcon(Page page)
        {
            UIImage image;
            if (page.Title == "App")
            {
                image = UIImage.FromBundle((FileImageSource)page.IconImageSource).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
            else
            {
                image = UIImage.FromBundle((FileImageSource)page.IconImageSource).ImageWithRenderingMode(UIImageRenderingMode.Automatic);
            }

            return Task.FromResult(new Tuple<UIImage, UIImage>(image, image));
        }
    }
}