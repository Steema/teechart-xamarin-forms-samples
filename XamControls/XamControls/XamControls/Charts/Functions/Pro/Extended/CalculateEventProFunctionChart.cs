using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class CalculateEventProFunctionChart
    {

		private Line line;
		private Steema.TeeChart.Functions.Custom customFunction;
		private Variables.Variables var;

		public CalculateEventProFunctionChart(ChartView BaseChart)
		{

			line = new Line();
			customFunction = new Steema.TeeChart.Functions.Custom();
			var = new Variables.Variables();

			BaseChart.Chart.Title.Text = "Custom Function";
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Legend.Visible = false;
			BaseChart.Chart.Axes.Left.Increment = 0.2;

			line.Function = customFunction;
			line.LinePen.Width = 3;
			line.Color = var.GetPaletteBasic[0];
            line.Marks.DrawEvery = 3;

			customFunction.Period = 1;
			customFunction.CalculateEvent += CustomFunction_CalculateEvent;

			BaseChart.Chart.Series.Add(line);

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 0.15, BaseChart.Chart.Axes.Left.MaxYValue + 0.15);
			BaseChart.Chart.Axes.Bottom.Automatic = true;


		}

		private void CustomFunction_CalculateEvent(object sender, CalculateEventArgs e)
		{

			e.Y = Math.Sin(e.X * 0.1);

		}
	}
}
