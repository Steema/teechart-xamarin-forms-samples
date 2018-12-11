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
    public partial class GroundLevel : ContentPage
    {
        public GroundLevel()
        {
            InitializeComponent();
            this.Title = "Pressure on the ground level";
            GroundLevelForecast(App.Weather);
        }
        private void GroundLevelForecast(ActualWeather weather)
        {
            Chart tChart1 = new Chart();
            tChart1.Axes.Bottom.Increment = 1;
            tChart1.Axes.Bottom.Labels.Font.Color = Color.White;
            tChart1.Axes.Bottom.Ticks.Length = 10;
            tChart1.Axes.Bottom.Labels.Font.Size = 15;
            tChart1.Axes.Bottom.Title.Text = "Days";
            tChart1.Axes.Bottom.Title.Font.Color = Color.White;
            tChart1.Axes.Left.Increment = 1;
            tChart1.Axes.Left.Labels.Font.Color = Color.White;
            tChart1.Axes.Left.Labels.Font.Size = 15;
            tChart1.Axes.Left.Title.Text = "Hours";
            tChart1.Axes.Left.MinorTicks.Visible = false;
            tChart1.Axes.Left.Title.Font.Size = 15;
            tChart1.Axes.Left.Title.Font.Color = Color.White;
            tChart1.Axes.Left.Title.Gradient.Visible = false;
            tChart1.Axes.Left.Ticks.Length = 10;
            tChart1.Header.Visible = false;
            tChart1.Panel.Visible = true;
            tChart1.Panel.Gradient.Visible = false;
            tChart1.Panel.Transparent = false;
            tChart1.Panel.MarginBottom = 5;
            tChart1.Panel.MarginLeft = 5;
            tChart1.Panel.MarginRight = 5;
            tChart1.Panel.MarginTop = 5;
            tChart1.Panel.Color = Color.FromHex("#61493d");
            tChart1.Walls.Back.Visible = true;
            tChart1.Walls.Back.Transparent = false;
            tChart1.Walls.Back.Gradient.Visible = false;
            tChart1.Walls.Back.Color = Color.White;
            tChart1.Aspect.View3D = false;
            tChart1.Zoom.Direction = ZoomDirections.None;
            tChart1.Legend.Visible = false;
            tChart1.Panning.Allow = ScrollModes.None;
            double min = weather.LstWeather[0].GroundLevel;
            double max = weather.LstWeather[0].GroundLevel;

            var groundLevel = new ColorGrid(tChart1.Chart);

            foreach (var item in weather.LstWeather)
            {
                groundLevel.Add(item.Date.Day, item.GroundLevel, item.Date.Hour);
            }

            groundLevel.StartColor = Color.White;
            groundLevel.EndColor = Color.Black;
            groundLevel.MidColor = Color.FromHex("#49311c");
            tChart1.AfterDraw += new PaintChartEventHandler(this.tChart1_AfterDraw);
            groundLevel.Marks.Visible = false;

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
                g.Font.Color = newColor;
                g.TextOut(
                    x + colorGrid1.GetHorizAxis.CalcSizeValue(0.25),
                    y - colorGrid1.GetVertAxis.CalcSizeValue(1.25),
                    myStr);
            }


        }
    }
}
