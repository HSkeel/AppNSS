using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthShoreSurfApp
{
    // Cancel pressed trigger
    public class CustomDialogCancelPressedTriggerAction : TriggerAction<Button>
    {
        protected override void Invoke(Button button)
        {
            var parent = button.FindParentWithType<Grid>();
            var frame = parent.FindByName<Frame>("frameCancel");
            frame.BackgroundColor = (Color)App.Current.Resources["NSSBluePressed"];
        }
    }

    // Cancel pressed trigger
    public class CustomDialogCancelReleasedTriggerAction : TriggerAction<Button>
    {
        protected override void Invoke(Button button)
        {
            var parent = button.FindParentWithType<Grid>();
            var frame = parent.FindByName<Frame>("frameCancel");
            frame.BackgroundColor = (Color)App.Current.Resources["NSSBlue"];
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomDialog : Rg.Plugins.Popup.Pages.PopupPage
    {
        /*****************************************************************/
        // VARIABLES
        /*****************************************************************/
        #region Variables

        public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(CustomDialog), null);
        public event EventHandler Canceled;

        #endregion

        /*****************************************************************/
        // CONSTRUCTOR
        /*****************************************************************/
        #region Constructor

        public CustomDialog(string message) : this()
        {
            this.Message = message;
        }

        public CustomDialog()
        {
            InitializeComponent();

            // Background pressed
            var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tgr.Tapped += async (sender, args) =>
            {
                if (this.CloseWhenBackgroundIsClicked)
                    await PopupNavigation.Instance.PopAsync();
            };
            var views = new View[] { rlBackground, rlBackground2, rlBackground3, rlBackground4 };
            foreach (var view in views)
                view.GestureRecognizers.Add(tgr);

            button.Clicked += async (sender, args) =>
            {
                await PopupNavigation.Instance.PopAsync();
                Canceled?.Invoke(this, new EventArgs());
            };
        }

        #endregion

        /*****************************************************************/
        // PROPERTIES
        /*****************************************************************/
        #region Properties

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        #endregion
    }
}