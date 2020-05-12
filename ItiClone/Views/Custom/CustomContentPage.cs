using System;
using Xamarin.Forms;

namespace ItiClone.Views.Custom
{
    public class CustomContentPage : ContentPage
    {
        public Action CustomBackButtonAction { get; set; }

        public static readonly BindableProperty EnableBackButtonOverrideProperty = BindableProperty.Create(
               nameof(EnableBackButtonOverride),
               typeof(bool),
               typeof(CustomContentPage),
               false);

        public bool EnableBackButtonOverride
        {
            get => (bool)GetValue(EnableBackButtonOverrideProperty);
            set => SetValue(EnableBackButtonOverrideProperty, value);
        }
    }
}