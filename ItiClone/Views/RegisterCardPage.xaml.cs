using ItiClone.Events;
using ItiClone.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItiClone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCardPage : ContentPage
    {
        public RegisterCardPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ShowFrontCardEvent>(this, "showFrontCard", async (a) => await ShowFrontCard());
            MessagingCenter.Subscribe<ShowBackCardEvent>(this, "showBackCard", async (a) => await ShowBackCard());
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<ShowFrontCardEvent>(this, "showFrontCard");
            MessagingCenter.Unsubscribe<ShowBackCardEvent>(this, "showBackCard");
        }

        protected override bool OnBackButtonPressed()
        {
            if ((BindingContext as RegisterCardPageViewModel).CurrentStep > 1)
            {
                (BindingContext as RegisterCardPageViewModel).GoBackStepCommand.Execute(null);
                return true;
            }
            else
            {
                base.OnBackButtonPressed();
                return false;
            }
        }

        private async Task ShowFrontCard()
        {
            await flBackCard.FadeTo(0, 250);
            await frCard.RotateYTo(0, 500);
            await flBackCard.RotateYTo(0, 0);
            await flFrontCard.FadeTo(1, 250);
        }

        private async Task ShowBackCard()
        {
            await flFrontCard.FadeTo(0, 250);
            await frCard.RotateYTo(-180, 500);
            await flBackCard.RotateYTo(-180, 0);
            await flBackCard.FadeTo(1, 250);
        }
    }
}