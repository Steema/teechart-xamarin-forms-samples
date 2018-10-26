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
    public class RSIProFunctionChart : SeriesModel
    {

				private Candle candle;
				private Line line;
				private RSIFunction rsiFunction;
				private Variables.Variables var;
				private Axis rightAxis;

				public RSIProFunctionChart(ChartView BaseChart)
				{

					candle = new Candle();
					line = new Line();
					rsiFunction = new RSIFunction();
					var = new Variables.Variables();
					rightAxis = new Axis();

					Themes.CandleGodStyle(candle);
					Themes.DoubleAxisChart(BaseChart);
					Themes.CustomAxisRight(rightAxis);

					BaseChart.Chart.Title.Text = "Relative Strength Index";
					BaseChart.Chart.Axes.Left.Automatic = true;
					BaseChart.Chart.Axes.Bottom.Automatic = true;
					BaseChart.Chart.Axes.Custom.Add(rightAxis);
					BaseChart.Chart.Panel.MarginRight = 10;
					rightAxis.Automatic = true;
				
					FillSampleValues(candle, 20, 250);
					candle.Title = "Candle";
					candle.HorizAxis = HorizontalAxis.Bottom;
					candle.VertAxis = VerticalAxis.Left;

					line.DataSource = candle;
					line.Function = rsiFunction;
					line.Color = var.GetPaletteBasic[2];
					line.LinePen.Width = 3;
					line.HorizAxis = HorizontalAxis.Bottom;
					line.VertAxis = VerticalAxis.Custom;
					line.CustomVertAxis = rightAxis;
					line.Title = "R.S.I.";

					rsiFunction.Period = 5;
					rsiFunction.Style = RSIStyle.Close;

					BaseChart.Chart.Series.Add(candle);
					BaseChart.Chart.Series.Add(line);

				}


    }
}
