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
    public class OBVProFunctionChart : SeriesModel
    {

				private Candle candle;
				private Volume volume;
				private Line line;
				private OBVFunction obvFunction;
				private Variables.Variables var;
				private Axis midLeftAxis;
				private Axis botLeftAxis;

				public OBVProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						volume = new Volume();
						line = new Line();
						obvFunction = new OBVFunction();
						var = new Variables.Variables();
						midLeftAxis = new Axis();
						botLeftAxis = new Axis();

						Themes.CandleGodStyle(candle);
						Themes.CustomAxisLeft(midLeftAxis);
						Themes.CustomAxisLeft(botLeftAxis);
						Themes.UpdateAxes(BaseChart.Chart.Axes.Left, BaseChart.Chart.Axes.Right);
						Themes.TripleAxisChart(BaseChart, midLeftAxis, botLeftAxis);
						BaseChart.Chart.Axes.Custom.Add(midLeftAxis);
						BaseChart.Chart.Axes.Custom.Add(botLeftAxis);

						BaseChart.Chart.Title.Text = "On Balance Volume";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(volume);
						BaseChart.Chart.Series.Add(line);

						candle.FillSampleValues(20);
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.VertAxis = VerticalAxis.Left;
						candle.Title = "Candle";

						volume.HorizAxis = HorizontalAxis.Bottom;
						volume.VertAxis = VerticalAxis.Custom;
						volume.CustomVertAxis = midLeftAxis;
						volume.XValues.DataMember = "X";
						volume.XValues.Order = ValueListOrder.Ascending;
						volume.YValues.DataMember = "Y";
						volume.Title = "Volume";
						volume.FillSampleValues(20);
						volume.LinePen.Width = 3;
						volume.Color = var.GetPaletteBasic[3];

						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Custom;
						line.CustomVertAxis = botLeftAxis;
						line.DataSource = candle;
						line.Function = obvFunction;
						line.Title = "CLV Function";
						line.LinePen.Width = 3;
						line.Color = var.GetPaletteBasic[2];

						obvFunction.Period = 1;
						obvFunction.Series = candle;
						obvFunction.Volume = volume;

						BaseChart.Chart.Axes.Custom.Add(midLeftAxis);
						BaseChart.Chart.Axes.Custom.Add(botLeftAxis);

						
						midLeftAxis.Automatic = true;
						botLeftAxis.Automatic = true;
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;


				}

    }
}
