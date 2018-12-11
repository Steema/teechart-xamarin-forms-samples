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

    public partial class MinTemperature : ContentPage
    {
        public MinTemperature()
        {
            InitializeComponent();
            this.Title = "Min/Max temperatures for the week";
            MinTemperatureForecast(App.Weather);
        }
        private void MinTemperatureForecast(ActualWeather weather)
        {

            Chart tChart1 = new Chart();
            tChart1.Axes.Left.Increment = 1;
            tChart1.Axes.Bottom.Labels.Angle = 90;
            tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MMM";
            tChart1.Axes.Bottom.Labels.Font.Size = 15;
            tChart1.Axes.Bottom.Ticks.Length = 15;
            tChart1.Axes.Bottom.Ticks.Visible = true;
            tChart1.Axes.Bottom.Labels.Color = Color.Aqua;
            tChart1.Axes.Left.Labels.Color = Color.Aqua;
            tChart1.Axes.Left.Labels.Font.Size = 15;
            tChart1.Axes.Left.Ticks.Visible = true;
            tChart1.Axes.Left.Ticks.Length = 15;
            tChart1.Axes.Left.MinorTicks.Visible = false;
            tChart1.Aspect.ColorPaletteIndex = 20;
            tChart1.Header.Visible = false;
            tChart1.Aspect.View3D = false;
            tChart1.Panel.Pen.Visible = true;
            tChart1.Walls.Back.Brush.Visible = true;
            tChart1.Walls.Back.Transparent = false;
            tChart1.Walls.Back.Gradient.Visible = false;
            tChart1.Walls.Back.Color = Color.White;
            tChart1.Panel.Gradient.Visible = false;
            tChart1.Panel.Color = Color.FromHex("#00007F");
            tChart1.Panning.Allow = ScrollModes.None;
            tChart1.Legend.Visible = false;
            tChart1.Panel.Visible = false;
            tChart1.Panel.MarginBottom = 5;
            tChart1.Panel.MarginLeft = 5;
            tChart1.Panel.MarginRight = 5;
            tChart1.Panel.MarginTop = 5;

            var minTemp = new Bar(tChart1.Chart);
            minTemp.Marks.Visible = false;
            double max = weather.LstWeather[0].MinTemperature;
            double min = weather.LstWeather[0].MinTemperature;
            
            foreach (var item in weather.LstWeather)
            {
                if (item.MinTemperature > max) max = item.MinTemperature;
                if (item.MinTemperature < min) min = item.MinTemperature;
                minTemp.Add(item.Date, item.Temperature);
            }

            tChart1.Axes.Left.SetMinMax((int)min - 5, (int)max + 5);
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
