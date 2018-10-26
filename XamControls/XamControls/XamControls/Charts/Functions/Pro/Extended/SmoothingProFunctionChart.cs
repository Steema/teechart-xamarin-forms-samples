using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class SmoothingProFunctionChart
    {

		private Line line1;
		private Line line2;
		private Smoothing smoothing;
		private Variables.Variables var;

		public SmoothingProFunctionChart(ChartView BaseChart)
		{

			line1 = new Line();
			line2 = new Line();
			smoothing = new Smoothing();
			var = new Variables.Variables();

			BaseChart.Chart.Title.Text = "Smoothing";
			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Bottom.Automatic = true;
			BaseChart.Chart.Axes.Left.Increment = 1;

			line1.FillSampleValues(6);
			line1.Title = "Line";
			line1.LinePen.Width = 3;
			line1.Color = var.GetPaletteBasic[0];
			line1.Pointer.Visible = true;
            line1.Marks.Transparency = 100;

			line2.DataSource = line1;
			line2.Function = smoothing;
			line2.LinePen.Width = 3;
			line2.Color = var.GetPaletteBasic[1];
			line2.Title = "Line Smoothed";
            line2.Marks.DrawEvery = 12;

			smoothing.Factor = 50;

			BaseChart.Chart.Series.Add(line1);
			BaseChart.Chart.Series.Add(line2);

		}

    }
}
