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
    public class SmoothMovAvgProFunctionChart : SeriesModel
    {
#if !TEE_STD
        private Candle candle;
				private Line line;
				private Line lineSmooth;
				private MovingAverage movingAverageFunction;
				private SmoothedMovAvgFunction smoothMovAvgFunction;
				private Variables.Variables var;

				public SmoothMovAvgProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						line = new Line();
						lineSmooth = new Line();
						movingAverageFunction = new MovingAverage();
						smoothMovAvgFunction = new SmoothedMovAvgFunction();
						var = new Variables.Variables();

						Themes.CandleGodStyle(candle);

						BaseChart.Chart.Title.Text = "Smoothed Moving Average";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;

						FillSampleValues(candle, 20);
						candle.Title = "Candle";

						line.DataSource = candle;
						line.Color = var.GetPaletteBasic[2];
						line.LinePen.Width = 3;
						line.Function = movingAverageFunction;
						line.Title = "Moving Average";

						lineSmooth.DataSource = candle;
						lineSmooth.Function = smoothMovAvgFunction;
						lineSmooth.Color = var.GetPaletteBasic[3];
						lineSmooth.LinePen.Width = 3;
						lineSmooth.Title = "Smooth Moving Average";

						movingAverageFunction.Period = 3;
						smoothMovAvgFunction.Period = 3;

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(line);
						BaseChart.Chart.Series.Add(lineSmooth);

				}
#endif
    }
}
