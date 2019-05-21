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

    public class AOProFunctionChart
    {
        #if !TEE_STD
				private Candle candle;
				private Volume volume;
				private AOFunction aoFunction;
				private Variables.Variables var;
				private ChartView BaseChart;
				private Axis leftAxis;

				public AOProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						volume = new Volume();
						aoFunction = new AOFunction();
						var = new Variables.Variables();
						this.BaseChart = BaseChart;
						leftAxis = new Axis();

						Themes.CandleGodStyle(candle);
						Themes.CustomAxisLeft(leftAxis);
						leftAxis.AxisPen.Transparency = 100;
						leftAxis.Labels.Transparency = 100;
						leftAxis.Grid.Visible = false;

						BaseChart.Chart.Header.Text = "Awesome Oscillator (AO)";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(volume);

						FillSampleValues(candle);

						candle.VertAxis = VerticalAxis.Left;
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.Title = "Data Source";

						volume.UseOrigin = true;
						volume.DataSource = candle;
						volume.Function = aoFunction;
						volume.HorizAxis = HorizontalAxis.Bottom;
						volume.VertAxis = VerticalAxis.Custom;
						volume.CustomVertAxis = leftAxis;
						volume.Title = "AO";
						volume.LinePen.Width = 3;

						aoFunction.Period = 12;
						aoFunction.Series = candle;

						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;

						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 100, BaseChart.Chart.Axes.Left.MaxYValue + 10);
						BaseChart.Chart.Axes.Left.Increment = 20;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Custom.Add(leftAxis);

				}

				private void FillSampleValues(Candle candle)
				{

						bool correcte = false;

						while (!correcte)
						{

								candle.FillSampleValues(20);
								int i = 0;
								bool trobat = false;

								while (i < candle.mandatory.Count && !trobat)
								{

									if (candle.mandatory[i] > 200) { trobat = true; }
									i++;

								}

								if (!trobat) { correcte = true; }

						}

				}
#endif

		}
}
