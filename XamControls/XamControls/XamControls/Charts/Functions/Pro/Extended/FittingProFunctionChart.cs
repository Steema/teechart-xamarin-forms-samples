using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class FittingProFunctionChart : SeriesModel
    {

		private Points points;
		private Line line;
#if !TEE_STD
        private PolyFitting fittingFunction;
#endif
		private Variables.Variables var;

		public FittingProFunctionChart(ChartView BaseChart)
		{
#if !TEE_STD
            points = new Points();
			line = new Line();
			fittingFunction = new PolyFitting();
			var = new Variables.Variables();

			BaseChart.Chart.Title.Text = "Fitting Linearizable Model";
			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Bottom.Automatic = true;
			BaseChart.Chart.Axes.Left.Increment = 30;

			FillSampleValues(points, 10, 500, 0);
			points.Color = var.GetPaletteBasic[0];
			points.Pointer.HorizSize += 3;
			points.Pointer.VertSize += 3;
			points.Pointer.Style = PointerStyles.Rectangle;
			points.Pointer.Pen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.25);
			points.Title = "Data Source";

			line.DataSource = points;
			line.Function = fittingFunction;
			line.Color = var.GetPaletteBasic[1];
			line.LinePen.Width = 3;
			line.Title = "Fitted";

			BaseChart.Chart.Series.Add(points);
			BaseChart.Chart.Series.Add(line);
#endif
        }

    }
}
