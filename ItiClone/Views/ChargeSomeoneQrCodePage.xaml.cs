using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItiClone.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChargeSomeoneQrCodePage : ContentPage
    {
        public ChargeSomeoneQrCodePage()
        {
            InitializeComponent();
        }

        private void canvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = ((Color)Application.Current.Resources["WindowBackground"]).ToSKColor(),
                StrokeWidth = 5,
                StrokeCap = SKStrokeCap.Butt,
                PathEffect = SKPathEffect.CreateDash(new float[] { 5, 10 }, 20)
            };

            SKPath path = new SKPath();
            path.LineTo(info.Width, 1);

            canvas.DrawPath(path, paint);
        }
    }
}