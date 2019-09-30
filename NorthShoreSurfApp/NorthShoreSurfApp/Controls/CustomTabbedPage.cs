using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NorthShoreSurfApp
{
    public class CustomTabbedPage : TabbedPage
    {
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            var list = Children.ToList();

            foreach (var page in list)
            {
                if (page is CustomNavigationPage)
                {
                    var navigationPage = page as CustomNavigationPage;

                    if (navigationPage.IconSelectedResource == null || navigationPage.IconUnselectedResource == null)
                        continue;
                    else if (page == CurrentPage)
                        page.IconImageSource = ((CustomNavigationPage)page).IconSelectedResource;
                    else
                        page.IconImageSource = ((CustomNavigationPage)page).IconUnselectedResource;
                }
            }
        }
    }
}
