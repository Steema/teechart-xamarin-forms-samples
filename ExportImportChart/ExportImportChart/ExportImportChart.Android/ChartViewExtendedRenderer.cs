using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using ExportImportChart;
using ExportImportChart.Droid;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Steema.TeeChart;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Permission = Plugin.Permissions.Abstractions.Permission;

[assembly: ExportRenderer(typeof(ChartViewExtended), typeof(ChartViewExtendedRenderer))]
namespace ExportImportChart.Droid
{
    public class ChartViewExtendedRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<ChartViewExtended, Android.Views.View>
    {

        Context _context;

        public ChartViewExtendedRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ChartViewExtended> e)
        {
            base.OnElementChanged(e);
            Element.OnSavePanelAsPNG += Element_OnSavePanelAsPNG;
        }

        private void Element_OnSavePanelAsPNG(SaveChartEventArgs e)
        {
            var nativeChartView = this.GetChildAt(0) as ChartViewRenderer;
            string fileName = e.FileName;
            SavePanelAsPNG(nativeChartView, fileName);
        }

        private void SavePanelAsPNG(ChartViewRenderer chartView, String fileName)
        {
            if (chartView.ViewGroup != null)
            {
                //get the subview
                Android.Views.View subView = ViewGroup.GetChildAt(0);
                int width = subView.Width;
                int height = subView.Height;

                //create and draw the bitmap
                Bitmap b = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
                Canvas c = new Canvas(b);
                ViewGroup.Draw(c);

                //save the bitmap to file
                SaveBitmapToFile(b, fileName);
            }
        }

        void SaveBitmapToFile(Bitmap bm, String fileName)
        {
            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/TeeChart/";
            Directory.CreateDirectory(sdCardPath);

            var filePath = System.IO.Path.Combine(sdCardPath, fileName);
            var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            bm.Compress(Bitmap.CompressFormat.Png, 100, stream);
            stream.Close();
        }

    }
}