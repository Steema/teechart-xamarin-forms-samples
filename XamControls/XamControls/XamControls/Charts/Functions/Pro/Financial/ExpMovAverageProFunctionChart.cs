using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class ExpMovAverageProFunctionChart : SeriesModel
    {

				private Candle candle;
				private Line line;
				private ExpMovAverage expMovAverage;
				private Variables.Variables var;

				public ExpMovAverageProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						line = new Line();
						expMovAverage = new ExpMovAverage();
						var = new Variables.Variables();

						Themes.CandleGodStyle(candle);

						BaseChart.Chart.Title.Text = "Exponential Moving Average";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(line);

						FillSampleValues(candle, 15);
						candle.Title = "Data Source";
						candle.YValues.DataMember = "Close";

						line.Color = var.GetPaletteBasic[2];
						line.DataSource = candle;
						line.Function = expMovAverage;
						line.Pointer.Visible = true;
						line.Pointer.Color = var.GetPaletteBasic[2];
						line.Title = "Exp. Mov. Average";
						line.LinePen.Width = 3;

						expMovAverage.Period = 14;
	
						BaseChart.Chart.Axes.Left.Increment = 20;
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;

				}

		}
}
