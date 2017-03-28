using System;
using Steema.TeeChart.Drawing;
using Xamarin.Forms;
using Steema.TeeChart.Editors.Tools;
using Steema.TeeChart.Themes;

namespace TeeChartDemo.PCL
{
    public partial class ChartToolsPage : ContentPage
    {
        public ChartToolsPage(Type toolsType)
        {

            Steema.TeeChart.Chart chart = new Steema.TeeChart.Chart();

            ToolsGalleryDemos toolsDemos = new ToolsGalleryDemos(chart, typeof(TeeChartTheme));

            //Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(chart, 18);

            ChartView chartView = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,

                WidthRequest = 400,
                HeightRequest = 500
            };

            chart.Aspect.View3D = false;
            chart.Panel.Bevel.Inner = BevelStyles.None;
            chart.Panel.Bevel.Outer = BevelStyles.None;
            chart.Panel.Gradient.Visible = true;
            //chart.Panel.Color = Color.FromRgb(255, 255, 255);

            chart.Zoom.Active = false;
            chart.Touch.Style = Steema.TeeChart.TouchStyle.InChart;

            toolsDemos.CreateGallery(toolsType);

            BlackIsBackTheme theme = new BlackIsBackTheme(chart);
            Steema.TeeChart.Themes.Theme.ApplyChartTheme(theme, chart);
            Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(chart, Theme.OnBlackPalette);
            //chart.Panel.Gradient.Visible = false;
            //chart.Panel.Color = Color.White;
            chart.Header.Font.Color = Color.Gray;
            chart.Axes.Left.AxisPen.Color = Color.Gray;
            chart.Axes.Bottom.AxisPen.Color = Color.Gray;
            chart.Axes.Left.Labels.Font.Color = Color.Gray;
            chart.Axes.Bottom.Labels.Font.Color = Color.Gray;

            if (chart.Series.Count > 0)
            {
                if (chart.Series[0] is Steema.TeeChart.Styles.Pie)
                {
                    Steema.TeeChart.Styles.Pie pie = ((Steema.TeeChart.Styles.Pie)(chart.Series[0]));
                    pie.Circled = true;
                    pie.CircleGradient.Visible = false;
                }
            }

            if (chart.Tools.Count>0)
            {

                foreach (Steema.TeeChart.Tools.Tool s in chart.Tools)
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
                        gridband.Band2.Color = Color.FromRgb(225,225,225);
                        chart.Axes.Left.Labels.RoundFirstLabel = true;
                        chart.Axes.Left.Labels.Separation = 100;
                    }
                }
            }


            chartView.Model = chart;

            Content = new StackLayout
            {
                Children = {
                      chartView,
                  }
            };
        }
    }
}
