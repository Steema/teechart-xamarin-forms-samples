	using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class ACProFunctionChart : SeriesModel
    {

				private ACFunction acFunction;
				private Candle candle;
				private Volume volume;
				private Axis myAxisLeft;
				private ChartView BaseChart;
				private Variables.Variables var;

				public ACProFunctionChart(ChartView BaseChart)
				{

					this.acFunction = new ACFunction();
					this.candle = new Candle();
					this.volume = new Volume();
					this.myAxisLeft = new Axis();
					this.BaseChart = BaseChart;
					this.var = new Variables.Variables();

					Themes.CandleGodStyle(candle);

					BaseChart.Chart.Header.Text = "Acceleration/Deceleration Indicator (AC)";

					BaseChart.Chart.Series.Add(candle);
					BaseChart.Chart.Series.Add(volume);
					BaseChart.Chart.Axes.Custom.Add(myAxisLeft);

					BaseChart.Chart.Axes.Left.RelativePosition = 0;
					BaseChart.Chart.Axes.Left.StartPosition = 0;
					BaseChart.Chart.Axes.Left.EndPosition = 55;
					BaseChart.Chart.Axes.Left.Automatic = true;
					BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
					BaseChart.Chart.Axes.Left.Increment = 15;

					BaseChart.Chart.Axes.Bottom.RelativePosition = 0;
					BaseChart.Chart.Axes.Bottom.StartPosition = 0;
					BaseChart.Chart.Axes.Bottom.EndPosition = 100;
					BaseChart.Chart.Axes.Bottom.Automatic = true;

					myAxisLeft = Themes.CustomAxisLeft(myAxisLeft);

					FillSampleValues(candle, 20, 200);
					candle.HorizAxis = HorizontalAxis.Bottom;
					candle.VertAxis = VerticalAxis.Left;
					candle.Title = "Data Source";

					volume.HorizAxis = HorizontalAxis.Bottom;
					volume.VertAxis = VerticalAxis.Custom;
					volume.CustomVertAxis = myAxisLeft;
					volume.Function = acFunction;
					volume.DataSource = candle;
					volume.Title = "AC";
					volume.LinePen.Width = 3;

					acFunction.Period = 2;
					acFunction.Series = candle;

				}

	}
}
