using ItiClone.Events;
using ItiClone.Services.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ItiClone.ViewModels
{
    public class RegisterCardPageViewModel : BaseViewModel
    {
        private readonly int _totalSteps = 7;

        private string _nickNameCard;
        public string NickNameCard
        {
            get { return _nickNameCard; }
            set { SetProperty(ref _nickNameCard, value); }
        }

        private string _nickName;
        public string Nickname
        {
            get { return _nickName; }
            set
            {
                SetProperty(ref _nickName, value, onChanged: () =>
                {
                    NickNameCard = _nickName.Length == 0 ? "apelido do cartão" : _nickName;
                    NicknameCanNavigate();
                });
            }
        }

        private string _cardNumber;
        public string CardNumber
        {
            get { return _cardNumber; }
            set { SetProperty(ref _cardNumber, value); }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                SetProperty(ref _number, value, onChanged: () =>
                {
                    CardNumber = _number.Length == 0 ? "XXXX XXXX XXXX XXXX" : _number;
                    NumberCanNavigate();
                });
            }
        }

        private string _cardName;
        public string CardName
        {
            get { return _cardName; }
            set { SetProperty(ref _cardName, value); }
        }

        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value, onChanged: () =>
                {
                    CardName = _name.Length == 0 ? "NOME IMPRESSO" : _name;
                    NameCanNavigate();
                });
            }
        }

        private string _validateCard;
        public string ValidateCard
        {
            get { return _validateCard; }
            set { SetProperty(ref _validateCard, value); }
        }

        private string _validate;
        public string Validate
        {
            get { return _validate; }
            set
            {
                SetProperty(ref _validate, value, onChanged: () =>
                {
                    ValidateCard = _validate.Length == 0 ? "MM / AA" : _validate;
                    ValidateCanNavigate();
                });
            }
        }

        private string _cvvCard;
        public string CVVCard
        {
            get { return _cvvCard; }
            set { SetProperty(ref _cvvCard, value); }
        }

        private string _cvv;
        public string CVV
        {
            get { return _cvv; }
            set
            {
                SetProperty(ref _cvv, value, onChanged: () =>
                {
                    CVVCard = _cvv.Length == 0 ? "CVV" : _cvv;
                    CVVCanNavigate();
                });
            }
        }

        private int _currentStep;
        public int CurrentStep
        {
            get { return _currentStep; }
            set
            {
                SetProperty(ref _currentStep, value, onChanged: () =>
                {
                    OnPropertyChanged(nameof(LastStepVisible));

                    if (!LastStepVisible)
                        OnPropertyChanged(nameof(ChangeCardColorVisible));
                });
            }
        }

        private string _cpfCnpj;
        public string CpfCnpj
        {
            get { return _cpfCnpj; }
            set { SetProperty(ref _cpfCnpj, value, onChanged: () => { CPFCNPJCanNavigate(); }); }
        }

        private bool _canNavigateNextStep;
        public bool CanNavigateNextStep
        {
            get { return _canNavigateNextStep; }
            set { SetProperty(ref _canNavigateNextStep, value); }
        }

        public bool ChangeCardColorVisible { get => CurrentStep == 6; }

        public bool LastStepVisible { get => CurrentStep == 7; }

        #region [ Steps ]

        private bool _step1Visible;
        public bool Step1Visible
        {
            get { return _step1Visible; }
            set { SetProperty(ref _step1Visible, value); }
        }

        private bool _step2Visible;
        public bool Step2Visible
        {
            get { return _step2Visible; }
            set { SetProperty(ref _step2Visible, value); }
        }

        private bool _step3Visible;
        public bool Step3Visible
        {
            get { return _step3Visible; }
            set { SetProperty(ref _step3Visible, value); }
        }

        private bool _step4Visible;
        public bool Step4Visible
        {
            get { return _step4Visible; }
            set { SetProperty(ref _step4Visible, value); }
        }

        private bool _step5Visible;
        public bool Step5Visible
        {
            get { return _step5Visible; }
            set { SetProperty(ref _step5Visible, value); }
        }

        private Color _step1Color;
        public Color Step1Color
        {
            get { return _step1Color; }
            set { SetProperty(ref _step1Color, value); }
        }

        private Color _step2Color;
        public Color Step2Color
        {
            get { return _step2Color; }
            set { SetProperty(ref _step2Color, value); }
        }

        private Color _step3Color;
        public Color Step3Color
        {
            get { return _step3Color; }
            set { SetProperty(ref _step3Color, value); }
        }

        private Color _step4Color;
        public Color Step4Color
        {
            get { return _step4Color; }
            set { SetProperty(ref _step4Color, value); }
        }

        private Color _step5Color;
        public Color Step5Color
        {
            get { return _step5Color; }
            set { SetProperty(ref _step5Color, value); }
        }

        #endregion

        public ICommand NextStepCommand { get; private set; }
        public ICommand GoBackStepCommand { get; private set; }
        public ICommand ChangeStepColorCommand { get; private set; }

        public RegisterCardPageViewModel()
        {
            Title = "cadastrar cartão";
            _currentStep = 1;
            _nickNameCard = "apelido do cartão";
            _cardNumber = "XXXX XXXX XXXX XXXX";
            _cardName = "NOME IMPRESSO";
            _validateCard = "MM / AA";
            _cvvCard = "CVV";
            _canNavigateNextStep = false;
            ChangeStepVisibily();
            NextStepCommand = new Command(async () => await NextStepCommandExecute(), () => CanNavigateNextStep);
            GoBackStepCommand = new Command(GoBackStepCommandExecute);
            ChangeStepColorCommand = new Command<string>((c) => ChangeStepColor(c));
        }

        public override Task InitializeAsync(object[] args)
        {
            ChangeStepColorCommand.Execute(null);
            return Task.CompletedTask;
        }

        private async Task NextStepCommandExecute()
        {
            CanNavigateNextStep = false;

            if (CurrentStep == _totalSteps)
                await SaveCard();
            else
            {
                CurrentStep++;

                ChangeStepVisibily();
                ChangeStepColor();
                StepCanNavigate();

                if (CurrentStep == 4 && string.IsNullOrEmpty(Nickname))
                    Nickname = $"Cartão - final {Number.Substring(Number.Length - 4, 4)}";

                if (CurrentStep == 5)
                    MessagingCenter.Send(new ShowBackCardEvent(), "showBackCard");
                else if (CurrentStep == 6)
                    MessagingCenter.Send(new ShowFrontCardEvent(), "showFrontCard");
            }
        }

        private void GoBackStepCommandExecute()
        {
            CurrentStep--;

            ChangeStepVisibily();
            ChangeStepColor();
            StepCanNavigate();

            if (CurrentStep == 4)
                MessagingCenter.Send(new ShowFrontCardEvent(), "showFrontCard");
            else if (CurrentStep == 5)
                MessagingCenter.Send(new ShowBackCardEvent() { SetInitialColor = true }, "showBackCard");
        }

        private void ChangeStepVisibily()
        {
            Step1Visible = CurrentStep == 1 ? true : false;
            Step2Visible = CurrentStep == 2 ? true : false;
            Step3Visible = CurrentStep == 3 ? true : false;
            Step4Visible = CurrentStep == 4 ? true : false;
            Step5Visible = CurrentStep == 5 ? true : false;
        }

        private void ChangeStepColor(string color = "")
        {
            if (CurrentStep > 5)
            {
                Color textColorCard = Color.FromHex(color);

                Step1Color = textColorCard;
                Step2Color = textColorCard;
                Step3Color = textColorCard;
                Step4Color = textColorCard;
                Step5Color = textColorCard;
            }
            else
            {
                Step1Color = CurrentStep == 1 ? (Color)Application.Current.Resources["TextColorOrange"] : Color.FromHex("#DCDCDC");
                Step2Color = CurrentStep == 2 ? (Color)Application.Current.Resources["TextColorOrange"] : Color.FromHex("#DCDCDC");
                Step3Color = CurrentStep == 3 ? (Color)Application.Current.Resources["TextColorOrange"] : Color.FromHex("#DCDCDC");
                Step4Color = CurrentStep == 4 ? (Color)Application.Current.Resources["TextColorOrange"] : Color.FromHex("#DCDCDC");
                Step5Color = CurrentStep == 5 ? (Color)Application.Current.Resources["TextColorOrange"] : Color.FromHex("#DCDCDC");
            }
        }

        private void NumberCanNavigate() => CanNavigateNextStep = Number != null && Number.Length > 0;

        private void NicknameCanNavigate() => CanNavigateNextStep = Nickname != null && Nickname.Length > 0;

        private void NameCanNavigate() => CanNavigateNextStep = Name != null && Name.Length > 0;

        private void ValidateCanNavigate() => CanNavigateNextStep = Validate != null && Validate.Replace("/", "").Length == 4;

        private void CVVCanNavigate() => CanNavigateNextStep = CVV != null && CVV.Length == 3;

        private void CPFCNPJCanNavigate() => CanNavigateNextStep = CpfCnpj != null && CpfCnpj.Length > 0;

        private void StepCanNavigate()
        {
            if (CurrentStep == 1)
                NumberCanNavigate();
            else if (CurrentStep == 2)
                ValidateCanNavigate();
            else if (CurrentStep == 3)
                NameCanNavigate();
            else if (CurrentStep == 4)
                NicknameCanNavigate();
            else if (CurrentStep == 5 || CurrentStep == 6)
                CVVCanNavigate();
            else
                CPFCNPJCanNavigate();
        }

        private async Task SaveCard() 
        {
            await NavigationService.Current.PopAsync();
        }
    }
}