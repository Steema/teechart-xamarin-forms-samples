using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WeatherApp.Charts
{
    public partial class MaxTemperature : ContentPage
    {
        Chart tChart1;
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            tChart1.Series.Clear();
            GC.Collect();
            return true;
        }
        public MaxTemperature()
        {
            InitializeComponent();
            this.Title = "Historigram temp. for the week";
            MaxTemperatureForecast(App.Weather);
        }
        private void MaxTemperatureForecast(ActualWeather weather)
        {
            tChart1 = new Chart();
            tChart1.Axes.Bottom.Increment = 1;
            tChart1.Axes.Bottom.Title.Font.Size = 20;
            tChart1.Axes.Bottom.Labels.Font.Size = 15;
            tChart1.Axes.Bottom.Title.Gradient.Visible = false;
            tChart1.Axes.Bottom.Title.Font.Color = Color.Blue;
            tChart1.Axes.Bottom.Labels.Angle = 90;
            tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MMM";
            tChart1.Axes.Left.Labels.Font.Size = 15;
            tChart1.Axes.Left.Title.Font.Color = Color.Blue;
            tChart1.Axes.Left.Increment = 1;
            tChart1.Axes.Left.Title.Font.Size = 20;
            tChart1.Axes.Left.MinorTicks.Visible = false;
            tChart1.Header.Visible = false;
            tChart1.Panel.Visible = true;
            tChart1.Panel.Gradient.StartColor = Color.FromHex("#d32213");
            tChart1.Panel.Gradient.EndColor = Color.FromHex("#EB9D01");
            tChart1.Panel.Gradient.Direction = Steema.TeeChart.Drawing.GradientDirection.BottomTop;
            tChart1.Panel.Gradient.Visible = true;
            tChart1.Panel.Visible = true;
            tChart1.Aspect.View3D = false;
            tChart1.Panel.Transparent = false;
            tChart1.Header.Alignment = TextAlignment.Center;
            tChart1.Walls.Back.Visible = true;
            tChart1.Walls.Back.Transparent = false;
            tChart1.Walls.Back.Gradient.Visible = false;
            tChart1.Walls.Back.Color = Color.White;
            tChart1.Zoom.Active = true;
            tChart1.Legend.Visible = false;
            tChart1.Aspect.View3D = false;
            var maxTemp = new Histogram(tChart1.Chart);

            double max = weather.LstWeather[0].MaxTemperature;
            double min = weather.LstWeather[0].MaxTemperature;
            foreach (var item in weather.LstWeather)
            {
                if (item.MaxTemperature > max) max = item.MaxTemperature;
                if (item.MaxTemperature < min) min = item.MinTemperature;
                maxTemp.Add(item.Date, item.MaxTemperature);
            }
            maxTemp.Marks.AutoPosition = true;
            maxTemp.Marks.Transparent = true;
            tChart1.Axes.Left.SetMinMax((int)min - 5, (int)max + 5);
            maxTemp.Brush.Gradient.Visible = true;
            maxTemp.Brush.Gradient.StartColor = Color.FromHex("#d32213");
            maxTemp.Brush.Gradient.MiddleColor = Color.FromHex("#EB9D01");
            maxTemp.Brush.Gradient.EndColor = Color.FromHex("#FFDA50");
            maxTemp.Brush.Gradient.Direction = Steema.TeeChart.Drawing.GradientDirection.DiagonalUp;

            ShowChart(tChart1);
        }
        private void ShowChart(Chart tChart1)
        {
            if (tChart1 != null)
            {
                ChartView chartView = new ChartView
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                chartView.Model = tChart1;
                Content = new StackLayout
                {
                    Children =
                    {
                        chartView,
                    }
                };
            }
        }
    }
}
