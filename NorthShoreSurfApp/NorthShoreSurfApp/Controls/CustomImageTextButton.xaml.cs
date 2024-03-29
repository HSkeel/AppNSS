﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthShoreSurfApp
{
    // Button pressed trigger
    public class CustomButtonImageTextPressedTriggerAction : TriggerAction<Button>
    {
        protected override void Invoke(Button button)
        {
            var parent = button.FindParentWithType<CustomImageTextButton>();
            var frame = parent.FindByName<Frame>("frame");
            frame.BackgroundColor = parent.BackgroundPressed;
        }
    }

    // Button released trigger
    public class CustomButtonImageTextReleasedTriggerAction : TriggerAction<Button>
    {
        protected override void Invoke(Button button)
        {
            var parent = button.FindParentWithType<CustomImageTextButton>();
            var frame = parent.FindByName<Frame>("frame");
            frame.BackgroundColor = parent.Background;
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomImageTextButton : ContentView
    {
        /*****************************************************************/
        // VARIABLES
        /*****************************************************************/
        #region Variables

        public static readonly BindableProperty BackgroundPressedProperty = BindableProperty.Create(nameof(BackgroundPressed), typeof(Color), typeof(CustomImageTextButton), null);
        public static readonly BindableProperty BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(Color), typeof(CustomImageTextButton), null);
        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(CustomImageTextButton), null);
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(CustomImageTextButton), null);
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CustomImageTextButton), null);
        public static readonly BindableProperty TitleColorProperty = BindableProperty.Create(nameof(TitleColor), typeof(Color), typeof(CustomImageTextButton), null);

        #endregion

        /*****************************************************************/
        // CONSTRUCTOR
        /*****************************************************************/
        #region Constructor

        public CustomImageTextButton()
        {
            InitializeComponent();
        }

        #endregion

        /*****************************************************************/
        // PROPERTIES
        /*****************************************************************/
        #region Properties

        public Color BackgroundPressed
        {
            get { return (Color)GetValue(BackgroundPressedProperty); }
            set { SetValue(BackgroundPressedProperty, value); }
        }
        public Color Background
        {
            get { return (Color)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public Color TitleColor
        {
            get { return (Color)GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }

        public Button Button { get => button; }
        public Image Image { get => image; }
        public Label Label { get => label; }

        #endregion
    }
}