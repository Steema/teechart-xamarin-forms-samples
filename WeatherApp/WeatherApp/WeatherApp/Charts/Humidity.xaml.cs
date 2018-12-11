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
    public partial class Humidity : ContentPage
    {
        public Humidity()
        {
            InitializeComponent();
            this.Title = "Humidity for the week";
            HumidityForecast(App.Weather);
        }
        private void HumidityForecast(ActualWeather weather)
        {
            Chart tChart1 = new Chart();
            tChart1.Axes.Bottom.Ticks.Visible = false;
            tChart1.Axes.Bottom.Labels.Visible = false;
            tChart1.Axes.Bottom.Labels.Font.Color = Color.White;
            tChart1.Axes.Left.Increment = Utils.GetDateTimeStep(DateTimeSteps.OneDay);
            tChart1.Axes.Left.Labels.Font.Size = 15;
            tChart1.Axes.Left.Labels.Font.Color = Color.White;
            tChart1.Header.Visible = false;
            tChart1.Panel.Visible = true;
            tChart1.Panel.Transparent = false;
            tChart1.Panel.Gradient.Visible = false;
            tChart1.Panel.Color = Color.FromHex("#125675");
            tChart1.Header.Alignment = TextAlignment.Center;
            tChart1.Walls.Back.Visible = true;
            tChart1.Walls.Back.Transparent = false;
            tChart1.Walls.Back.Gradient.Visible = false;
            tChart1.Panel.MarginBottom = 5;
            tChart1.Panel.MarginLeft = 5;
            tChart1.Panel.MarginRight = 5;
            tChart1.Panel.MarginTop = 5;
            tChart1.Walls.Back.Color = Color.White;
            tChart1.Zoom.Active = true;
            tChart1.Aspect.View3D = false;
            tChart1.Legend.Visible = false;

            var humidity = new HorizBar(tChart1.Chart);
            humidity.Marks.AutoPosition = true;
            humidity.Marks.Transparent = true;
            humidity.MarksLocation = MarksLocation.End;
            humidity.Marks.Font.Size = 10;
            humidity.Marks.Style = MarksStyles.Value;


            double max = weather.LstWeather[0].Humidity;
            foreach (var item in weather.LstWeather)
            {
                if (item.Humidity > max) max = item.Humidity;
                humidity.Add(item.Humidity, item.Date);
            }

            tChart1.Legend.Visible = false;
            tChart1.Axes.Bottom.SetMinMax(0, max + 20);
            humidity.Color = Color.FromHex("#85D2F6");
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
