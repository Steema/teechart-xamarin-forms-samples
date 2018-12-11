using System;
using Steema.TeeChart.Styles;
using Xamarin.Forms;
using System.Threading.Tasks;
using WeatherApp.DashBoard;
using Steema.TeeChart;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using WeatherApp.Model;
using System.Diagnostics;

namespace WeatherApp
{
    public partial class Visualization : ContentPage
    {
        private ActualWeather weather;
        public ChartView chartView;

        public Visualization()
        {

            InitializeComponent();

        }

        protected override bool OnBackButtonPressed()
        {

            base.OnBackButtonPressed();

            return true;

        }
        public Visualization(object sender, ActualWeather actuWeather)
        {

            InitializeComponent();

            MenuItemType selectedItem = (MenuItemType)sender;

            weather = actuWeather;
            InitializeChart(selectedItem);

        }


        /// <summary>
        /// Function that look the selected item text from the ListView, and call his own chart. 
        /// </summary>
        /// <param name="selectedItem"></param>
        private void InitializeChart(MenuItemType selectedItem)
        {

            switch (selectedItem)
            {

                case MenuItemType.Temperature:
                    this.Title = "Temperature";
                    TemperatureForecast(weather);
                    break;
                case MenuItemType.MinMaxTemperature:
                    this.Title = "Min/MaxTemperature";
                    MinTemperatureForecast(weather);
                    break;
                case MenuItemType.MinMaxTemperatureHistogram:
                    this.Title = "Min/Max Temp. Historigram";
                    MaxTemperatureForecast(weather);
                    break;
                case MenuItemType.Humidity:
                    this.Title = "Humidity";
                    HumidityForecast(weather);
                    break;
                case MenuItemType.WindSpeed:
                    this.Title = "Wind Speed and Degrees";
                    WindSpeedForecastAsync(weather);
                    break;
                case MenuItemType.SeaLevel:
                    this.Title = "Sea Level";
                    SeaLevelForecast(weather);
                    break;
                //case MenuItemType.GroundLevel:
                  //  this.Title = "Ground Level";
                    //GroundLevelForecast(weather);
                    //break;

            }

        }

        private void TitleSettings(Steema.TeeChart.Chart chart)
        {

            chart.Header.Font.Color = Color.Black;
            chart.Header.Font.Size = 18;
            chart.Axes.Left.Title.Font.Color = Color.FromRgb(80, 80, 80);
            chart.Axes.Left.Title.Font.Size = 14;
            chart.Axes.Bottom.Title.Font.Color = Color.FromRgb(80, 80, 80);
            chart.Axes.Left.Title.Font.Size = 14;
            if (chart.Title.Text.Length > 34) { chart.Title.Font.Size = 12; }
            else if (chart.Title.Text.Length > 26) { chart.Title.Font.Size = 14; }
            else { chart.Title.Font.Size = 18; }

        }

        private void SeriesMarksSettings(Steema.TeeChart.Styles.Series series)
        {
            series.Marks.Transparent = true;
            series.Marks.BackColor = Color.Transparent;
            series.Marks.Shadow.Visible = false;
            series.Marks.FontSeriesColor = true;
            series.Marks.Pen.Visible = false;
        }

        private void AxisSettings(Steema.TeeChart.Chart chart)
        {

            chart.Axes.Bottom.AxisPen.Width = 3;
            chart.Axes.Bottom.AxisPen.Visible = true;
            chart.Axes.Bottom.AxisPen.Color = Color.FromRgb(100, 100, 100);
            chart.Axes.Left.AxisPen.Color = Color.FromRgb(100, 100, 100);
            chart.Axes.Bottom.Labels.Font.Color = Color.FromRgb(100, 100, 100);
            chart.Axes.Left.Labels.Font.Color = Color.FromRgb(100, 100, 100);
            chart.Axes.Bottom.Grid.Visible = false;
            chart.Axes.Bottom.MinimumOffset = 60;
            chart.Axes.Bottom.MaximumOffset = 80;
            chart.Axes.Left.MinimumOffset = 50;
            chart.Axes.Left.MaximumOffset = 50;
            chart.Axes.Bottom.Ticks.Visible = false;
            chart.Axes.Bottom.Ticks.Length = 5;
            chart.Axes.Left.Labels.Font.Size = 12;
            chart.Axes.Bottom.Labels.Font.Size = 11;
            chart.Axes.Bottom.Ticks.Length = 12;
            chart.Axes.Left.Increment = chart.Axes.Left.Maximum / 5;
            chart.Axes.Left.MinorTicks.Visible = true;
            chart.Axes.Left.MinorTicks.Width = 1;
            chart.Axes.Left.MinorTicks.Length = 12;
            chart.Axes.Left.MinorTicks.Transparency = 100;
            chart.Axes.Left.Grid.Color = Color.FromRgb(170, 170, 170);
            chart.Axes.Bottom.Labels.AutoSize = false;
            chart.Axes.Bottom.Labels.CustomSize = 35;

        }

