using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using Steema.TeeChart.Themes;
using Steema.TeeChart.Drawing;

namespace TeeChartDemo.PCL.Other
{
    public partial class SubChartTool : ContentPage
    {
        Chart tChart1 = new Chart();        

        public SubChartTool()
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
        private Steema.TeeChart.Tools.SubChartTool subChartTool1;
        private void InitializeChart()
        {
            Chart chart;            
            tChart1.Series.Add(line1 = new Line());
            tChart1.Series.Add(line2 = new Line());
            line1.FillSampleValues();
            line2.FillSampleValues();

            tChart1.Axes.Bottom.Grid.Visible = false;            
            tChart1.Aspect.View3D = false;

            tChart1.Tools.Add(subChartTool1 = new Steema.TeeChart.Tools.SubChartTool());

            tChart1.Panning.Active = true;

            chart = subChartTool1.Charts.AddChart("Chart0");
            chart.Panel.Color = Color.Transparent;
            chart.Series.Add(new Bar());
            chart.Aspect.View3D = false;
            chart.Series[0].FillSampleValues();
            chart.Series[0].ColorEach = true;
            (chart.Series[0] as Bar).Pen.Visible = false;
            chart[0].Marks.Visible = false;
            chart[0].Chart.Title.Visible = false;
            subChartTool1.Charts[0].Left = 50;
            subChartTool1.Charts[0].Top = 35;            
            subChartTool1.Charts[0].Chart.Walls.Visible = false;

            for (int j = 0; j < subChartTool1.Charts.Count; j++)
            {
                chart = subChartTool1.Charts[j].Chart;
                for (int i = 0; i < line1.Count; i++)
                {
                    chart[0].Add(line1.XValues[i], line1.YValues[i]);
                }
            }

            tChart1.Axes.Left.Increment = line1.YValues.Maximum / 5;            
            tChart1.Walls.Visible = false;
            tChart1.Legend.Alignment = LegendAlignments.Bottom;
            tChart1.Legend.Transparent = true;
            tChart1.Title.Text = "Chart with a SubChart Tool";
            tChart1.Title.Font.Color = Color.Gray;
        }
    }
}
