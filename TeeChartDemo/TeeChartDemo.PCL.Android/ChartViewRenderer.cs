using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeeChartDemo.PCL;
using TeeChartDemo.PCL.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ChartView), typeof(ChartViewRenderer))]
namespace TeeChartDemo.PCL.Droid
{
  public class ChartViewRenderer : ViewRenderer
  {
    protected TChart NativeControl
    {
      get
      {
        return ((TChart)Control);
      }
    }
    protected ChartView NativeElement
    {
      get
      {
        return ((ChartView)Element);
      }
    }

    protected override void OnElementChanged(ElementChangedEventArgs<View> e)
    {
      base.OnElementChanged(e);

      var plotView = new TChart(Context);

      //NativeElement.OnInvalidateDisplay = (s, ea) =>
      //{
      //  plotView.Invalidate();
      //};

      SetNativeControl(plotView);

      NativeControl.Chart = NativeElement.Model;

      //NativeControl.SetBackgroundColor(NativeElement.BackgroundColor.ToAndroid());
    }

    protected override void OnLayout(bool changed, int l, int t, int r, int b)
    {
      base.OnLayout(changed, l, t, r, b);
    }

    protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      base.OnElementPropertyChanged(sender, e);

      //if (e.PropertyName == OxyPlotView.BackgroundColorProperty.PropertyName)
      //{
      //  NativeControl.SetBackgroundColor(NativeElement.BackgroundColor.ToAndroid());
      //}
    }
  }
}
