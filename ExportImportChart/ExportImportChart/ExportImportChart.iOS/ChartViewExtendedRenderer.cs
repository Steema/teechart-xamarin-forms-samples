using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExportImportChart;
using ExportImportChart.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ChartViewExtended), typeof(ChartViewExtendedRenderer))]
namespace ExportImportChart.iOS
{
    public class ChartViewExtendedRenderer : Xamarin.Forms.Platform.iOS.ViewRenderer<ChartViewExtended, UIView>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<ChartViewExtended> e)
        {
            base.OnElementChanged(e);
            Element.OnSavePanelAsPNG += Element_OnSavePanelAsPNG;
        }

        private void Element_OnSavePanelAsPNG(SaveChartEventArgs e)
        {
            var nativeChartView = this.Subviews[0];
            UIGraphics.BeginImageContext(nativeChartView.Frame.Size);
            var ctx = UIGraphics.GetCurrentContext();
            if (ctx != null)
            {
                nativeChartView.Layer.RenderInContext(ctx);
                UIImage img = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();

                img.SaveToPhotosAlbum(
                    (sender, args) => {
                        Console.WriteLine("image saved to Photos");
                    }
                );

                string fileName = "ruben.png";
                SavePanelAsPNG(nativeChartView, fileName);
            }
        }

        public void SavePanelAsPNG(UIView view, string fileName)
        {

        }

    }
}