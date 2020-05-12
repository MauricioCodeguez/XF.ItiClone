using ItiClone.iOS.Renderer;
using ItiClone.Renderers;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryBorderless), typeof(EntryBorderlessRenderer))]
namespace ItiClone.iOS.Renderer
{
    public class EntryBorderlessRenderer : EntryRenderer
    {

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}