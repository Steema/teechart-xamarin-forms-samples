using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class CLVProFunctionChart
    {

				private Candle candle;
				private Volume volume;
				private Line line;
				private CLVFunction clvFunction;
				private Variables.Variables var;
				private Axis leftBottomAxis;
				private Axis leftCenterAxis;

				public CLVProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						volume = new Volume();
						line = new Line();
						clvFunction = new CLVFunction();
						var = new Variables.Variables();
						leftBottomAxis = new Axis();
						leftCenterAxis = new Axis();

						Themes.CandleGodStyle(candle);

						BaseChart.Chart.Header.Text = "Accumulation / Distribution Line";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(volume);
						BaseChart.Chart.Series.Add(line);

						Themes.CustomAxisLeft(leftCenterAxis);
						Themes.CustomAxisLeft(leftBottomAxis);
						Themes.UpdateAxes(BaseChart.Chart.Axes.Left, BaseChart.Chart.Axes.Bottom);
						Themes.TripleAxisChart(BaseChart, leftCenterAxis, leftBottomAxis);
						
						candle.FillSampleValues(20);
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.VertAxis = VerticalAxis.Left;
						candle.Title = "Candle";

						volume.HorizAxis = HorizontalAxis.Bottom;
						volume.VertAxis = VerticalAxis.Custom;
						volume.CustomVertAxis = leftCenterAxis;
						volume.XValues.DataMember = "X";
						volume.XValues.Order = ValueListOrder.Ascending;
						volume.YValues.DataMember = "Y";
						volume.Title = "Volume";
						volume.FillSampleValues(20);
						volume.LinePen.Width = 3;
						volume.Color = var.GetPaletteBasic[3];

						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Custom;
						line.CustomVertAxis = leftBottomAxis;
						line.DataSource = candle;
						line.Function = clvFunction;
						line.Title = "CLV Function";
						line.LinePen.Width = 3;
						line.Color = var.GetPaletteBasic[2];

						clvFunction.Accumulate = true;
						clvFunction.Period = 1;
						clvFunction.Series = candle;
						clvFunction.Volume = volume;

						BaseChart.Chart.Axes.Custom.Add(leftCenterAxis);
						BaseChart.Chart.Axes.Custom.Add(leftBottomAxis);

						leftBottomAxis.Automatic = true;
						leftCenterAxis.Automatic = true;
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
				

				}

    }
}
