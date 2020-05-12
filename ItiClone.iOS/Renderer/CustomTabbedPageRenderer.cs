using ItiClone.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace ItiClone.iOS.Renderer
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (TabBar != null && TabBarItem != null)
            {
                TabBar.BarTintColor = Color.FromHex("#2A3548").ToUIColor();

                TabBarItem.SetTitleTextAttributes(new UITextAttributes()
                {
                    TextColor = Color.FromHex("#EC7000").ToUIColor()
                },
                UIControlState.Selected);

                TabBarItem.SetTitleTextAttributes(new UITextAttributes()
                {
                    TextColor = Color.FromHex("#FFFFFF").ToUIColor()
                },
                UIControlState.Normal);
            }
        }
    }
}