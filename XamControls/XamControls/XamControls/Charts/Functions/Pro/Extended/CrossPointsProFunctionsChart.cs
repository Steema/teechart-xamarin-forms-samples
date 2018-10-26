using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class CrossPointsProFunctionsChart
    {

		private Line line1;
		private Line line2;
		private Steema.TeeChart.Functions.CrossPoints crossPoints;
		private Line crossLine;
		private Variables.Variables var;

		public CrossPointsProFunctionsChart(ChartView BaseChart)
		{

				line1 = new Line();
				line2 = new Line();
				crossPoints = new Steema.TeeChart.Functions.CrossPoints();
				crossLine = new Line();
				var = new Variables.Variables();

				BaseChart.Chart.Title.Text = "Cross Point";
				BaseChart.Chart.Axes.Left.Increment = 0.2;

				for (double x = -5; x < 5; x += 0.2)
				{
						line1.Add(x, Math.Sin(Math.PI / 2 * x));
						line2.Add(x, Math.Sin(Math.PI / 6 * x) - 0.25);
				}

				line1.Title = "Wave 1";
				line1.Color = var.GetPaletteBasic[0];
				line1.LinePen.Width = 3;

				line2.Title = "Wave 2";
				line2.Color = var.GetPaletteBasic[1];
				line2.LinePen.Width = 3;

				crossLine.Title = "CrossPoints";
				crossLine.Color = var.GetPaletteBasic[2];
				crossLine.LinePen.Width = 3;
				crossLine.ColorEach = false;
				crossLine.DataSource = new object[] { line1, line2 };
				crossLine.Function = crossPoints;
				crossLine.Pointer.Visible = true;

				BaseChart.Chart.Axes.Left.Automatic = true;
				BaseChart.Chart.Axes.Bottom.Automatic = true;
				BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
				BaseChart.Chart.Axes.Left.Increment = 0.2;

				BaseChart.Chart.Series.Add(line1);
				BaseChart.Chart.Series.Add(line2);
				BaseChart.Chart.Series.Add(crossLine);

		}

    }
}
