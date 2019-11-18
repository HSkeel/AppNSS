using NorthShoreSurfApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthShoreSurfApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpUserPage : ContentPage
    {
        public SignUpUserModel SignUpUserModel { get => (SignUpUserModel)this.BindingContext; }

        public SignUpUserPage()
        {
            InitializeComponent();
            SignUpUserModel.FirstName = "Jakob";
            btnNext.Button.Clicked += Button_Clicked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender == btnNext.Button)
            {
                var model = SignUpUserModel;
                CustomDialog customDialog = new CustomDialog("Henter data.\nVent venligst...");
                customDialog.Canceled += (sender, args) =>
                {

                };
                PopupNavigation.Instance.PushAsync(customDialog, true);
            }
        }
    }
}