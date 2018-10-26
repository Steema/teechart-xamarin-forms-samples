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
    public class ScalesLinearChart
    {

				private LinearGauge linearGauge;

				public ScalesLinearChart(ChartView BaseChart)
				{

						linearGauge = new LinearGauge();

						BaseChart.Chart.Series.Add(linearGauge);
						BaseChart.Chart.Header.Visible = false;
						BaseChart.Rotation = 0;

						linearGauge.Value = 70;
						linearGauge.Axis.Increment = 10;
						linearGauge.Maximum = 100;
						linearGauge.Minimum = 0;

						linearGauge.Hand.Gradient.Visible = true;
						linearGauge.Hand.Gradient.StartColor = Color.FromRgb(0, 129, 206);
						linearGauge.Hand.Gradient.EndColor = Color.FromRgb(40, 174, 225);
						linearGauge.Hand.Gradient.MiddleColor = Color.FromRgb(0, 153, 244);
						linearGauge.Hand.Gradient.Direction = GradientDirection.BottomTop;
						linearGauge.GreenLine.Visible = false;
						linearGauge.RedLine.Visible = false;
						linearGauge.MinorTicks.Visible = false;
						linearGauge.Ticks.Visible = true;
						linearGauge.Ticks.VertSize = 70;
						linearGauge.Ticks.HorizSize = 0.5;
						linearGauge.Ticks.Color = Color.White;
						linearGauge.Ticks.Pen.Color = Color.White;
						linearGauge.MaxValueIndicator.Visible = true;
						linearGauge.MaxValueIndicator.VertSize = 12;
						linearGauge.MaxValueIndicator.HorizSize = 12;
						linearGauge.MaxValueIndicator.Color = Color.FromRgb(0, 93, 160);
						linearGauge.FaceBrush.Gradient.Visible = false;
						linearGauge.FaceBrush.Color = Color.White;
						linearGauge.ValueAreaBrush.Visible = true;
						linearGauge.ValueAreaBrush.Color = Color.FromRgb(170, 210, 240);
						linearGauge.IsoVertAxes = false;
						linearGauge.IsoHorizAxes = false;

				}

    }
}
