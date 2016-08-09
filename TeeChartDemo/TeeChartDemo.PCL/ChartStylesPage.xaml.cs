using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
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
            if (chart.Series[0].GetType() == typeof(Steema.TeeChart.Styles.Clock))
            {
                ((Steema.TeeChart.Styles.Clock)(chart.Series[0])).CancelTimer = true;
            }

            base.OnDisappearing();
        }

        Steema.TeeChart.Chart chart = new Steema.TeeChart.Chart();

        public ChartStylesPage(Type seriesType)
        {
            chart.Series.Add(seriesType);

            ChartView chartView = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,

                WidthRequest = 300,
                HeightRequest = 400
            };

            chart.Aspect.View3D = false;

            chart.Panel.Bevel.Inner = BevelStyles.None;
            chart.Panel.Bevel.Outer = BevelStyles.None;
            chart.Panel.Gradient.Visible = false;
            chart.Panel.Color = Color.White;

            chart.Zoom.Active = true;
            chart.Panning.Active = true;
            chart.Touch.Style = Steema.TeeChart.TouchStyle.InChart;

            Steema.TeeChart.Themes.TeeChartTheme theme = new Steema.TeeChart.Themes.TeeChartTheme(chart.Chart);
            theme.Apply();

            Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(chart, 18);

            chart.Panel.Gradient.Visible = false;
            chart.Panel.Color = Color.White;
            chart.Header.Font.Size = 14;
            chart.Header.Font.Color = Color.Gray;
            chart.Axes.Bottom.Labels.Font.Size = 12;
            chart.Axes.Left.Labels.Font.Size = 12;
            chart.Legend.Font.Size = 10;
            chart.Axes.Bottom.AxisPen.Visible = true;
            chart.Axes.Left.AxisPen.Visible = true;
            chart.Axes.Left.AxisPen.Color = Color.Gray;
            chart.Axes.Bottom.AxisPen.Color = Color.Gray;
            chart.Axes.Bottom.AxisPen.Width = 1;
            chart.Axes.Left.AxisPen.Width = 1;
            chart.Legend.Visible = false;
            chart.Axes.Left.Labels.Font.Color = Color.Gray;
            chart.Axes.Bottom.Labels.Font.Color = Color.Gray;

            foreach (var item in chart.Series)
            {
                item.FillSampleValues();
            }

            chart.Header.Text = chart[0].Description;

            if (seriesType != null && seriesType.GetTypeInfo().IsSubclassOf(typeof(Custom3D)) && seriesType != typeof(TagCloud)
            && seriesType != typeof(Ternary) && seriesType != typeof(World))
            {
                chart.Aspect.View3D = true;
                chart.Axes.Left.Grid.Visible = false;
                chart.Axes.Bottom.Grid.Visible = false;
                chart.Aspect.Chart3DPercent = 30;
            }

            Variables.ModifySeries(chart, Color.White);
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
