using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using Xamarin.Forms;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Animations.EasingFunctions;

namespace XamControls.Charts.Linear_Gauge
{
    public class MoreLinesLinearChart
    {

				private LinearGauge linearGauge;

				public MoreLinesLinearChart(ChartView BaseChart)
				{

						linearGauge = new LinearGauge();

						BaseChart.Chart.Series.Add(linearGauge);
						BaseChart.Chart.Header.Visible = false;

						linearGauge.Value = 6;
						linearGauge.Maximum = 10;
						linearGauge.Minimum = 0;

						linearGauge.Axis.AxisPen.Color = Color.Green;
						linearGauge.Axis.MinorGrid.Visible = false;
						linearGauge.Axis.Labels.Font.Size = 12;
						linearGauge.Axis.Labels.Color = Color.Blue;
						linearGauge.Axis.Ticks.Visible = true;
						linearGauge.Axis.Increment = 1;
						//BaseChart.Rotation = 180;

						BaseChart.Chart.Axes.Bottom.Labels.Font.Size = 12;
						BaseChart.Chart.Axes.Bottom.Labels.Font.Color = Color.Green;
						BaseChart.Chart.Axes.Bottom.MinorTicks.Visible = false;
						BaseChart.Chart.Axes.Bottom.MinorTicks.Length = 20;
						BaseChart.Chart.Axes.Bottom.MinorTicks.Width = 1;
						BaseChart.Chart.Axes.Bottom.MinorTicks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Ticks.Visible = false;
						BaseChart.Rotation = 0;

						linearGauge.Hand.Gradient.Visible = true;
						linearGauge.Hand.Gradient.StartColor = Color.FromRgb(0, 209, 106);
						linearGauge.Hand.Gradient.MiddleColor = Color.FromRgb(0, 187, 84);
						linearGauge.Hand.Gradient.EndColor = Color.FromRgb(20, 144, 65);
						linearGauge.Hand.Gradient.Direction = GradientDirection.BottomTop;
						linearGauge.Hand.Transparency = 20;
			
						linearGauge.GreenLine.Visible = true;
						linearGauge.GreenLine.VertSize = 30;
						linearGauge.GreenLine.Gradient.StartColor = Color.FromRgb(30, 119, 226);
						linearGauge.GreenLine.Gradient.MiddleColor = Color.FromRgb(10, 80, 160);
						linearGauge.GreenLine.Gradient.EndColor = Color.FromRgb(0, 40, 115);
						linearGauge.GreenLineEndValue = 5;
						linearGauge.GreenLineStartValue = 0;

						linearGauge.RedLine.Visible = true;
						linearGauge.RedLine.VertSize = 30;
						linearGauge.RedLine.Gradient.StartColor = Color.FromRgb(110, 6, 9);
						linearGauge.RedLine.Gradient.MiddleColor = Color.FromRgb(160, 10, 10);
						linearGauge.RedLine.Gradient.EndColor = Color.FromRgb(200, 19, 16);
						linearGauge.RedLineStartValue = 7;
						linearGauge.RedLineEndValue = 10;

						linearGauge.MinorTicks.Visible = false;

						linearGauge.Ticks.Visible = false;
						linearGauge.Ticks.VertSize = 70;
						linearGauge.Ticks.HorizSize = 0.5;
						linearGauge.Ticks.Color = Color.White;
						linearGauge.Ticks.Pen.Color = Color.White;

						linearGauge.MaxValueIndicator.Visible = true;
						linearGauge.MaxValueIndicator.VertSize = 15;
						linearGauge.MaxValueIndicator.HorizSize = 15;
						linearGauge.MaxValueIndicator.Color = Color.FromRgb(20, 93, 20);
						linearGauge.MaxValueIndicator.Style = PointerStyles.Triangle;

						linearGauge.FaceBrush.Gradient.Visible = false;
						linearGauge.FaceBrush.Color = Color.White;

						linearGauge.ValueAreaBrush.Visible = true;
						linearGauge.ValueAreaBrush.Color = Color.FromRgb(180, 255, 230);

						linearGauge.IsoVertAxes = false;
						linearGauge.IsoHorizAxes = false;


				}

	}
}
