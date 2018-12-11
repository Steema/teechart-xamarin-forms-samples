using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace WeatherApp.DashBoard
{
    public class LineTemperaturePage : ContentPage
    {

        public ChartView chartView;
        public ObservableCollection<ChartView> lstChart = new ObservableCollection<ChartView>();

        public ObservableCollection<ChartView> LstChart
        {

            get { return lstChart; }
            set { lstChart = value; }
        }

        public LineTemperaturePage(ActualWeather weather)
        {

            double min = App.getDegScaleTemp(weather.LstWeather[0].MinTemperature);
            double max = App.getDegScaleTemp(weather.LstWeather[0].MaxTemperature);
            DateTime date = DateTime.ParseExact(weather.LstWeather[0].Date.ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            InitializeChart(chartView.Chart, date);
            var LineTemp = new Line(chartView.Chart);
            foreach (var item in weather.LstWeather)
            {
                if (TimerUpdate(date, item.Date))
                {
                    date = item.Date;
                    chartView = new ChartView();
                    InitializeChart(chartView.Chart, item.Date);
                    LineTemp = new Line(chartView.Chart);
                    LstChart.Add(chartView);

                }
                LineTemp.Add(item.Date, App.getDegScaleTemp(item.Temperature));
                if (App.getDegScaleTemp(item.Temperature) > max) max = App.getDegScaleTemp(item.Temperature);
                if (App.getDegScaleTemp(item.Temperature) < min) min = App.getDegScaleTemp(item.Temperature);
                chartView.Chart.Legend.Alignment = LegendAlignments.Bottom;
                chartView.Chart.Legend.TextAlign = TextAlignment.Start;
                //LineTemp.Color = Color.FromHex("#0e661f");
                LineTemp.Legend.TextAlign = TextAlignment.Start;
                LineTemp.Legend.Visible = false;
                LineTemp.Marks.Visible = true;
                LineTemp.LinePen.Width = 8;
                LineTemp.Pointer.Pen.Width = 5;
                LineTemp.Marks.Font.Size = 45;
                LineTemp.Marks.Font.Name = "Verdana";
                LineTemp.LinePen.EndCap = Steema.TeeChart.Drawing.PenLineCap.Round;
                //LineTemp.Marks.ArrowLength = -20;
                chartView.Chart.Axes.Left.SetMinMax(min - 2, max + 2);
            }
        }

        private void InitializeChart(Chart c, DateTime date)
        {
            c.setTheme(ThemeType.Report);
            c.Axes.Left.Increment = 1;
            c.Axes.Right.Increment = 5;
            /*c.Axes.Bottom.Ticks.Length = 15;
            c.Axes.Bottom.Labels.Font.Size = 12;
            c.Axes.Bottom.Title.Font.Size = 15;
            c.Axes.Bottom.Ticks.Visible = true;
            c.Axes.Left.Ticks.Visible = true;
            c.Axes.Left.Title.Font.Size = 15;
            c.Axes.Left.Ticks.Length = 15;
            c.Axes.Left.Labels.Font.Size = 12;
            c.Axes.Left.MinorTicks.Visible = false;*/
            c.Header.Text = date.DayOfWeek + " ,  " + date.Day + " " + date.ToString("MMM");
            c.Axes.Left.Title.Text = App.DegTempScale == TempScale.celsius ? " ºC" : " ºF";
            /*c.Header.Font.Size = 30;
            c.Header.Alignment = TextAlignment.Center;
            c.Aspect.View3D = false;
            c.Panel.Pen.Visible = true;
            c.Panel.MarginBottom = 5;
            c.Panel.MarginLeft = 5;
            c.Panel.MarginRight = 5;
            c.Panel.MarginTop = 5;
            c.Legend.Visible = false;
            c.Walls.Back.Brush.Visible = true;
            c.Walls.Back.Transparent = false;
            c.Panel.Visible = false;
            c.Walls.Back.Gradient.Visible = false;
            c.Walls.Back.Color = Color.White;*/
            c.Panning.Allow = ScrollModes.None;
            c.Axes.Automatic = true;
        }

        private bool TimerUpdate(DateTime date, DateTime itemDate)
        {
            bool update = false;
            if (itemDate.Day - date.Day >= 1) update = true;
            return update;
        }
    }
}
