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
        Chart tChart1 = new Chart();

        public ColorLineTool()
        {
            ChartView chartView1 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //WidthRequest = 400,
                //HeightRequest = 
            };

            InitializeChart();

            chartView1.Model = tChart1;

            Content = new StackLayout
            {
                Children = { chartView1 }
            };
        }

        private Line line1;
        private Line line2;
        private Steema.TeeChart.Tools.ColorLine colorlinetTool;

        private void InitializeChart()
        {           
            tChart1.Series.Add(line1 = new Line());
            tChart1.Series.Add(line2 = new Line());
            line1.FillSampleValues();
            line2.FillSampleValues();

            tChart1.Axes.Bottom.Grid.Visible = false;
            tChart1.Aspect.View3D = false;            

            tChart1.Tools.Add(colorlinetTool = new Steema.TeeChart.Tools.ColorLine());
            colorlinetTool.Axis = tChart1.Axes.Bottom;
            colorlinetTool.Value = 10;
            colorlinetTool.Pen.Color = Color.Red;
            colorlinetTool.Pen.Width = 2;
            colorlinetTool.ColorLineClickTolerance = 10;

            tChart1.Panning.Active = true;
            tChart1.Panning.Allow = ScrollModes.Both;
            tChart1.Zoom.Active = true;

            tChart1.Axes.Left.Increment = line1.YValues.Maximum / 5;
            tChart1.Walls.Visible = false;
            tChart1.Legend.Alignment = LegendAlignments.Bottom;
            tChart1.Legend.Transparent = true;
            tChart1.Title.Text = "Chart with a ColorLine Tool";
            tChart1.Title.Font.Color = Color.Gray;
        }
    }
}
