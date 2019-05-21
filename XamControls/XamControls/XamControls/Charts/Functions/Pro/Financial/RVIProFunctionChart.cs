using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class RVIProFunctionChart : SeriesModel
    {
#if !TEE_STD
        private Candle candle;
				private Line line;
				private RVIFunction rviFunction;
				private Variables.Variables var;
				private Axis leftAxis;

				public RVIProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						line = new Line();
						rviFunction = new RVIFunction();
						var = new Variables.Variables();
						leftAxis = new Axis();

						Themes.CandleGodStyle(candle);
						Themes.DoubleAxisChart(BaseChart);
						Themes.CustomAxisLeft(leftAxis);

						BaseChart.Chart.Title.Text = "Relative Vigor Index";
						BaseChart.Chart.Axes.Custom.Add(leftAxis);
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						leftAxis.Increment = 0.1;
						leftAxis.Automatic = true;

						FillSampleValues(candle, 20);
						candle.Title = "DataSouce";
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.VertAxis = VerticalAxis.Left;

						line.Title = "RVI";
						line.DataSource = candle;
						line.Function = rviFunction;
						line.Color = var.GetPaletteBasic[2];
						line.LinePen.Width = 3;
						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Custom;
						line.CustomVertAxis = leftAxis;

						rviFunction.Period = 10;
						rviFunction.Signal.Visible = true;
						rviFunction.Signal.LinePen.Width = 3;
						rviFunction.Signal.Color = var.GetPaletteBasic[3];

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(line);

				}
#endif
    }
}
