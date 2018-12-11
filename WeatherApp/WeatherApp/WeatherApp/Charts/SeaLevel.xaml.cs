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
    public partial class SeaLevel : ContentPage
    {
        public SeaLevel()
        {
            InitializeComponent();
            this.Title = "Pressure on the sea level";
            SeaLevelForecast(App.Weather);
        }
        private void SeaLevelForecast(ActualWeather weather)
        {
            Chart tChart1 = new Chart();
            tChart1.Axes.Bottom.Increment = 1;
            tChart1.Axes.Bottom.Ticks.Length = 10;
            tChart1.Axes.Bottom.Labels.Angle = 90;
            tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MMM";
            tChart1.Axes.Bottom.Labels.Font.Size = 15;
            tChart1.Axes.Bottom.Labels.Font.Color = Color.White;
            tChart1.Axes.Left.Labels.Font.Color = Color.White;
            tChart1.Axes.Left.Labels.Font.Size = 15;
            tChart1.Axes.Left.Increment = 1;
            tChart1.Axes.Left.Title.Text = "Hpa";
            tChart1.Axes.Left.Title.Font.Size = 15;
            tChart1.Axes.Left.Title.Font.Color = Color.White;
            tChart1.Axes.Left.Ticks.Length = 10;
            tChart1.Legend.Visible = false;
            tChart1.Header.Visible = false;
            tChart1.Panel.Visible = true;
            tChart1.Panel.Gradient.Visible = false;
            tChart1.Panel.Color = Color.FromHex("#125675");
            tChart1.Panel.MarginBottom = 5;
            tChart1.Panel.MarginLeft = 5;
            tChart1.Panel.MarginRight = 5;
            tChart1.Panel.MarginTop = 5;
            tChart1.Walls.Back.Visible = true;
            tChart1.Zoom.Active = false;
            tChart1.Aspect.View3D = false;
            tChart1.Legend.Visible = false;
            tChart1.Panning.Allow = ScrollModes.None;



            var seaLevel = new Area(tChart1.Chart);
            foreach (var item in weather.LstWeather)
            {
                seaLevel.Add(item.Date, item.SeaLevel);
            }

            seaLevel.Legend.Visible = true;
            seaLevel.Color = Color.FromHex("#084B8A");
            seaLevel.Stairs = false;
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
