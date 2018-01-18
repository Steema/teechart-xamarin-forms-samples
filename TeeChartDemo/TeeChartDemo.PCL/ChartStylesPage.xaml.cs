using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Themes;
using System;
using Xamarin.Forms;
using System.Reflection;

namespace TeeChartDemo.PCL
{
  public partial class ChartStylesPage : ContentPage
  {
    protected override void OnDisappearing()
    {
      //Android menu system issue
      if (chart.Chart.Series[0].GetType() == typeof(Steema.TeeChart.Styles.Clock))
      {
        ((Steema.TeeChart.Styles.Clock)(chart.Chart.Series[0])).CancelTimer = true;
      }

      base.OnDisappearing();
    }

    Steema.TeeChart.ChartView chart = new Steema.TeeChart.ChartView();

    public ChartStylesPage(Type seriesType)
    {

      chart.WidthRequest = 400;
      chart.HeightRequest = 300;
      chart.Chart.Series.Add(Series.NewFromType(seriesType));

      chart.Chart.Aspect.View3D = false;

      chart.Chart.Panel.Bevel.Inner = BevelStyles.None;
      chart.Chart.Panel.Bevel.Outer = BevelStyles.None;
      chart.Chart.Panel.Gradient.Visible = true;

      chart.Chart.Zoom.Active = true;
      chart.Chart.Panning.Active = true;
      chart.Chart.Touch.Style = Steema.TeeChart.TouchStyle.InChart;

      ReportTheme theme = new ReportTheme(chart.Chart);
      Steema.TeeChart.Themes.Theme.ApplyChartTheme(theme, chart.Chart);
      Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(chart.Chart, Theme.SeawashPalette);
      chart.Chart.CurrentTheme = Steema.TeeChart.ThemeType.Report;

      chart.Chart.Header.Font.Size = 14;
      chart.Chart.Header.Font.Color = Color.Gray;
      chart.Chart.Axes.Bottom.Labels.Font.Size = 12;
      chart.Chart.Axes.Left.Labels.Font.Size = 12;
      chart.Chart.Legend.Font.Size = 10;
      chart.Chart.Axes.Bottom.AxisPen.Visible = true;
      chart.Chart.Axes.Left.AxisPen.Visible = true;
      chart.Chart.Axes.Left.AxisPen.Color = Color.Gray;
      chart.Chart.Axes.Bottom.AxisPen.Color = Color.Gray;
      chart.Chart.Axes.Bottom.AxisPen.Width = 1;
      chart.Chart.Axes.Left.AxisPen.Width = 1;
      chart.Chart.Legend.Visible = false;
      chart.Chart.Axes.Left.Labels.Font.Color = Color.Gray;
      chart.Chart.Axes.Bottom.Labels.Font.Color = Color.Gray;

      foreach (var item in chart.Chart.Series)
      {
        item.FillSampleValues();
      }

      chart.Chart.Header.Text = chart.Chart[0].Description;

      if (seriesType != null && seriesType.GetTypeInfo().IsSubclassOf(typeof(Custom3D)) && seriesType != typeof(TagCloud)
      && seriesType != typeof(Ternary) && seriesType != typeof(World))
      {
        chart.Chart.Aspect.View3D = true;
        chart.Chart.Axes.Left.Grid.Visible = false;
        chart.Chart.Axes.Bottom.Grid.Visible = false;
        chart.Chart.Aspect.Chart3DPercent = 30;
      }

      Variables.ModifySeries(chart.Chart, Color.White);      

      Content = new StackLayout
      {
        Children = {
                      chart,
                  },
          VerticalOptions = LayoutOptions.CenterAndExpand,
          HorizontalOptions = LayoutOptions.CenterAndExpand,
      };
    }
  }
}