        /// <summary>
        /// Shows the Line Chart from Temperature forecast. 
        /// </summary>
        /// <param name="weather"> Weather info</param>
        private void TemperatureForecast(ActualWeather weather)
        {

            try
            {

                var tChart1 = new Chart();

                tChart1.Axes.Bottom.Labels.Angle = 90;
                tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MMM";
                tChart1.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneDay);
                tChart1.Axes.Left.Title.Text = "Temperature (" + (App.DegTempScale == TempScale.celsius ? "ºC" : "ºF") + ")";

                tChart1.Header.Text = "Average temperature of " + App.Weather.Name;
                tChart1.Header.Alignment = TextAlignment.Center;
                tChart1.Header.TextAlign = TextAlignment.Center;

                double min = App.getDegScaleTemp(weather.LstWeather[0].MinTemperature);
                double max = App.getDegScaleTemp(weather.LstWeather[0].MaxTemperature);

                var avTemp = new Line(tChart1);      
                foreach (var item in weather.LstWeather)
                {
                    if (App.getDegScaleTemp(item.MaxTemperature) > max) max = App.getDegScaleTemp(item.MaxTemperature);
                    if (App.getDegScaleTemp(item.MinTemperature) < min) min = App.getDegScaleTemp(item.MinTemperature);
                    avTemp.Add(item.Date, App.getDegScaleTemp(item.Temperature));
                }

                tChart1.Axes.Left.SetMinMax((int)min - 3, (int)max + 3);
                tChart1.Axes.Bottom.SetMinMax(tChart1.Axes.Bottom.MinXValue + 0.5, tChart1.Axes.Bottom.MaxXValue - 0.5);

                AxisSettings(tChart1);
                TitleSettings(tChart1);
                //SeriesMarksSettings(avTemp);

                ShowChart(tChart1);

                avTemp.Legend.Visible = false;
                avTemp.LinePen.Width = 3;
                avTemp.LinePen.EndCap = Steema.TeeChart.Drawing.PenLineCap.Round;
                avTemp.Color = Color.FromRgb(27, 177, 255);
                avTemp.Marks.Visible = true;
                avTemp.Marks.DrawEvery = 4;
                tChart1.Series.Add(avTemp);

            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e.Message);

            }

        }

        /// <summary>
        /// Shows the Line3D Chart from Minimum Temperature forecast. 
        /// </summary>
        /// <param name="weather"> Weather info</param>
        private void MinTemperatureForecast(ActualWeather weather)
        {

            var tChart1 = new Chart();
            tChart1.Header.Text = "Min Temperature of " + App.Weather.Name;
            tChart1.Legend.Visible = true;
            tChart1.Legend.Alignment = LegendAlignments.Bottom;
            tChart1.Legend.LegendStyle = LegendStyles.Series;
            tChart1.Legend.Transparent = true;
            tChart1.Aspect.View3D = false;
            tChart1.Axes.Bottom.Labels.Angle = 90;
            tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MMM";

            var minTemp = new Line(tChart1.Chart);
            minTemp.Marks.Visible = false;
            double max = App.getDegScaleTemp(weather.LstWeather[0].MinTemperature);
            double min = App.getDegScaleTemp(weather.LstWeather[0].MinTemperature);
            minTemp.LinePen.Width = 3;
            minTemp.Pointer.Visible = true;
            minTemp.Pointer.HorizSize = 3;
            minTemp.Pointer.VertSize = 3;
            minTemp.Pointer.Style = PointerStyles.Sphere;
            minTemp.Pointer.Pen.Visible = false;
            minTemp.LinePen.Color = Color.FromRgb(27, 177, 255);
            minTemp.Color = Color.FromRgb(27, 177, 255);
            minTemp.Title = "Min Temperature";
            minTemp.Marks.Visible = true;
            minTemp.Marks.DrawEvery = 4;

            AxisSettings(tChart1);
            TitleSettings(tChart1);
            //SeriesMarksSettings(minTemp);

            foreach (var item in weather.LstWeather)
            {
                if (App.getDegScaleTemp(item.MinTemperature) > max) max = App.getDegScaleTemp(item.MinTemperature);
                if (App.getDegScaleTemp(item.MinTemperature) < min) min = App.getDegScaleTemp(item.MinTemperature);
                minTemp.Add(item.Date, App.getDegScaleTemp(item.MinTemperature));
            }

            //tChart1.Axes.Left.SetMinMax((int)min - 5, (int)max + 5);
            tChart1.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneDay);
            tChart1.Axes.Bottom.Grid.Visible = false;
            tChart1.Axes.Left.Increment = 4;
            tChart1.Legend.Font.Color = Color.FromRgb(100, 100, 100);

            ShowChart(tChart1);

            

        }

        /// <summary>
        /// Shows the Historigram Chart from Maximum Temperature forecast. 
        /// </summary>
        /// <param name="weather"> Weather info</param>
        private void MaxTemperatureForecast(ActualWeather weather)
        {

            var tChart1 = new Chart();

            tChart1.Aspect.View3D = false;
            tChart1.Legend.Visible = false;
            tChart1.Axes.Bottom.Labels.Angle = 90;
            tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MMM";
            tChart1.Header.Text = "Min/Max Temperature of " + App.Weather.Name;
            var maxTemp = new Histogram(tChart1.Chart);
            var highlow = new HighLow(tChart1.Chart);
            //maxTemp.LinesPen.Visible = false;
            maxTemp.Color = Color.FromRgb(27, 177, 255);
            maxTemp.LinePen.Color = Color.FromRgb(27, 177, 255);
            maxTemp.LinePen.Width = 20;
            maxTemp.LinesPen.Width = 20;
            maxTemp.LinesPen.Visible = true;
            maxTemp.LinePen.Visible = true;
            maxTemp.LinesPen.Color = Color.FromRgb(27, 177, 255);
            highlow.HighPen.Width = 4;
            highlow.LowPen.Width = 4;
            highlow.HighPen.DashCap = Steema.TeeChart.Drawing.PenLineCap.Round;
            highlow.HighPen.EndCap = Steema.TeeChart.Drawing.PenLineCap.Round;
            highlow.HighPen.Style = Steema.TeeChart.Drawing.DashStyle.Solid;
            highlow.LowPen.DashCap = Steema.TeeChart.Drawing.PenLineCap.Round;
            highlow.LowPen.EndCap = Steema.TeeChart.Drawing.PenLineCap.Round;
            highlow.LowPen.Style = Steema.TeeChart.Drawing.DashStyle.Solid;
            highlow.Marks.Visible = true;
            highlow.Marks.DrawEvery = 3;
            highlow.Marks.FollowSeriesColor = true;
            highlow.HighPen.Color = Color.FromRgb(223, 5, 0);
            highlow.LowPen.Color = Color.FromRgb(240, 186, 0);
            highlow.Pen.Visible = false;

            double max = App.getDegScaleTemp(weather.LstWeather[0].MaxTemperature);
            double min = App.getDegScaleTemp(weather.LstWeather[0].MaxTemperature);
            foreach (var item in weather.LstWeather)
            {
                if (App.getDegScaleTemp(item.MaxTemperature) > max) max = App.getDegScaleTemp(item.MaxTemperature);
                if (App.getDegScaleTemp(item.MaxTemperature) < min) min = App.getDegScaleTemp(item.MinTemperature);
                maxTemp.Add(item.Date, App.getDegScaleTemp(item.MaxTemperature));
                highlow.Add(maxTemp.XValues.Last, item.MaxTemperature,item.MinTemperature);
            }
            maxTemp.Marks.AutoPosition = true;
            maxTemp.Marks.Transparent = true;
            tChart1.Axes.Left.SetMinMax((int)min - 3, (int)max + 4);

            tChart1.Axes.Bottom.Increment = Steema.TeeChart.Utils.GetDateTimeStep(Steema.TeeChart.DateTimeSteps.OneDay);
            tChart1.Axes.Bottom.SetMinMax(tChart1.Axes.Bottom.MinXValue + 0.5, tChart1.Axes.Bottom.MaxXValue - 0.5);
            AxisSettings(tChart1);
            TitleSettings(tChart1);
            //SeriesMarksSettings(maxTemp);
            tChart1.Axes.Left.Increment = 4;

            ShowChart(tChart1);

        }

        /// <summary>
        /// Shows the HorizontalBar Chart from Humidity forecast. 
        /// </summary>
        /// <param name="weather"> Weather info</param>
        private void HumidityForecast(ActualWeather weather)
        {

            var tChart1 = new Chart();
            tChart1.Axes.Left.Increment = Steema.TeeChart.Utils.GetDateTimeStep(DateTimeSteps.OneDay);
            tChart1.Aspect.View3D = false;
            tChart1.Legend.Visible = false;
            tChart1.Header.Text = "Humidity of " + App.Weather.Name;

            var humidity = new HorizBar(tChart1);
            humidity.Marks.AutoPosition = true;
            humidity.Marks.Transparent = true;
            humidity.MarksLocation = MarksLocation.End;
            humidity.Marks.Font.Size = 11;
            humidity.Marks.Style = MarksStyles.Value;
            humidity.Marks.Arrow.Color = Color.Transparent;
            humidity.Marks.DrawEvery = 2;

            double max = weather.LstWeather[0].Humidity;
            foreach (var item in weather.LstWeather)
            {
                if (item.Humidity > max) max = item.Humidity;
                humidity.Add(item.Humidity, item.Date);
            }

            tChart1.Legend.Visible = false;
            tChart1.Axes.Bottom.SetMinMax(0, max + 20);
            humidity.Color = Color.FromRgb(27, 177, 255);

            AxisSettings(tChart1);
            TitleSettings(tChart1);
            tChart1.Header.Visible = true;

            ShowChart(tChart1);
        }

        private DashBoard.CircularGaugeChart windSpeed;
        //private RealTimeLine windSpeed2;
        /// <summary>
        /// Shows the Circular Gauge Chart from Wind Speed forecast. 
        /// </summary>
        /// <param name="weather"> Weather info</param>
        private async Task WindSpeedForecastAsync(ActualWeather weather)
        {

            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = 5,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  }
                }

            };

            windSpeed = new DashBoard.CircularGaugeChart(weather);
            //windSpeed2 = new RealTimeLine();
            grid.Children.Add(windSpeed.chartView, 0, 0);
            //grid.Children.Add(windSpeed2.chartView, 0, 1);
            Content = grid;
            
            windSpeed.chartView.Chart.Header.Font.Size = 15;
            //windSpeed2.chartView.Chart.Header.Font.Size = 15;
            windSpeed.chartView.Chart.Header.Font.Color = Color.White;
            //windSpeed2.chartView.Chart.Header.Font.Color = Color.White;
            windSpeed.chartView.Chart.SubHeader.Visible = true;
            windSpeed.chartView.Chart.SubHeader.Font.Color = Color.White;
            windSpeed.chartView.Chart.SubHeader.Alignment = TextAlignment.End;
            windSpeed.chartView.Chart.SubHeader.Font.Size += 4;

        }

        public void RefreshCircularGauge()
        {

            this.Content = null;
            windSpeed = null;
            //windSpeed2 = null;

            WindSpeedForecastAsync(weather);
            RefreshCircularGaugeAnimationAsync();

        }

        private async Task RefreshCircularGaugeAnimationAsync()
        {

            #region ANIMATED

            int i = 0;
            bool ended = false;

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
                    windSpeed.chartView.Chart.Header.Text = string.Format("{0:0.00} m/s - {1:0.00} º", item.WindSpeed, item.WindDegree);
                    windSpeed.chartView.Chart.SubHeader.Text = item.Date.ToString();
                    //windSpeed2.chartView.Chart.Header.Text = string.Format("{0:0.00} m/s - {1:0.00} º", item.WindSpeed, item.WindDegree);

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
                                    //windSpeed2.chartView.Chart.Axes.Bottom.SetMinMax(weather.LstWeather[0].Date, temps);
                                    //windSpeed2.wndSpeedLinear.Add(temps, linearSpeed);
                                    windSpeed.wndSpeedGauge.Value += 0.15;
                                }
                                else
                                {
                                    //windSpeed2.wndSpeedLinear.Add(item.Date, item.WindSpeed);
                                    windSpeed.wndSpeedGauge.Value = item.WindSpeed;
                                    endUp = true;
                                }
                                //windSpeed2.chartView.Chart.Axes.Bottom.SetMinMax(weather.LstWeather[0].Date, item.Date);
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
                                    //windSpeed2.chartView.Chart.Axes.Bottom.SetMinMax(weather.LstWeather[0].Date, temps);
                                    //windSpeed2.wndSpeedLinear.Add(temps, linearSpeed);
                                    windSpeed.wndSpeedGauge.Value -= 0.15;
                                }
                                else
                                {
                                    //windSpeed2.wndSpeedLinear.Add(item.Date, item.WindSpeed);
                                    windSpeed.wndSpeedGauge.Value = item.WindSpeed;
                                    endDown = true;
                                }
                                //windSpeed2.chartView.Chart.Axes.Bottom.SetMinMax(weather.LstWeather[0].Date, item.Date);
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

                //ShowChart(windSpeed.chartView.Chart);
                //ShowChart(windSpeed2.chartView.Chart);

            }
            catch (ObjectDisposedException)
            {
                ended = true;
            }

            //ShowChart(windSpeed.chartView.Chart);
            //ShowChart(windSpeed2.chartView.Chart);

            #endregion


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

        /// <summary>
        /// Shows the Area Chart from Pressure Sea Level forecast.
        /// </summary>
        /// <param name="weather"> Weather info</param>
        private void SeaLevelForecast(ActualWeather weather)
        {
            var tChart1 = new Chart();
            tChart1.Zoom.Active = false;            
            tChart1.Aspect.View3D = false;
            tChart1.Legend.Visible = false;
            tChart1.Panning.Allow = ScrollModes.None;
            tChart1.Header.Text = "Sea Level of " + App.Weather.Name;

            var seaLevel = new Area(tChart1);
            foreach (var item in weather.LstWeather)
            {
                seaLevel.Add(item.Date, item.SeaLevel);
            }

            seaLevel.Legend.Visible = true;
            seaLevel.Color = Color.FromRgb(27, 177, 255); //  FromHex("#084B8A");
            seaLevel.Stairs = false;
            seaLevel.LinePen.Visible = false;
            seaLevel.AreaLinesPen.Visible = false;

            AxisSettings(tChart1);
            TitleSettings(tChart1);

            tChart1.Axes.Left.Increment = 4;

            ShowChart(tChart1);
        }

        /// <summary>
        /// Shows the Surface Chart from Pressure Ground Level forecast. 
        /// </summary>
        /// <param name="weather"> Weather info</param>
        private void GroundLevelForecast(ActualWeather weather)
        {
            var tChart1 = new Chart();
            tChart1.Axes.Left.Title.Text = "Hours";
            tChart1.Axes.Bottom.Title.Text = "Days";
            tChart1.Legend.Visible = false;
            tChart1.Panning.Allow = ScrollModes.None;
            tChart1.Header.Text = "Ground Level of " + App.Weather.Name;
            double min = weather.LstWeather[0].GroundLevel;
            double max = weather.LstWeather[0].GroundLevel;

            var groundLevel = new ColorGrid(tChart1);
            groundLevel.FillSampleValues();
            
            groundLevel.IrregularGrid = true;

            foreach (var item in weather.LstWeather)
            {
                Debug.WriteLine(item.Date.Day+";"+item.GroundLevel+";"+item.Date.Hour);
                groundLevel.Add(item.Date.Day, item.GroundLevel, item.Date.Hour);
            }

            groundLevel.StartColor = Color.FromHex("#F2B551");
            groundLevel.EndColor = Color.FromHex("#ED8256");
            groundLevel.MidColor = Color.FromHex("#ED8256");
            //tChart1.AfterDraw += new PaintChartEventHandler(this.tChart1_AfterDraw);
            groundLevel.Marks.Visible = false;

            AxisSettings(tChart1);
            TitleSettings(tChart1);
            SeriesMarksSettings(groundLevel);
            
            ShowChart(tChart1);
        }

        /// <summary>
        /// Display on the screen the created Chart. 
        /// </summary>
        /// <param name="tChart1"></param>
        private void ShowChart(Chart tChart1)
        {

            if (tChart1 != null)
            {
                chartView = new ChartView
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                chartView.Chart = tChart1;
                Content = new StackLayout
                {
                    WidthRequest = 100,
                    HeightRequest = 100,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = 5,
                    Children =
                    {
                        chartView,
                    }

                };
            }

        }

        private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            Chart tChart1 = (Chart)sender;
            ColorGrid colorGrid1 = (ColorGrid)tChart1[0];
            g.Font.Size = 20;
            string myStr = "";
            Color newColor;
            ColorList lstColor = new ColorList();
            double y, x;
            for (int i = 0; i < colorGrid1.Count; i++)
            {
            myStr = colorGrid1.YValues.Value[i].ToString("0.00");
            y = colorGrid1.GetVertAxis.CalcPosValue(colorGrid1.ZValues[i]);

            x = colorGrid1.GetHorizAxis.CalcPosValue(colorGrid1.XValues[i]);

            newColor = colorGrid1.ValueColor(i).Luminosity > 0.5f ? Color.Black : Color.White;

            double strWdth = g.TextWidth(myStr);
            double strHght = g.TextHeight(myStr);

    //        g.Rectangle(x - (strWdth / 2), y - (strHght / 2), x + (strWdth / 2), y + (strHght / 2));

            g.Font.Color = newColor;
            g.Font.Size = 12;
            g.TextOut(
                x + colorGrid1.GetHorizAxis.CalcSizeValue(0.25),
                y - colorGrid1.GetVertAxis.CalcSizeValue(1.25),
                myStr);
            }

        }
        private void tChart1_AfterDrawMaxMin(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            Chart tChart1 = (Chart)sender;
            Line minTempLine = (Line)tChart1[0];

            int textMargin = 4;

            g.Font.Size = 12;
            g.BackColor = Color.White;
            g.Font.Color = Color.White;
            
            List<int> indexMin = new List<int>();
            List<int> indexMax = new List<int>();
            bool down = false;
            double x, y;
            if (minTempLine[0].Y > minTempLine[1].Y) down = true;
            for (int i = 1; i <= minTempLine.Count; i++)
            {
                if (down)
                {
                    if (minTempLine[i].Y > minTempLine[i - 1].Y)
                    {
                    down = false;
                    indexMin.Add(i - 1);
                    }
                }
                else
                {
                    if (minTempLine[i].Y < minTempLine[i - 1].Y)
                    {
                        down = true;
                        indexMax.Add(i - 1);
                    }
                }
            }
            foreach (int i in indexMin)
            {
                //low
                y = minTempLine.GetVertAxis.CalcYPosValue(minTempLine.YValues[i]);

                x = minTempLine.GetHorizAxis.CalcXPosValue(minTempLine.XValues[i]);

                string outStr = minTempLine.YValues[i].ToString("0.0") + (App.DegTempScale == TempScale.celsius ? " ºC" : " ºF").ToString();

                double strWdth = g.TextWidth(outStr);
                double strHght = g.TextHeight(outStr);

                    //g.Rectangle(x - (strWdth / 2) - textMargin, y - (textMargin/2), x + (strWdth / 2) + textMargin, y + (strHght * 1.2) + textMargin);

                g.TextOut(
                    x - (g.TextWidth(outStr)/2),
                    y,
                    outStr);
            }
            foreach (int i in indexMax)
            {
                //high
                y = minTempLine.GetVertAxis.CalcYPosValue(minTempLine.YValues[i]);

                x = minTempLine.GetHorizAxis.CalcXPosValue(minTempLine.XValues[i]);

                string outStr = minTempLine.YValues[i].ToString("0.0") + (App.DegTempScale == TempScale.celsius ? " ºC" : " ºF").ToString();

                double strWdth = g.TextWidth(outStr);
                double strHght = g.TextHeight(outStr);

                // g.Rectangle(x - (strWdth / 2) - textMargin, y - strHght - textMargin, x + (strWdth / 2), y + textMargin);

                g.TextOut(
                    x - (g.TextWidth(outStr) / 2),
                    y - (g.TextHeight("W") * 1.2),
                    outStr);
            }

        }

    }
}

