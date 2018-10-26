using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class MACDProFunctionChart : SeriesModel
    {

				private Candle candle;
				private Line line;
				private MACDFunction macd;
				private Axis leftAxis;
				private Variables.Variables var;

				public MACDProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						line = new Line();
						macd = new MACDFunction();
						leftAxis = new Axis();
						var = new Variables.Variables();

						Themes.DoubleAxisChart(BaseChart);
						Themes.CustomAxisLeft(leftAxis);

						BaseChart.Chart.Title.Text = "Moving Average Convergence Divergence";
						BaseChart.Chart.Axes.Custom.Add(leftAxis);
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.Increment = 20;
						leftAxis.Automatic = true;
						leftAxis.Increment = 3;

						FillSampleValues(candle, 15, 250);
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.VertAxis = VerticalAxis.Left;
						candle.Color = var.GetPaletteBasic[0];
						candle.Style = CandleStyles.CandleBar;
						candle.UpCloseColor = var.GetPaletteBasic[0];
						candle.DownCloseColor = var.GetPaletteBasic[1];
						candle.CandleWidth = 15;
						candle.Pen.Width = 3;
						candle.Title = "Data Source";

						line.DataSource = candle;
						line.Function = macd;
						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Custom;
						line.CustomVertAxis = leftAxis;
						line.Title = "Data Source";

						macd.MACDPen.Color = var.GetPaletteBasic[2];
						macd.MACDPen.Width = 3;
						macd.MACDExp.Color = var.GetPaletteBasic[3];
						macd.MACDExpPen.Width = 3;
						macd.Histogram.Color = var.GetPaletteBasic[4];
						macd.Histogram.LinePen.Width = 3;

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(line);

				}

    }
}
