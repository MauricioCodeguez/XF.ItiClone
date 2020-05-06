using PanCardView.Extensions;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ItiClone.ViewModels
{
    public class DepositMoneyBarCodePageViewModel : BaseViewModel
    {
        private decimal? _value;
        public decimal? Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public DateTime ExpiryDate { get => DateTime.Now.AddDays(7); }

        public ICommand CloseCodeCommand { get; private set; }

        public DepositMoneyBarCodePageViewModel()
        {
            Title = "boleto criado";
            CloseCodeCommand = new Command(async () => await CloseCodeCommandExecuteAsync());
        }

        public override Task InitializeAsync(object[] args)
        {
            if (args.Count() > 0)
                Value = Convert.ToDecimal(args[0]);

            return Task.CompletedTask;
        }

        private async Task CloseCodeCommandExecuteAsync() => await Navigation.PopToRootAsync();
    }
}