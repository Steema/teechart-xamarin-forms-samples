using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DashBoard;
using Xamarin.Forms;

namespace WeatherApp.Charts
{
    public partial class WindSpeed : ContentPage
    {
        public WindSpeed()
        {
            InitializeComponent();
            this.Title = "Wind speed and degrees";
            WindSpeedForecast(App.Weather);
        }

        private async void WindSpeedForecast(ActualWeather weather)
        {
            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 5,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  }
                }
            };

            CircularGaugePage windSpeed = new CircularGaugePage(weather);
            RealTimeLinePage windSpeed2 = new RealTimeLinePage();
            grid.Children.Add(windSpeed.chartView, 0, 0);
            grid.Children.Add(windSpeed2.chartView, 0, 1);
            Content = grid;
            int i = 0;
            bool ended = false;
            windSpeed.tChart1.Header.Font.Size = 20;
            windSpeed2.tChart1.Header.Font.Size = 20;
            double prevWind = weather.LstWeather[0].WindSpeed;
            WeatherData item = weather.LstWeather[0];
            DateTime nextDay = weather.LstWeather[0].Date;
            DateTime temps = DateTime.Now;
            int minutes;
            try
            {
                double linearSpeed = 0;
                while (i < weather.LstWeather.Count - 1 && !ended)
                {
                    item = weather.LstWeather[i];
                    if (i < weather.LstWeather.Count - 1)
                    {
                        nextDay = weather.LstWeather[i + 1].Date;
                    }

                    minutes = TimeIncrement(prevWind, item.WindSpeed);
                    windSpeed.tChart1.Header.Text = string.Format("{0:0.00} m/s - {1:0.00} º", item.WindSpeed, item.WindDegree);
                    windSpeed2.tChart1.Header.Text = string.Format("{0:0.00} m/s - {1:0.00} º", item.WindSpeed, item.WindDegree);

                    if (windSpeed.wndSpeedGauge.Value < item.WindSpeed)
                    {
                        bool endUp = false;
                        try
                        {
                            while (!endUp)
                            {
                                temps += TimeSpan.FromMinutes(minutes);
                                if (linearSpeed + 0.15 < item.WindSpeed)
                                {
                                    linearSpeed += 0.15;
                                    windSpeed2.tChart1.Axes.Bottom.SetMinMax(weather.LstWeather[0].Date, temps);
                                    windSpeed2.wndSpeedLinear.Add(temps, linearSpeed);
                                    windSpeed.wndSpeedGauge.Value += 0.15;
                                }
                                else
                                {
                                    windSpeed2.wndSpeedLinear.Add(item.Date, item.WindSpeed);
                                    windSpeed.wndSpeedGauge.Value = item.WindSpeed;
                                    endUp = true;
                                }
                                windSpeed2.tChart1.Axes.Bottom.SetMinMax(weather.LstWeather[0].Date, item.Date);
                                await Task.Delay(10);
                            }
                        }
                        catch (ObjectDisposedException)
                        {
                            endUp = true;
                            ended = true;
                        }
                    }
                    else
                    {
                        bool endDown = false;
                        try
                        {
                            while (!endDown)
                            {
                                temps += TimeSpan.FromMinutes(minutes);
                                if (linearSpeed - 0.15 > item.WindSpeed)
                                {
                                    linearSpeed -= 0.15;
                                    windSpeed2.tChart1.Axes.Bottom.SetMinMax(weather.LstWeather[0].Date, temps);
                                    windSpeed2.wndSpeedLinear.Add(temps, linearSpeed);
                                    windSpeed.wndSpeedGauge.Value -= 0.15;
                                }
                                else
                                {
                                    windSpeed2.wndSpeedLinear.Add(item.Date, item.WindSpeed);
                                    windSpeed.wndSpeedGauge.Value = item.WindSpeed;
                                    endDown = true;
                                }
                                windSpeed2.tChart1.Axes.Bottom.SetMinMax(weather.LstWeather[0].Date, item.Date);
                                await Task.Delay(10);
                            }
                        }
                        catch (ObjectDisposedException)
                        {
                            endDown = true;
                            ended = true;
                        }
                    }
                    i++;
                    temps = item.Date;
                    prevWind = item.WindSpeed;
                }
            }
            catch (ObjectDisposedException)
            {
                ended = true;
            }
        }
        private int TimeIncrement(double prevWindSpeed, double actuWindSpeed)
        {
            int result = 0;
            if (prevWindSpeed != actuWindSpeed)
            {
                double distance = actuWindSpeed - prevWindSpeed;
                if (distance < 0) distance = distance * -1;
                double increments = distance * 15;
                result = (int)((3 * 60) / increments);
            }
            else
            {
                double distance = actuWindSpeed - 0;
                if (distance < 0) distance = distance * -1;
                double increments = distance * 15;
                result = (int)((3 * 60) / increments);

            }
            return result;
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
