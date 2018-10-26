using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class AlligatorProFunctionChart : SeriesModel
    {

				private AlligatorFunction allFunction;
				private Candle candle;
				private Line line;
				private ChartView BaseChart;
				private Variables.Variables var;

				public AlligatorProFunctionChart(ChartView BaseChart)
				{

						allFunction = new AlligatorFunction();
						candle = new Candle();
						line = new Line();
						this.BaseChart = BaseChart;
						var = new Variables.Variables();

						Themes.CandleGodStyle(candle);
                        Themes.UpdateAxes(BaseChart.Chart.Axes.Left, BaseChart.Chart.Axes.Bottom);

						BaseChart.Chart.Header.Text = "Alligator Technical Indicator";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(line);

						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.Increment = 10;

						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.VertAxis = VerticalAxis.Left;
						candle.Title = "Data Source";
						FillSampleValues(candle, 15);

						allFunction.LipsPen.Color = var.GetPaletteBasic[3];
						allFunction.LipsPen.Width = 3;
						allFunction.TeethPen.Color = var.GetPaletteBasic[4];
						allFunction.TeethPen.Width = 3;

						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Left;
						line.Title = "Alligator";
						line.Function = allFunction;
						line.DataSource = candle;
						line.LinePen.Color = var.GetPaletteBasic[0];
						line.SeriesColor = var.GetPaletteBasic[0];
						line.LinePen.Width = 3;

				}

		}
}
