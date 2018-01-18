using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace TeeChartDemo.PCL.Other
{
    public partial class ColorLineTool : ContentPage
    {
        ChartView tChart1 = new ChartView();

        public ColorLineTool()
        {
            InitializeChart();

            Content = new StackLayout
            {
                Children = { tChart1 },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
        }

        private Line line1;
        private Line line2;
        private Steema.TeeChart.Tools.ColorLine colorlinetTool;

        private void InitializeChart()
        {           
            tChart1.Chart.Series.Add(line1 = new Line());
            tChart1.Chart.Series.Add(line2 = new Line());
            line1.FillSampleValues();
            line2.FillSampleValues();

            tChart1.Chart.Axes.Bottom.Grid.Visible = false;
            tChart1.Chart.Aspect.View3D = false;

            tChart1.Chart.Tools.Add(colorlinetTool = new Steema.TeeChart.Tools.ColorLine());
            colorlinetTool.Axis = tChart1.Chart.Axes.Bottom;
            colorlinetTool.Value = 10;
            colorlinetTool.Pen.Color = Color.Red;
            colorlinetTool.Pen.Width = 2;
            colorlinetTool.ColorLineClickTolerance = 10;

            tChart1.Chart.Panning.Active = true;
            tChart1.Chart.Panning.Allow = ScrollModes.Both;
            tChart1.Chart.Zoom.Active = true;

            tChart1.Chart.Axes.Left.Increment = line1.YValues.Maximum / 5;
            tChart1.Chart.Walls.Visible = false;
            tChart1.Chart.Legend.Alignment = LegendAlignments.Bottom;
            tChart1.Chart.Legend.Transparent = true;
            tChart1.Chart.Title.Text = "Chart with a ColorLine Tool";
            tChart1.Chart.Title.Font.Color = Color.Gray;
        }
    }
}
