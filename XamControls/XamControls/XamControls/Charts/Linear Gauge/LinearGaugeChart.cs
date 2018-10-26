using Steema.TeeChart;
using Steema.TeeChart.Animations.EasingFunctions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Charts.Linear_Gauge
{
    public class LinearGaugeChart
    {

				private LinearGauge linearGauge;

				public LinearGaugeChart(ChartView BaseChart)
				{

						linearGauge = new LinearGauge();
						linearGauge.FillSampleValues();

						BaseChart.Chart.Series.Add(linearGauge);
						BaseChart.Chart.Header.Visible = false;
						BaseChart.Rotation = 0;

						linearGauge.Value = 20;
						linearGauge.Axis.Increment = 10;
						linearGauge.Maximum = 100;
						linearGauge.Minimum = 0;

						linearGauge.FaceBrush.Color = Color.White;
						linearGauge.FaceBrush.ForegroundColor = Color.White;
						linearGauge.RedLine.Visible = false;
						linearGauge.GreenLine.Visible = false;
						linearGauge.Hand.Visible = false;
						linearGauge.FaceBrush.Visible = true;
						linearGauge.FaceBrush.Gradient.Visible = false;
						linearGauge.Maximum = 100;
						linearGauge.Minimum = 0;
						linearGauge.Hand.Visible = false;
						linearGauge.Ticks.Visible = true;
						linearGauge.Ticks.VertSize = 60;
						linearGauge.Ticks.HorizSize = 0.5;
						linearGauge.MinorTicks.Visible = false;
						linearGauge.MinorTickDistance = 0;
						linearGauge.MaxValueIndicator.VertSize = 10;
						linearGauge.MaxValueIndicator.HorizSize = 10;
						linearGauge.MaxValueIndicator.Visible = true;


				}

    }
}
