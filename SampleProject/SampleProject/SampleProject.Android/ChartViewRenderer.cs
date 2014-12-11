using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinFormsTest.Droid;
using XamarinFormsTest;
using Steema.TeeChart;
using SampleProject;

[assembly: ExportRenderer(typeof(ChartView), typeof(ChartViewRenderer))]
namespace XamarinFormsTest.Droid
{
  public class ChartViewRenderer: ViewRenderer
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

      //if (/*Control == null ||*/ e.OldElement != null || this.Element == null)
      //  return;

      if (Control == null)
      {
        var chartView = new Steema.TeeChart.TChart(Context);

        chartView.Chart = NativeElement.Model;

        SetNativeControl(chartView);
      }

      if (e.OldElement != null)
      {
        //unhook old events
      }

      if (e.NewElement != null)
      {
        //hook old events
      }
    }

    //protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    //{
    //  base.OnElementPropertyChanged(sender, e);
    //}
  }
}