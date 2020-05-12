using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using ItiClone.Views.Custom;
using PanCardView.Droid;
using System.Linq;

namespace ItiClone.Droid
{
    [Activity(Label = "ItiClone", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            ZXing.Net.Mobile.Forms.Android.Platform.Init();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CardsViewRenderer.Preserve();

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
			// check if the current item id 
			// is equals to the back button id
			if (item.ItemId == 16908332)
			{
				var currentpage = (CustomContentPage)
				Xamarin.Forms.Application.
				Current.MainPage.Navigation.
				NavigationStack.LastOrDefault();

				if (currentpage?.CustomBackButtonAction != null)
				{
					currentpage?.CustomBackButtonAction.Invoke();
					return false;
				}

				return base.OnOptionsItemSelected(item);
			}
			else
				return base.OnOptionsItemSelected(item);
		}

		public override void OnBackPressed()
		{
			var currentpage = (CustomContentPage)
			Xamarin.Forms.Application.
			Current.MainPage.Navigation.
			NavigationStack.LastOrDefault();

			if (currentpage?.CustomBackButtonAction != null)
				currentpage?.CustomBackButtonAction.Invoke();
			else
				base.OnBackPressed();
		}
	}
}