using ItiClone.Services.Navigation;
using ItiClone.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ItiClone.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Action> Actions { get; private set; }
        public ObservableCollection<Models.Resume> Resumes { get; private set; }

        public ICommand ActionCommand { get; private set; }

        public HomePageViewModel()
        {
            Actions = new ObservableCollection<Models.Action>()
            {
                new Models.Action
                {
                    Title = "pagar",
                    SubTitle = "transferir",
                    Icon = "pagaricon",
                    ActionType = Models.ActionType.Pay
                },
                new Models.Action
                {
                    Title = "cobrar",
                    SubTitle = "alguém",
                    Icon = "usericon",
                    ActionType = Models.ActionType.ChargeSomeone
                },
                new Models.Action
                {
                    Title = "colocar",
                    SubTitle = "dinheiro",
                    Icon = "colocardinheiroicon",
                    ActionType = Models.ActionType.DepositMoney
                },
                new Models.Action
                {
                    Title = "adicionar",
                    SubTitle = "cartão",
                    Icon = "cartaocreditoicon",
                    ActionType = Models.ActionType.AddCard
                },
                new Models.Action
                {
                    Title = "fazer",
                    SubTitle = "recarga",
                    Icon = "recargaicon",
                    ActionType = Models.ActionType.TopUp
                }
            };

            Resumes = new ObservableCollection<Models.Resume>()
            {
                new Models.Resume
                {
                    Title = "movimentações",
                    ResumeType = Models.ResumeType.Transactions
                },
                new Models.Resume
                {
                    Title = "conexão iti",
                    ResumeType = Models.ResumeType.Connections
                },
                new Models.Resume
                {
                    Title = "meus cartões",
                    ResumeType = Models.ResumeType.Cards
                },
                new Models.Resume
                {
                    Title = "conta pra gente",
                    ResumeType = Models.ResumeType.Recommendation
                }
            };

            ActionCommand = new Command<Models.Action>(async (a) => await ActionCommandExecuteAsync(a));
        }

        public override Task InitializeAsync(object[] args)
        {
            return Task.CompletedTask;
        }

        private async Task ActionCommandExecuteAsync(Models.Action action)
        {
            if (action == null)
                return;

            if (action.ActionType == Models.ActionType.AddCard)
                await Navigation.PushAsync<RegisterCardPageViewModel>();
            else if (action.ActionType == Models.ActionType.ChargeSomeone)
                await Navigation.PushAsync<ChargeSomeonePageViewModel>();
            else if (action.ActionType == Models.ActionType.DepositMoney)
                await Navigation.PushAsync<DepositMoneyPageViewModel>();
        }
    }
}