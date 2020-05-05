using Android.Content;
using Android.Graphics.Drawables;
using ItiClone.Droid.Renderers;
using ItiClone.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryBorderless), typeof(EntryBorderlessRenderer))]
namespace ItiClone.Droid.Renderers
{
    public class EntryBorderlessRenderer : EntryRenderer
    {
        public EntryBorderlessRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}