using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ItiClone.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Action> Actions { get; private set; }

        public HomePageViewModel()
        {
            Actions = new ObservableCollection<Models.Action>()
            {
                new Models.Action
                {
                    Title = "pagar",
                    SubTitle = "transferir",
                    Icon = "pagaricon"
                },
                new Models.Action
                {
                    Title = "cobrar",
                    SubTitle = "alguém",
                    Icon = "usericon"
                },
                new Models.Action
                {
                    Title = "colocar",
                    SubTitle = "dinheiro",
                    Icon = "colocardinheiroicon"
                },
                new Models.Action
                {
                    Title = "adicionar",
                    SubTitle = "cartão",
                    Icon = "cartaocreditoicon"
                },
                new Models.Action
                {
                    Title = "fazer",
                    SubTitle = "recarga",
                    Icon = "recargaicon"
                }
            };
        }

        public override Task InitializeAsync(object[] args)
        {
            return Task.CompletedTask;
        }
    }
}