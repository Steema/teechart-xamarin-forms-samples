using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Statistical
{
    public class SPCProFunctionChart
    {

		private Line lineGood;
        private Line lineBad;
        private Variables.Variables var;
        private ChartView BaseChart;

		public SPCProFunctionChart(ChartView BaseChart)
		{

			lineGood = new Line();
			lineBad = new Line();
			var = new Variables.Variables();
            this.BaseChart = BaseChart;

            BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.AxisPen.Transparency = 100;
            BaseChart.Chart.Axes.Left.MinorTicks.Transparency = 100;
            BaseChart.Chart.Axes.Left.Ticks.Visible = false;
			BaseChart.Chart.Axes.Bottom.Automatic = true;
			BaseChart.Chart.Title.Text = "Quality Control";
            BaseChart.Chart.AfterDraw += Chart_AfterDraw;

			lineBad.Title = "Line 1";
            lineBad.Marks.Visible = true;
			lineGood.Title = "Line 2";
            lineGood.Marks.Visible = true;

			Function_SPC();

            BaseChart.Chart.Series.Add(lineBad);
            BaseChart.Chart.Series.Add(lineGood);

        }

        private bool isRepainted = false; 
        private void Chart_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {

            if (!isRepainted)
            {

                var chart = sender as Chart;
                double maxValue = chart.Axes.Left.MaxYValue + 100;
                chart.Chart.Axes.Left.Automatic = false;
                chart.Axes.Left.SetMinMax(0, maxValue);
                isRepainted = true;
                chart.Draw();

            }

        }

        private void CalcLimits(Series Good, Series Bad)
		{

			double sum, sumn, tmp, aux,
				lcp, lcn, numtotal, percent;
			int n;
            n = 0;
			sum = 0.0;
			sumn = 0.0;
			for (int i = 0; i < Good.Count; i++)
			{
				percent = (Bad.YValues[i] * Good.YValues[i] / 100.0);
				numtotal = Good.YValues[i] + percent;
				if (numtotal > 0)
				{
					sum += percent / numtotal;
					sumn += numtotal;
					n++;
				}
			}
			lcp = sum / n;
			lcn = sumn / n;
			tmp = (lcp * (1.0 - lcp)) / lcn;
			if (tmp > 0)
			{
				aux = 3 * Math.Sqrt(tmp); // <-- 3 by square root
            }

		}

		public void Function_SPC()
		{

			this.lineGood.Pointer.Visible = true;
			this.lineBad.Pointer.Visible = true;
			Random r = new Random();
			for (int i = 1; i < 19; i++)
			{
				this.lineGood.Add(800 + r.Next(200)); // good
				this.lineBad.Add(4 + r.Next(4)); // bad
			}

			CalcLimits(lineGood, lineBad);

		}

        public void RemoveEvent()
        {

            BaseChart.Chart.AfterDraw -= Chart_AfterDraw;

        }

	}
}
