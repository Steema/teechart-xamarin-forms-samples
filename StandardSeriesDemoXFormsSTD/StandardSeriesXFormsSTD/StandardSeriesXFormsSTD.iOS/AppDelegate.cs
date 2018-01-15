
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Steema.TeeChart.ChartViewRenderer), typeof(Steema.TeeChart.ChartViewRenderer))]
namespace StandardSeriesXFormsSTD.iOS
{
	[Register("AppDelegate")]    
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            new Steema.TeeChart.ChartViewRenderer();

            global::Xamarin.Forms.Forms.Init();
            Steema.TeeChart.TChart.Init();

            LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
