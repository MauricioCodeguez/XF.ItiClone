using ItiClone.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ItiClone.ViewModels
{
    public class RegisterCardPageViewModel : BaseViewModel
    {
        private readonly int _totalSteps = 6;

        private string _nickNameCard;
        public string NickNameCard
        {
            get { return _nickNameCard; }
            set { SetProperty(ref _nickNameCard, value); }
        }

        private string _cardNumber;
        public string CardNumber
        {
            get { return _cardNumber; }
            set { SetProperty(ref _cardNumber, value); }
        }

        private string _cardName;
        public string CardName
        {
            get { return _cardName; }
            set { SetProperty(ref _cardName, value); }
        }

        private string _validateCard;
        public string ValidateCard
        {
            get { return _validateCard; }
            set { SetProperty(ref _validateCard, value); }
        }

        private string _cvv;
        public string CVV
        {
            get { return _cvv; }
            set { SetProperty(ref _cvv, value); }
        }

        private int _currentStep;
        public int CurrentStep
        {
            get { return _currentStep; }
            set { SetProperty(ref _currentStep, value); }
        }

        public ICommand NextStepCommand { get; private set; }
        public ICommand GoBackStepCommand { get; private set; }

        public RegisterCardPageViewModel()
        {
            Title = "cadastrar cartão";
            _currentStep = 1;
            _nickNameCard = "apelido do cartão";
            _cardNumber = "XXXX XXXX XXXX XXXX";
            _cardName = "NOME IMPRESSO";
            _validateCard = "MM / AA";
            _cvv = "CVV";
            NextStepCommand = new Command(NextStepCommandExecute);
            GoBackStepCommand = new Command(GoBackStepCommandExecute);
        }

        private void NextStepCommandExecute()
        {
            if (CurrentStep == _totalSteps)
                SaveCard();
            else
            {
                CurrentStep++;

                if (CurrentStep == 5)
                    MessagingCenter.Send(new ShowBackCardEvent(), "showBackCard");
            }
        }

        private void GoBackStepCommandExecute()
        {
            CurrentStep--;

            if (CurrentStep == 4)
                MessagingCenter.Send(new ShowFrontCardEvent(), "showFrontCard");
        }

        private void SaveCard() { }
    }
}