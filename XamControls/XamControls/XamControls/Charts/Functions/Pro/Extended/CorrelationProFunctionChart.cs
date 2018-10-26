using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
	public class CorrelationProFunctionChart : SeriesModel
	{

			private Points points;
			private Line correlation;
			private Line trend;
			private CorrelationFunction correlationFunction;
			private TrendFunction trendFunction;
			private Variables.Variables var;
			
			public CorrelationProFunctionChart(ChartView BaseChart)
			{

					points = new Points();
					correlation = new Line();
					trend = new Line();
					correlationFunction = new CorrelationFunction();
					trendFunction = new TrendFunction();
					var = new Variables.Variables();

					BaseChart.Chart.Title.Text = "Correlation";
					BaseChart.Chart.Axes.Left.Increment = 50;

					FillSampleValues(points, 20);
					points.Color = var.GetPaletteBasic[0];
					points.Title = "Data Source";
					points.Pointer.Style = PointerStyles.Diamond;
					points.Pointer.HorizSize += 3;
					points.Pointer.VertSize += 3;
					points.Pointer.Pen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.25);

					correlation.LinePen.Width = 3;
					correlation.Color = var.GetPaletteBasic[1];
					//correlation.LinePen.Style = DashStyle.Dot;
					correlation.Function = correlationFunction;
					correlation.DataSource = points;
					correlation.Title = "Correlation";

					correlationFunction.TrendStyle = TrendStyles.Logarithmic;

					trend.Title = "Trend";
					trend.Function = trendFunction;
					trend.DataSource = points;
					trend.LinePen.Width = 3;
					trend.Color = var.GetPaletteBasic[2];

					trendFunction.TrendStyle = TrendStyles.Normal;
					trendFunction.Period = 10;

					BaseChart.Chart.Axes.Left.Automatic = true;
					BaseChart.Chart.Axes.Bottom.Automatic = true;
					BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;

					BaseChart.Chart.Series.Add(points);
					BaseChart.Chart.Series.Add(correlation);
					BaseChart.Chart.Series.Add(trend);

			}

    }
}
