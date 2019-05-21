using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{

    public class KurtosisProFunctionChart : SeriesModel
    {
#if !TEE_STD
        private Area area;
		private Line line;
		private KurtosisFunction kurtosis;
		private Variables.Variables var;

		public KurtosisProFunctionChart(ChartView BaseChart)
		{

			area = new Area();
			line = new Line();
			kurtosis = new KurtosisFunction();
			var = new Variables.Variables();

			BaseChart.Chart.Title.Text = "Kurtosis";

			FillSampleValues(area, 15, 250);

			line.Color = var.GetPaletteBasic[1];

			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Bottom.Automatic = true;
			BaseChart.Chart.Axes.Left.Increment = 50;

			BaseChart.Chart.Series.Add(area);
			BaseChart.Chart.Series.Add(line);

			kurtosis.Chart = BaseChart.Chart;

			area.FillSampleValues();
			area.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);
			area.AreaLines.Visible = false;
			area.SeriesColor = var.GetPaletteBasic[0];
			area.Smoothed = true;
			area.Title = "Data Source";
            area.Marks.DrawEvery = 7;

			line.Function = kurtosis;
			line.DataSource = area;
			line.LinePen.Width = 5;
			line.VertAxis = VerticalAxis.Right;
			line.Title = "Kurtosis";

		}
#endif
    }
}
