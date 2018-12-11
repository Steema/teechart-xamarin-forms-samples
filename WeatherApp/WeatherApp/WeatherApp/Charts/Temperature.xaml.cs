using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DashBoard;
using Xamarin.Forms;
using CarouselView.FormsPlugin.Abstractions;

namespace WeatherApp.Charts
{
    public partial class Temperature : ContentPage
    {
        LineTemperaturePage lineTemperature;
        Chart tChart1;
        public Temperature()
        {
            InitializeComponent();
            this.Title = "Temperature for the week";
            TemperatureForecast(App.Weather);

        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            lineTemperature.lstTemp.Clear();
            tChart1.Series.Clear();
            GC.Collect();
            return true;
        }
        private void TemperatureForecast(ActualWeather weather)
        {
            try
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

                tChart1 = new Chart();
                tChart1.Axes.Left.Increment = 1;
                tChart1.Axes.Bottom.Labels.Font.Size = 12;
                tChart1.Axes.Bottom.Ticks.Length = 15;
                tChart1.Axes.Bottom.Ticks.Visible = true;
                tChart1.Axes.Bottom.Title.Font.Size = 15;
                tChart1.Axes.Bottom.Labels.Angle = 90;
                tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MMM";
                tChart1.Axes.Left.Labels.Font.Size = 12;
                tChart1.Axes.Left.Ticks.Visible = true;
                tChart1.Axes.Left.Ticks.Length = 15;
                tChart1.Axes.Left.Title.Font.Size = 15;
                tChart1.Axes.Left.MinorTicks.Visible = false;
                tChart1.Aspect.ColorPaletteIndex = 20;
                tChart1.Aspect.View3D = false;
                tChart1.Header.Visible = true;
                tChart1.Panel.Pen.Visible = true;
                tChart1.Walls.Back.Brush.Visible = true;
                tChart1.Walls.Back.Transparent = false;
                tChart1.Walls.Back.Gradient.Visible = false;
                tChart1.Walls.Back.Color = Color.White;
                tChart1.Panel.Gradient.Visible = false;
                tChart1.Panel.MarginBottom = 5;
                tChart1.Panel.MarginLeft = 5;
                tChart1.Panel.MarginRight = 5;
                tChart1.Panel.MarginTop = 15;
                tChart1.Panel.Color = Color.FromHex("#81a9e8");
                tChart1.Panning.Allow = ScrollModes.None;
                tChart1.Legend.Alignment = LegendAlignments.Bottom;
                tChart1.Legend.TextAlign = TextAlignment.Start;
                tChart1.Panel.Visible = false;


                double min = weather.LstWeather[0].MinTemperature;
                double max = weather.LstWeather[0].MaxTemperature;

                var avTemp = new Line(tChart1.Chart);
                foreach (var item in weather.LstWeather)
                {
                    if (item.MaxTemperature > max) max = item.MaxTemperature;
                    if (item.MinTemperature < min) min = item.MinTemperature;
                    avTemp.Add(item.Date, item.Temperature);
                }

                tChart1.Axes.Left.SetMinMax((int)min - 5, (int)max + 5);

                avTemp.Color = Color.FromHex("#0e661f");
                avTemp.Legend.Visible = false;
                avTemp.LinePen.Width = 8;

                lineTemperature = new LineTemperaturePage(weather);

                CarouselViewControl myCarousel = new CarouselViewControl();
                int i = 0;
                myCarousel.ItemsSource = lineTemperature.lstTemp;
                myCarousel.ItemTemplate = new DataTemplate(() =>
                {
                    if (i == lineTemperature.lstTemp.Count)
                    {
                        i = 0;
                    }
                    return lineTemperature.lstTemp[i++];
                });
                ChartView cv = ShowChart(tChart1);
                if(cv!=null)grid.Children.Add(cv, 0, 0);
                grid.Children.Add(myCarousel, 0, 1);
                Content = grid;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
        private ChartView ShowChart(Chart tChart1)
        {
            ChartView chartView = null;
            if (tChart1 != null)
            {
                chartView = new ChartView
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
            return chartView;
        }
      
    }
}
