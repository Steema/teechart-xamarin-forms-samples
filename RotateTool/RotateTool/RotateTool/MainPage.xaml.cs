using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RotateTool
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BackgroundColor = Color.White;

            /* Create ChartView by code at ContentPage */
            ChartView LineChart = new ChartView();

            LineChart.HorizontalOptions = LayoutOptions.FillAndExpand;
            LineChart.VerticalOptions = LayoutOptions.FillAndExpand;

            Content = new StackLayout
            {
                Children =
                {
                    new StackLayout()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.Start,
                        BackgroundColor = Color.FromRgb(10,170,255),
                        Children =
                        {
                            new Label()
                            {
                                FontSize = 20,
                                Text = "Drag to Rotate!",
                                TextColor = Color.White,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.Start,
                                HorizontalTextAlignment = TextAlignment.Center,
                                VerticalTextAlignment = TextAlignment.Center,
                                Margin = new Thickness(0,15,0,15),
                            }
                        }
                    },
                    LineChart
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            LineChart.Chart.Series.Add(new Line());
            double[] YValues = new double[] { 4000, 2500, 2200, 2000, 1800, 1700, 1500, 1300, 1100, 1000, 900, 850 };

            LineChart.Chart.Series[0].Add(YValues);
            (LineChart.Chart.Series[0] as Line).Marks.Visible = false;
            LineChart.Chart.Panel.Gradient.Visible = false;
            LineChart.Chart.Panel.Color = Color.White;
            LineChart.Chart.Walls.Left.Color = Color.LightGray;
            LineChart.Chart.Walls.Bottom.Color = Color.LightGray;
            LineChart.Chart.Walls.Back.Pen.Color = Color.LightGray;
            LineChart.Chart.Legend.Visible = true;
            LineChart.Chart.Legend.Alignment = LegendAlignments.Left;
            LineChart.Chart.Legend.VertMargin = 15;
            LineChart.Chart.Aspect.Chart3DPercent += 5;
            LineChart.Chart.Aspect.ColorPaletteIndex = 17;
            LineChart.Chart.Title.Text = "";
            LineChart.Chart.Axes.Left.Increment = 500;
            LineChart.Chart.Axes.Left.AxisPen.Visible = false;
            LineChart.Chart.Axes.Bottom.AxisPen.Visible = false;
            LineChart.Chart.Panel.MarginBottom += 25;
            LineChart.Chart.Panel.MarginLeft -= 1;
            LineChart.Chart.Walls.Left.Pen.Width = 1;
            LineChart.Chart.Walls.Bottom.Pen.Width = 2;
            LineChart.Chart.Walls.Left.Pen.Color = Color.LightGray;
            LineChart.Chart.Walls.Bottom.Pen.Color = Color.LightGray;
            LineChart.Chart.Axes.Left.MinorTicks.Visible = true;
            LineChart.Chart.Axes.Left.MinorTicks.Length = 5;
            LineChart.Chart.Axes.Left.MinorTicks.Transparency = 100;
            LineChart.Chart.Axes.Bottom.MinorTicks.Visible = true;
            LineChart.Chart.Axes.Bottom.MinorTicks.Length = 5;
            LineChart.Chart.Axes.Bottom.MinorTicks.Transparency = 100;

            Rotate RotateTool = new Rotate(LineChart.Chart);

            if (Device.RuntimePlatform == Device.UWP)
            {
                LineChart.Chart.Title.Text = "";
                LineChart.Chart.Walls.Back.Gradient.Visible = false;
                LineChart.Chart.Walls.Back.Color = Color.White;
                LineChart.Chart.Panel.MarginBottom -= 25;
                LineChart.Chart.Axes.Left.MinimumOffset = 5;
                LineChart.Chart.Axes.Left.MaximumOffset = 4;
                LineChart.Chart.Panning.Allow = ScrollModes.None;
            }
        }
    }
}
