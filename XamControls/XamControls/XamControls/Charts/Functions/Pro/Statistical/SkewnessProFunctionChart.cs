using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Statistical
{
    public class SkewnessProFunctionChart : SeriesModel
    {
        #if !TEE_STD
		private Area area;
		private Line line;
		private SkewnessFunction skeweness;
		private Variables.Variables var;

		public SkewnessProFunctionChart(ChartView BaseChart)
		{

			area = new Area();
			line = new Line();
			skeweness = new SkewnessFunction();
			var = new Variables.Variables();

			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Bottom.Automatic = true;
			BaseChart.Chart.Title.Text = "Skewness";
			BaseChart.Chart.Axes.Right.Automatic = true;

			BaseChart.Chart.Series.Add(area);
			BaseChart.Chart.Series.Add(line);

			FillSampleValues(area, 15, 200);
			area.Color = var.GetPaletteBasic[0];
			area.Title = "Area";
			//area.AreaLinesPen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);
			area.AreaLinesPen.Visible = false;
			area.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);
			area.LinePen.Width += 2;

            Themes.AplicarMarksTheme1(BaseChart);

			line.DataSource = area;
			line.Function = skeweness;
			line.LinePen.Width = 3;
			line.Color = var.GetPaletteBasic[1];
			line.Title = "Skewness";
			line.HorizAxis = HorizontalAxis.Bottom;
			line.VertAxis = VerticalAxis.Right;
			line.Marks.Visible = true;
			line.Marks.OnTop = true;
			line.Marks.FollowSeriesColor = true;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue + 20);

		}
#endif
    }
}
