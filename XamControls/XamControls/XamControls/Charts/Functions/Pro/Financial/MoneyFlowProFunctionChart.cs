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
    public class MoneyFlowProFunctionChart : SeriesModel
    {

				private Candle candle;
				private Volume volume;
				private Line line;
				private MoneyFlowFunction moneyFlowFunction;
				private Variables.Variables var;
				private Axis rightAxis;

				public MoneyFlowProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						volume = new Volume();
						line = new Line();
						moneyFlowFunction = new MoneyFlowFunction();
						var = new Variables.Variables();
						rightAxis = new Axis();

						BaseChart.Chart.Header.Text = "Money Flow Index";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(volume);
						BaseChart.Chart.Series.Add(line);

						Themes.CandleGodStyle(candle);
						Themes.CustomAxisRight(rightAxis);
						Themes.UpdateAxes(BaseChart.Chart.Axes.Left, BaseChart.Chart.Axes.Bottom);
						Themes.DoubleAxisChart(BaseChart);
						BaseChart.Chart.Axes.Custom.Add(rightAxis);

						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						rightAxis.Automatic = true;

						candle.FillSampleValues(15);
						candle.Title = "Candle";
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.VertAxis = VerticalAxis.Left;

						volume.HorizAxis = HorizontalAxis.Bottom;
						volume.VertAxis = VerticalAxis.Custom;
						volume.CustomVertAxis = rightAxis;
						volume.XValues.DataMember = "X";
						volume.XValues.Order = ValueListOrder.Ascending;
						volume.YValues.DataMember = "Y";
						volume.Title = "Volume";
						volume.FillSampleValues(20);
						volume.LinePen.Width = 3;

						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Custom;
						line.CustomVertAxis = rightAxis;
						line.DataSource = candle;
						line.Function = moneyFlowFunction;
						line.LinePen.Width = 3;
						line.Color = var.GetPaletteBasic[2];
						line.Title = "Line";

						moneyFlowFunction.Series = candle;
						moneyFlowFunction.Volume = volume;
						moneyFlowFunction.CMFStyle = CMFStyle.Histogram;
						moneyFlowFunction.Volume.Color = var.GetPaletteBasic[3];

						BaseChart.Chart.Axes.Custom.Add(rightAxis);

						rightAxis.Automatic = true;
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;

		}

    }
}
