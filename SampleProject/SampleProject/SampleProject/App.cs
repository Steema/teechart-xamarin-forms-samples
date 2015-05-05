using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SampleProject
{
  public class App : Application
  {
    public App()
    {
      var tChart1 = new Steema.TeeChart.Chart();

      tChart1.Series.Add(new Steema.TeeChart.Styles.Bar()).FillSampleValues();
      tChart1.Aspect.View3D = false;
      
      ChartView chartView = new ChartView
      {
        VerticalOptions = LayoutOptions.FillAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand,

        WidthRequest = 400,
        HeightRequest = 500
      };

      chartView.Model = tChart1;

      MainPage = new ContentPage
      {
        Content = new StackLayout
        {
          Children =
          {
            chartView,
          }
        },
      };
    }
  }
}
