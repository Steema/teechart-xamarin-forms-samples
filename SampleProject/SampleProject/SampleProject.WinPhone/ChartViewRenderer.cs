using SampleProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(ChartView), typeof(SampleProject.WP8.ChartViewRenderer))]
namespace SampleProject.WP8
{
  public class ChartViewRenderer : ViewRenderer<ChartView, Steema.TeeChart.TChart>
  {
    protected override void OnElementChanged(ElementChangedEventArgs<ChartView> e)
    {
      base.OnElementChanged(e);
      if (e.OldElement != null || this.Element == null)
        return;

      var chartView = new Steema.TeeChart.TChart();

      chartView.Chart = Element.Model;
      chartView.Aspect.ClipPoints = false;
      chartView.Aspect.ExtendAxes = true;

      SetNativeControl(chartView);
    }

    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      base.OnElementPropertyChanged(sender, e);
    }
  }
}
