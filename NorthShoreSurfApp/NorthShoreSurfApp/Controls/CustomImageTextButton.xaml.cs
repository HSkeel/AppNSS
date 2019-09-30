using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthShoreSurfApp
{
    public class CustomButtonImageTextPressedTriggerAction : TriggerAction<Button>
    {
        protected override void Invoke(Button button)
        {
            var parent = button.Parent;
            var frame = parent.FindByName<Frame>("frame");
            frame.BackgroundColor = Color.FromHex("0067B0");
        }
    }

    public class CustomButtonImageTextReleasedTriggerAction : TriggerAction<Button>
    {
        protected override void Invoke(Button button)
        {
            var parent = button.Parent;
            var frame = parent.FindByName<Frame>("frame");
            frame.BackgroundColor = Color.FromHex("3C5A99");
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomImageTextButton : ContentView
    {
        public CustomImageTextButton()
        {
            InitializeComponent();
            
        }

        public Button Button { get => button; }
    }
}