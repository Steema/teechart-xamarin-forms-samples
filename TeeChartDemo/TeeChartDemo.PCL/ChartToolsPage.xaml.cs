using System;
using Steema.TeeChart.Drawing;
using Xamarin.Forms;
using Steema.TeeChart.Editors.Tools;
using Steema.TeeChart.Themes;
using Steema.TeeChart;

namespace TeeChartDemo.PCL
{
  public partial class ChartToolsPage : ContentPage
  {

    ChartView chart = new ChartView();
    public ChartToolsPage(Type toolsType)
    {
      chart.HeightRequest = 300;
      chart.WidthRequest = 300;

      ToolsGalleryDemos toolsDemos = new ToolsGalleryDemos(chart.Chart, typeof(TeeChartTheme));

        chart.Chart.Aspect.View3D = false;
        chart.Chart.Panel.Bevel.Inner = BevelStyles.None;
        chart.Chart.Panel.Bevel.Outer = BevelStyles.None;
        chart.Chart.Panel.Gradient.Visible = true;

        chart.Chart.Zoom.Active = false;
        chart.Chart.Touch.Style = Steema.TeeChart.TouchStyle.InChart;

      toolsDemos.CreateGallery(toolsType);

      ReportTheme theme = new ReportTheme(chart.Chart);
      Steema.TeeChart.Themes.Theme.ApplyChartTheme(theme, chart.Chart);
      Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(chart.Chart, Theme.OnBlackPalette);
        chart.Chart.Header.Font.Color = Color.Gray;
        chart.Chart.Axes.Left.AxisPen.Color = Color.Gray;
        chart.Chart.Axes.Bottom.AxisPen.Color = Color.Gray;
        chart.Chart.Axes.Left.Labels.Font.Color = Color.Gray;
        chart.Chart.Axes.Bottom.Labels.Font.Color = Color.Gray;

      if (chart.Chart.Series.Count > 0)
      {
        if (chart.Chart.Series[0] is Steema.TeeChart.Styles.Pie)
        {
          Steema.TeeChart.Styles.Pie pie = ((Steema.TeeChart.Styles.Pie)(chart.Chart.Series[0]));
          pie.Circled = true;
          pie.CircleGradient.Visible = false;
        }
      }

      if (chart.Chart.Tools.Count > 0)
      {

        foreach (Steema.TeeChart.Tools.Tool s in chart.Chart.Tools)
        {
          if (s is Steema.TeeChart.Tools.Annotation)
          {
            Steema.TeeChart.Tools.Annotation annotation = ((Steema.TeeChart.Tools.Annotation)(s));
            annotation.Shape.Font.Size = 12;
            annotation.TextAlign = TextAlignment.Center;
            annotation.Shape.Gradient.StartColor = Color.FromRgb(120, 120, 120);
          }
          if (s is Steema.TeeChart.Tools.GridBand)
          {
            Steema.TeeChart.Tools.GridBand gridband = ((Steema.TeeChart.Tools.GridBand)(s));
            gridband.Band1.Color = Color.FromRgb(192, 192, 192);
            gridband.Band2.Color = Color.FromRgb(225, 225, 225);
            chart.Chart.Axes.Left.Labels.RoundFirstLabel = true;
            chart.Chart.Axes.Left.Labels.Separation = 100;
          }
        }
      }
      chart.InvalidateDisplay();
       chart.Chart.Invalidate();

      Content = new StackLayout
      {
          Children = {
              chart 
            },
        VerticalOptions = LayoutOptions.CenterAndExpand,
        HorizontalOptions = LayoutOptions.CenterAndExpand,
      };
    }
  }
}
