using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ItiClone.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Action> Actions { get; private set; }
        public ObservableCollection<Models.Resume> Resumes { get; private set; }

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
        }

        public override Task InitializeAsync(object[] args)
        {
            return Task.CompletedTask;
        }
    }
}