using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ItiClone.ViewModels
{
    public class DepositMoneyPageViewModel : BaseViewModel
    {
        private decimal? _lastValue;

        private decimal? _value;
        public decimal? Value
        {
            get { return _value; }
            set
            {
                SetProperty(ref _value, value, onChanged: () =>
                {
                    CanCreateBarCode();

                    if (!_value.HasValue || _value < MaxValue)
                        _lastValue = _value;
                    else
                        Value = _lastValue;
                });
            }
        }

        private bool _canContinue;
        public bool CanContinue
        {
            get { return _canContinue; }
            set { SetProperty(ref _canContinue, value); }
        }

        public string PlaceHolder { get => Convert.ToDecimal(0).ToString("C"); }
        public decimal MinValue { get => 10; }
        public decimal MaxValue { get => 19950; }

        public ICommand CreateBarCodeCommand { get; private set; }

        public DepositMoneyPageViewModel()
        {
            Title = "colocar dinheiro";
            CreateBarCodeCommand = new Command(async () => await CreateBarCodeCommandExecuteAsync());
        }

        private void CanCreateBarCode()
        {
            if (Value.HasValue && Value.Value >= MinValue && Value.Value <= MaxValue)
                CanContinue = true;
            else
                CanContinue = false;
        }

        private async Task CreateBarCodeCommandExecuteAsync() => await Navigation.PushAsync<DepositMoneyBarCodePageViewModel>(false, Value);
    }
}
