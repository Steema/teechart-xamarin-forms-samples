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
    public class BollingerProFunctionChart
    {

				private Candle candle;
				private Line line;
				private Bollinger bollingerFunction;
				private Variables.Variables var;

				public BollingerProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						line = new Line();
						bollingerFunction = new Bollinger();
						var = new Variables.Variables();

						Themes.CandleGodStyle(candle);

						BaseChart.Chart.Header.Text = "Bollinger Bands";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(line);

						candle.FillSampleValues(20);
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.VertAxis = VerticalAxis.Left;
						candle.Title = "Data Source";

						line.DataSource = candle;
						line.Function = bollingerFunction;
						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Left;
						line.Title = "Bollinger";
						line.LinePen.Width = 3;
						line.Color = var.GetPaletteBasic[2];

						bollingerFunction.Deviation = 2;
						bollingerFunction.Exponential = false;
						bollingerFunction.LowBandPen.Color = var.GetPaletteBasic[3];
						bollingerFunction.UpperBandPen.Color = var.GetPaletteBasic[2];
						bollingerFunction.UpperBandPen.Visible = true;
						bollingerFunction.LowBand.Visible = true;
						bollingerFunction.LowBandPen.Width = 3;
						bollingerFunction.UpperBandPen.Width = 3;
						bollingerFunction.Series = candle;

						bollingerFunction.LowBand.XValues.DataMember = "X";
						bollingerFunction.LowBand.XValues.DateTime = true;
						bollingerFunction.LowBand.XValues.Order = ValueListOrder.Ascending;
						bollingerFunction.LowBand.YValues.DataMember = "Y";
						bollingerFunction.Period = 10;


						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue - 1, BaseChart.Chart.Axes.Bottom.MaxXValue + 1);
						BaseChart.Chart.Axes.Left.Increment = 10;


				}

    }
}
