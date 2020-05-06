using Android.Content;
using ItiClone.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(ButtonAllCapsRenderer))]
namespace ItiClone.Droid.Renderers
{
    public class ButtonAllCapsRenderer : ButtonRenderer
    {
        public ButtonAllCapsRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.SetAllCaps(false);
        }
    }
}