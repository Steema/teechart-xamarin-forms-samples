using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class TrendlineProFunctionChart
    {

				private Area area;
				private Line line;
				private TrendFunction trendFunction;
				private Variables.Variables var;

				public TrendlineProFunctionChart(ChartView BaseChart)
				{

						area = new Area();
						line = new Line();
						trendFunction = new TrendFunction();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Trendline";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.Increment = 40;

						BaseChart.Chart.Series.Add(area);

						area.FillSampleValues(15);
						area.Color = var.GetPaletteBasic[0];
						area.AreaLines.Color = var.GetPaletteBasic[0];
						area.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);
						area.Title = "Data Source";

						BaseChart.Chart.Series.Add(line);
			
						line.DataSource = area;
						line.Function = trendFunction;
						line.Title = "Trendline";
						line.LinePen.Width = 3;
						line.Color = var.GetPaletteBasic[1];

						trendFunction.TrendStyle = TrendStyles.Normal;

				}
    }
}
