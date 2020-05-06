using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItiClone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepositMoneyPage : TabbedPage
    {
        public DepositMoneyPage()
        {
            InitializeComponent();
        }

        private void EntryValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
                SetEntryBorderColor((Color)Application.Current.Resources["GradientStartColor"], (Color)Application.Current.Resources["GradientEndColor"]);
            else
                SetEntryBorderColor((Color)Application.Current.Resources["WindowBackground"], (Color)Application.Current.Resources["WindowBackground"]);
        }

        private void SetEntryBorderColor(Color startColor, Color endColor)
        {
            pvBorder.BackgroundGradientStartColor = startColor;
            pvBorder.BackgroundGradientEndColor = endColor;
        }
    }
}