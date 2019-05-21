using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class DownSamplingProFunctionChart
    {
        #if !TEE_STD
		private Points points;
		private Line line;
		private DownSampling downSampling;
		private Variables.Variables var;

		public DownSamplingProFunctionChart(ChartView BaseChart)
		{

			points = new Points();
			line = new Line();
			downSampling = new DownSampling();
			var = new Variables.Variables();

			BaseChart.Chart.Title.Text = "Downsampling";
			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Bottom.Automatic = true;
			BaseChart.Chart.Axes.Left.Increment = 200;

			points.FillSampleValues(500);
			points.Title = "Data";
			points.Color = var.GetPaletteBasic[0];
			points.Pointer.VertSize -= 2;
			points.Pointer.HorizSize -= 2;
			points.Pointer.Style = PointerStyles.Triangle;
            points.Marks.Transparency = 100;

			line.DataSource = points;
			line.Function = downSampling;
			line.Title = "Reduced Data";
			line.LinePen.Width = 3;
			line.Color = var.GetPaletteBasic[1];
            line.Marks.DrawEvery = 3;

			downSampling.Tolerance = 10;
			downSampling.DisplayedPointCount = 0;
			downSampling.Period = 1;
			downSampling.Method = DownSamplingMethod.Average;

			BaseChart.Chart.Series.Add(points);
			BaseChart.Chart.Series.Add(line);


		}
#endif
    }
}
