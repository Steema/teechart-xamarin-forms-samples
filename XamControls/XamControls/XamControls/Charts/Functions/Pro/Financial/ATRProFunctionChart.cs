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
    public class ATRProFunctionChart
    {
#if !TEE_STD
        private Candle candle;
				private Line line;
				private ATRFunction atrFunction;
				private Variables.Variables var;
				private ChartView BaseChart;
				private Axis leftAxis;

				public ATRProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						line = new Line();
						atrFunction = new ATRFunction();
						var = new Variables.Variables();
						this.BaseChart = BaseChart;
						leftAxis = new Axis();

						BaseChart.Chart.Axes.Custom.Add(leftAxis);

						Themes.CandleGodStyle(candle);
						Themes.CustomAxisLeft(leftAxis);
						Themes.DoubleAxisChart(BaseChart);
						leftAxis.Automatic = true;

						BaseChart.Chart.Header.Text = "Average True Range Indicator (ATR)";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(line);

						candle.FillSampleValues(40);

						candle.VertAxis = VerticalAxis.Left;
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.Title = "Data Source";

						line.DataSource = candle;
						line.Function = atrFunction;
						line.VertAxis = VerticalAxis.Custom;
						line.CustomVertAxis = leftAxis;
						line.HorizAxis = HorizontalAxis.Bottom;
						line.Title = "ATR";
						line.LinePen.Width = 3;
						line.Color = var.GetPaletteBasic[2];

						atrFunction.Period = 10;
						atrFunction.Series = candle;

						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;

				}
#endif
    }
}
