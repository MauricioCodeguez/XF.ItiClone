using ItiClone.Services.Navigation;
using ItiClone.ViewModels;
using Xamarin.Forms;

namespace ItiClone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            NavigationService.Current.SetarMainPage<HomePageViewModel>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
