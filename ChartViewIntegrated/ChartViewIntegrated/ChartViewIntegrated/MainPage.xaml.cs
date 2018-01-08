using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace ChartViewIntegrated
{
    public partial class MainPage : ContentPage
    {    
        public MainPage()
        {
            InitializeComponent();

            /* Create ChartView by code at ContentPage */
            ChartView BarChart = new ChartView();

            BarChart.WidthRequest = 400;
            BarChart.HeightRequest = 300;

            Content = new StackLayout
            {
                Children =
                  {
                    BarChart
                  },
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            
            BarChart.Chart.Series.Add(new Bar());
            double[] YValues = new double[] { 4000, 2500, 2200, 2000, 1800, 1700, 1500, 1300, 1100, 1000, 900, 850 };
            string[] Labels = new string[] { "USA","China","Japan","Germany","UK","France","India","Spain","Netherlands","Russia","South Korea","Canada"};

            BarChart.Chart.Series[0].Add(YValues);
            BarChart.Chart.Series[0].Labels.AddRange(Labels);
            (BarChart.Chart.Series[0] as Bar).ColorEach = true;
            (BarChart.Chart.Series[0] as Bar).Pen.Visible = false;
            (BarChart.Chart.Series[0] as Bar).Marks.Visible = false;
            BarChart.Chart.Panel.Gradient.Visible = false;
            BarChart.Chart.Panel.Color = Color.White;
            BarChart.Chart.Walls.Left.Color = Color.White;
            BarChart.Chart.Walls.Bottom.Color = Color.White;
            BarChart.Chart.Walls.Back.Transparent = true;
            BarChart.Chart.Walls.Back.Pen.Color = Color.LightGray;
            BarChart.Chart.Legend.Visible = false;
            BarChart.Chart.Aspect.Chart3DPercent += 5;
            BarChart.Chart.Aspect.ColorPaletteIndex = 17;
            BarChart.Chart.Title.Text = "TeeChart for Xamarin.Forms";
            BarChart.Chart.Title.Alignment = TextAlignment.End;
            BarChart.Chart.Axes.Left.Title.Text = "Visitors";
            BarChart.Chart.Axes.Left.Increment = 500;
            BarChart.Chart.Axes.Left.AxisPen.Visible = false;
            BarChart.Chart.Axes.Bottom.AxisPen.Visible = false;
            BarChart.Chart.Axes.Bottom.Labels.Angle = 90;
            BarChart.Chart.Panel.MarginBottom += 25;
            BarChart.Chart.Panel.MarginLeft -= 1;
            BarChart.Chart.Title.Font.Color = Color.Gray;
            BarChart.Chart.Walls.Left.Pen.Width = 1;
            BarChart.Chart.Walls.Bottom.Pen.Width = 2;
            BarChart.Chart.Walls.Left.Pen.Color = Color.LightGray;
            BarChart.Chart.Walls.Bottom.Pen.Color = Color.LightGray;

            if (Device.OS == TargetPlatform.Windows)
            {
                BarChart.Chart.Walls.Back.Gradient.Visible = false;
                BarChart.Chart.Walls.Back.Color = Color.White;
                BarChart.Chart.Panel.MarginBottom -= 25;
                BarChart.Chart.Axes.Left.MinimumOffset = 5;
                BarChart.Chart.Axes.Left.MaximumOffset = 4;
            }
        }
    }
}
