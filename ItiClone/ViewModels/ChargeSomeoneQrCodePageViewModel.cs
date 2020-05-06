using PanCardView.Extensions;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ItiClone.ViewModels
{
    public class ChargeSomeoneQrCodePageViewModel : BaseViewModel
    {
        private decimal? _value;
        public decimal? Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        private string _barCodeValue;
        public string BarCodeValue
        {
            get { return _barCodeValue; }
            set { SetProperty(ref _barCodeValue, value); }
        }

        public ICommand CreateNewCodeCommand { get; private set; }
        public ICommand CloseCodeCommand { get; private set; }

        public ChargeSomeoneQrCodePageViewModel()
        {
            Title = "código criado!";
            CreateNewCodeCommand = new Command(async () => await CreateNewCodeCommandExecuteAsync());
            CloseCodeCommand = new Command(async () => await CloseCodeCommandExecuteAsync());
        }

        public override Task InitializeAsync(object[] args)
        {
            if (args.Count() > 0)
            {
                Value = (decimal)args[0];
                BarCodeValue = $"{Guid.NewGuid()}|{Value}";
            }

            return Task.CompletedTask;
        }

        private async Task CreateNewCodeCommandExecuteAsync() => await Navigation.PopAsync();

        private async Task CloseCodeCommandExecuteAsync() => await Navigation.PopToRootAsync();
    }
}