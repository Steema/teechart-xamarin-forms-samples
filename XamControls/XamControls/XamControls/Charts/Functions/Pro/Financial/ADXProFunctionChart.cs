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
    public class ADXProFunctionChart : SeriesModel
    {
#if !TEE_STD
        private ADXFunction adxFunction;
				private Candle candle;
				private Line line;
				private Axis myAxisLeft;
				private ChartView BaseChart;
				private Variables.Variables var;

				public ADXProFunctionChart(ChartView BaseChart)
				{

						this.adxFunction = new ADXFunction();
						this.candle = new Candle();
						this.line = new Line();
						this.myAxisLeft = new Axis();
						this.BaseChart = BaseChart;
						this.var = new Variables.Variables();

						Themes.CandleGodStyle(candle);

						BaseChart.Chart.Header.Text = "Average Directional Change (ADX)";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(line);
						BaseChart.Chart.Axes.Custom.Add(myAxisLeft);

						BaseChart.Chart.Axes.Left.RelativePosition = 0;
						BaseChart.Chart.Axes.Left.StartPosition = 0;
						BaseChart.Chart.Axes.Left.EndPosition = 55;
						//BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Left.Increment = 20;

						BaseChart.Chart.Axes.Bottom.RelativePosition = 0;
						BaseChart.Chart.Axes.Bottom.StartPosition = 0;
						BaseChart.Chart.Axes.Bottom.EndPosition = 100;
						//BaseChart.Chart.Axes.Bottom.Automatic = true;

						myAxisLeft = Themes.CustomAxisLeft(myAxisLeft);

						FillSampleValues(candle);
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.VertAxis = VerticalAxis.Left;
						candle.Title = "Data Source";

						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Custom;
						line.CustomVertAxis = myAxisLeft;
						line.Function = adxFunction;
						line.DataSource = candle;
						line.Title = "ADX";
						line.LinePen.Width = 3;
						line.Color = var.GetPaletteBasic[4];

						adxFunction.Period = 2;
						adxFunction.DMDown.Color = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(168)))));
						adxFunction.DMDown.ColorEach = false;
						adxFunction.DMDown.CustomVertAxis = myAxisLeft;
						adxFunction.DMDown.LinePen.Color = var.GetPaletteBasic[2];
						adxFunction.DMDown.LinePen.Width = 3;
						adxFunction.DMDown.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
						adxFunction.DMDown.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						adxFunction.DMDown.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
						adxFunction.DMDown.Marks.Callout.ArrowHead = ArrowHeadStyles.None;
						adxFunction.DMDown.Marks.Callout.ArrowHeadSize = 8;
						adxFunction.DMDown.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
						adxFunction.DMDown.Marks.Callout.Distance = 0;
						adxFunction.DMDown.Marks.Callout.Draw3D = false;
						adxFunction.DMDown.Marks.Callout.Length = 10;
						adxFunction.DMDown.Marks.Callout.Style = PointerStyles.Rectangle;
						adxFunction.DMDown.Marks.Callout.Visible = false;
						adxFunction.DMDown.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
						adxFunction.DMDown.Marks.Transparent = true;
						adxFunction.DMDown.Legend.Visible = false;
						adxFunction.DMDown.Title = "DMDown";
						adxFunction.DMDown.TreatNulls = TreatNullsStyle.Ignore;
						adxFunction.DMDown.VertAxis = VerticalAxis.Custom;
						adxFunction.DMDown.CustomVertAxis = myAxisLeft;
						adxFunction.DMDown.XValues.DataMember = "X";
						adxFunction.DMDown.XValues.DateTime = true;
						adxFunction.DMDown.XValues.Order = ValueListOrder.Ascending;
						adxFunction.DMDown.YValues.DataMember = "Y";

						adxFunction.DMUp.Color = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(20)))));
						adxFunction.DMUp.ColorEach = false;
						adxFunction.DMUp.LinePen.Color = var.GetPaletteBasic[3];
						adxFunction.DMUp.LinePen.Width = 3;
						adxFunction.DMUp.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
						adxFunction.DMUp.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
						adxFunction.DMUp.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
						adxFunction.DMUp.Marks.Callout.ArrowHead = ArrowHeadStyles.None;
						adxFunction.DMUp.Marks.Callout.ArrowHeadSize = 8;
						adxFunction.DMUp.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
						adxFunction.DMUp.Marks.Callout.Distance = 0;
						adxFunction.DMUp.Marks.Callout.Draw3D = false;
						adxFunction.DMUp.Marks.Callout.Length = 10;
						adxFunction.DMUp.Marks.Callout.Style = PointerStyles.Rectangle;
						adxFunction.DMUp.Marks.Callout.Visible = false;
						adxFunction.DMUp.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
						adxFunction.DMUp.Marks.Transparent = true;
						adxFunction.DMUp.Legend.Visible = false;
						adxFunction.DMUp.Title = "DMUp";
						adxFunction.DMUp.TreatNulls = TreatNullsStyle.Ignore;
						adxFunction.DMUp.VertAxis = VerticalAxis.Custom;
						adxFunction.DMUp.CustomVertAxis = myAxisLeft;
						adxFunction.DMUp.XValues.DataMember = "X";
						adxFunction.DMUp.XValues.DateTime = true;
						adxFunction.DMUp.XValues.Order = ValueListOrder.Ascending;
						adxFunction.DMUp.YValues.DataMember = "Y";

						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 10, BaseChart.Chart.Axes.Left.MaxYValue + 10);
						BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue - 1, BaseChart.Chart.Axes.Bottom.MaxXValue + 1);

				}

				public override void FillSampleValues(Series serie)
				{

						base.FillSampleValues(serie);

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

							if (!trobat && (candle.mandatory[(candle.mandatory.Count - 1)] - candle.mandatory[0]) > 50) { correcte = true; }

						}
				}

#endif

    }
}
