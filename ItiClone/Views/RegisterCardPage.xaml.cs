using ItiClone.Events;
using ItiClone.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItiClone.Views
{
    public enum ColorEnum
    {
        White,
        Orange,
        Blue,
        Black
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCardPage : ContentPage
    {
        private ColorEnum _lastColorSelected;
        private readonly uint _durationSelectColor = 100;
        private readonly double _scaleToSelected = 1.3;
        private readonly float _borderThicknessSelected = 3;
        private readonly double _scaleToDeselected = 1;
        private readonly float _borderThicknessDeselected = 0;

        public RegisterCardPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await SelectColor(ColorEnum.White, true);

            MessagingCenter.Subscribe<ShowFrontCardEvent>(this, "showFrontCard", async (a) => await ShowFrontCard());
            MessagingCenter.Subscribe<ShowBackCardEvent>(this, "showBackCard", async (a) => await ShowBackCard(a.SetInitialColor));
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

        private async void PvWhiteCardColor_Tapped(object sender, System.EventArgs e) => await SelectColor(ColorEnum.White);

        private async void PvOrangeCardColor_Tapped(object sender, System.EventArgs e) => await SelectColor(ColorEnum.Orange);

        private async void PvBlueCardColor_Tapped(object sender, System.EventArgs e) => await SelectColor(ColorEnum.Blue);

        private async void PvBlackCardColor_Tapped(object sender, System.EventArgs e) => await SelectColor(ColorEnum.Black);

        private async Task DeselectColor()
        {
            switch (_lastColorSelected)
            {
                case ColorEnum.White:
                    pvWhiteCardColor.BorderThickness = _borderThicknessDeselected;
                    await pvWhiteContentCardColor.ScaleTo(_scaleToDeselected, _durationSelectColor);
                    break;
                case ColorEnum.Orange:
                    pvOrangeCardColor.BorderThickness = _borderThicknessDeselected;
                    await pvOrangeContentCardColor.ScaleTo(_scaleToDeselected, _durationSelectColor);
                    break;
                case ColorEnum.Blue:
                    pvBlueCardColor.BorderThickness = _borderThicknessDeselected;
                    await pvBlueContentCardColor.ScaleTo(_scaleToDeselected, _durationSelectColor);
                    break;
                case ColorEnum.Black:
                    pvBlackCardColor.BorderThickness = _borderThicknessDeselected;
                    await pvBlackContentCardColor.ScaleTo(_scaleToDeselected, _durationSelectColor);
                    break;
            }
        }

        private async Task ShowFrontCard()
        {
            await flBackCard.FadeTo(0, 250);
            await frCard.RotateYTo(0, 500);
            await flBackCard.RotateYTo(0, 0);
            await flFrontCard.FadeTo(1, 250);
        }

        private async Task ShowBackCard(bool setInitialColor)
        {
            if (setInitialColor)
                await SelectColor(ColorEnum.White, changeStepColor: false);

            await flFrontCard.FadeTo(0, 250);
            await frCard.RotateYTo(-180, 500);
            await flBackCard.RotateYTo(-180, 0);
            await flBackCard.FadeTo(1, 250);
        }

        private async Task SelectColor(ColorEnum color, bool isInitial = false, bool changeStepColor = true)
        {
            if (color == _lastColorSelected)
                return;

            switch (color)
            {
                case ColorEnum.White:
                    await pvWhiteContentCardColor.ScaleTo(_scaleToSelected, _durationSelectColor);
                    pvWhiteCardColor.BorderThickness = _borderThicknessSelected;
                    SetCardColor(pvWhiteContentCardColor.BackgroundGradientStartColor, pvWhiteContentCardColor.BackgroundGradientEndColor);
                    break;
                case ColorEnum.Orange:
                    await pvOrangeContentCardColor.ScaleTo(_scaleToSelected, _durationSelectColor);
                    pvOrangeCardColor.BorderThickness = _borderThicknessSelected;
                    SetCardColor(pvOrangeContentCardColor.BackgroundGradientStartColor, pvOrangeContentCardColor.BackgroundGradientEndColor);
                    break;
                case ColorEnum.Blue:
                    await pvBlueContentCardColor.ScaleTo(_scaleToSelected, _durationSelectColor);
                    pvBlueCardColor.BorderThickness = _borderThicknessSelected;
                    SetCardColor(pvBlueContentCardColor.BackgroundGradientStartColor, pvBlueContentCardColor.BackgroundGradientEndColor);
                    break;
                case ColorEnum.Black:
                    await pvBlackContentCardColor.ScaleTo(_scaleToSelected, _durationSelectColor);
                    pvBlackCardColor.BorderThickness = _borderThicknessSelected;
                    SetCardColor(pvBlackContentCardColor.BackgroundGradientStartColor, pvBlackContentCardColor.BackgroundGradientEndColor);
                    break;
            }

            if (!isInitial)
            {
                SetCardSinImage(color != ColorEnum.White);

                if (changeStepColor)
                    (BindingContext as RegisterCardPageViewModel).ChangeStepColorCommand.Execute(color == ColorEnum.White ? "#6B6B6B" : "#FFFFFF");

                await DeselectColor();
            }

            _lastColorSelected = color;
        }

        private void SetCardColor(Color startColor, Color endColor, int angle = 310)
        {
            pvCard.BackgroundGradientAngle = angle;
            pvCard.BackgroundGradientStartColor = startColor;
            pvCard.BackgroundGradientEndColor = endColor;
        }

        private void SetCardSinImage(bool whiteIcon)
        {
            sinCardImage.Source = whiteIcon ? "sincardiconwhite" : "sincardiconorange";
        }
    }
}