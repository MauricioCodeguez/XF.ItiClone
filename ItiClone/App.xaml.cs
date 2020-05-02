using ItiClone.Services.Navigation;
using ItiClone.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ItiClone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new List<string>() {
                    "IndicatorView_Experimental",
                    "CarouselView_Experimental"
                });

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
