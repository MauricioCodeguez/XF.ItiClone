using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ItiClone.ViewModels
{
    public class ChargeSomeonePageViewModel : BaseViewModel
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
                    CanContinue = _value.HasValue;

                    if (!_value.HasValue || _value <= ActualLimit)
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
        public decimal ActualLimit { get => 4500; }

        public ICommand CreateQrCodeCommand { get; private set; }

        public ChargeSomeonePageViewModel()
        {
            Title = "cobrar alguém";
            CreateQrCodeCommand = new Command(async () => await CreateQrCodeCommandExecuteAsync());
        }

        private async Task CreateQrCodeCommandExecuteAsync()
        {
            await Navigation.PushAsync<ChargeSomeoneQrCodePageViewModel>(false, Value);
        }
    }
}
