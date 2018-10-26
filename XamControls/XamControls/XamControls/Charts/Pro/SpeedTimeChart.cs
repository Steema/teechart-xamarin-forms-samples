using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Services.Timer;

namespace XamControls.Charts.Pro
{
    public class SpeedTimeChart
    {

        private Line line1;
        private Line line2;
        private Line line3;
        private Variables.Variables var;
        private ChartView BaseChart;
        public SpeedTimeChart(ChartView BaseChart)
        {

            line1 = new Line();
            line2 = new Line();
            line3 = new Line();
            var = new Variables.Variables();
            this.BaseChart = BaseChart;

            BaseChart.Chart.Title.Text = "Real Time Charting";

            line1.FillSampleValues(2);
            line2.FillSampleValues(2);
            line3.FillSampleValues(2);

            line1.Color = var.GetPaletteBasic[0];
            line2.Color = var.GetPaletteBasic[1];
            line3.Color = var.GetPaletteBasic[2];
            line1.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);
            line2.LinePen.Color = var.GetPaletteBasic[1].AddLuminosity(-0.2);
            line3.LinePen.Color = var.GetPaletteBasic[2].AddLuminosity(-0.2);

            line1.LinePen.Width = 3;
            line2.LinePen.Width = 3;
            line3.LinePen.Width = 3;
            line1.Title = "Line1";
            line2.Title = "Line2";
            line3.Title = "Line3";

            BaseChart.Chart.Series.Add(line1);
            BaseChart.Chart.Series.Add(line2);
            BaseChart.Chart.Series.Add(line3);

		    BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
		    BaseChart.Chart.Axes.Left.Visible = true;
		    BaseChart.Chart.Axes.Bottom.Visible = true;
            BaseChart.Chart.Axes.Left.Grid.Visible = true;

		    BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
            BaseChart.Chart.Axes.Left.Automatic = true;
            BaseChart.Chart.Axes.Left.Increment = 100;
            BaseChart.Chart.Axes.Bottom.Automatic = true;
            BaseChart.Chart.AfterDraw += Chart_AfterDraw;

        }

        Random r = new Random();
        bool stop = false;

        private void Chart_AfterDraw(object sender, Graphics3D g)
        {

            Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
            {

                if (!stop)
                {

                    line1.Add(r.Next(0, Convert.ToInt32(line1.MaxYValue() / 2)));
                    line2.Add(r.Next(Convert.ToInt32(line2.MaxYValue() / 2), Convert.ToInt32(line2.MaxYValue())));
                    line3.Add(r.Next(Convert.ToInt32(line3.MaxYValue() / 3), Convert.ToInt32(line3.MaxYValue())));

                    if (line1.Count > 15) { BaseChart.Chart.Axes.Bottom.SetMinMax(line1.Count - 15, line1.Count); }

                    return false;

                }
                else { return true; }

            });
            
        }

        public void RemoveEvent()
        {

            stop = true;
            BaseChart.Chart.AfterDraw -= Chart_AfterDraw;

        }

    }
}
