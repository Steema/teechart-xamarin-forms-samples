using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace StandardSeriesXFormsSTD.DashBoards
{
    public class Page7 : ContentPage
    {
        public ChartView dashChart;
        public Page7()
        {
            dashChart = new ChartView();
            dashChart.WidthRequest = 400;
            dashChart.HeightRequest = 300;

            dashChart.Chart.Aspect.View3D = false;
            Steema.TeeChart.Styles.VerticalLinearGauge series = new Steema.TeeChart.Styles.VerticalLinearGauge();
            dashChart.Chart.Series.Add(series);
            series.FillSampleValues();

            // Vertical linear gauge
            dashChart.Chart.Panel.Color = Color.White;
            dashChart.Chart.Panel.Gradient.Visible = false;
            dashChart.Chart.Footer.Text = "Linear";
            dashChart.Chart.Footer.Alignment = TextAlignment.End;
            dashChart.Chart.Footer.Font.Size = 12;
            dashChart.Chart.Footer.Font.Color = Color.Navy;
            dashChart.Chart.Footer.Visible = true;
            dashChart.Chart.Title.Visible = false;
            //dashBoard0.Title.Font.Name = "";
            dashChart.Chart.Legend.Visible = false;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    dashChart
                }
            };
        }
    }
}
