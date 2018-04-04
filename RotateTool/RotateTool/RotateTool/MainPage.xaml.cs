using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;

namespace RotateTool
{
    public partial class MainPage : ContentPage
    {    
        public MainPage()
        {
            InitializeComponent();

            /* Create ChartView by code at ContentPage */
            ChartView LineChart = new ChartView();

            LineChart.WidthRequest = 400;
            LineChart.HeightRequest = 300;

            Content = new StackLayout
            {
                Children =
                  {
                    LineChart
                  },
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            
            LineChart.Chart.Series.Add(new Line());
            double[] YValues = new double[] { 4000, 2500, 2200, 2000, 1800, 1700, 1500, 1300, 1100, 1000, 900, 850 };

            LineChart.Chart.Series[0].Add(YValues);
            (LineChart.Chart.Series[0] as Line).Marks.Visible = false;
            LineChart.Chart.Panel.Gradient.Visible = false;
            LineChart.Chart.Panel.Color = Color.White;
            LineChart.Chart.Walls.Left.Color = Color.White;
            LineChart.Chart.Walls.Bottom.Color = Color.White;
            LineChart.Chart.Walls.Back.Transparent = true;
            LineChart.Chart.Walls.Back.Pen.Color = Color.LightGray;
            LineChart.Chart.Legend.Visible = true;
            LineChart.Chart.Aspect.Chart3DPercent += 5;
            LineChart.Chart.Aspect.ColorPaletteIndex = 17;
            LineChart.Chart.Title.Text = "Drag to Rotate !";
            LineChart.Chart.Title.Alignment = TextAlignment.End;
            LineChart.Chart.Axes.Left.Increment = 500;
            LineChart.Chart.Axes.Left.AxisPen.Visible = false;
            LineChart.Chart.Axes.Bottom.AxisPen.Visible = false;
            LineChart.Chart.Panel.MarginBottom += 25;
            LineChart.Chart.Panel.MarginLeft -= 1;
            LineChart.Chart.Title.Font.Color = Color.Gray;
            LineChart.Chart.Walls.Left.Pen.Width = 1;
            LineChart.Chart.Walls.Bottom.Pen.Width = 2;
            LineChart.Chart.Walls.Left.Pen.Color = Color.LightGray;
            LineChart.Chart.Walls.Bottom.Pen.Color = Color.LightGray;

            Rotate RorateTool = new Rotate(LineChart.Chart);


            if (Device.OS == TargetPlatform.Windows)
            {
                LineChart.Chart.Title.Text = "";
                LineChart.Chart.Walls.Back.Gradient.Visible = false;
                LineChart.Chart.Walls.Back.Color = Color.White;
                LineChart.Chart.Panel.MarginBottom -= 25;
                LineChart.Chart.Axes.Left.MinimumOffset = 5;
                LineChart.Chart.Axes.Left.MaximumOffset = 4;
            }
        }
    }
}
