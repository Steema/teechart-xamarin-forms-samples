using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;

namespace XamControls.Charts.Knob_Gauge
{
    public class BasicKnobGaugeChart
    {

				private KnobGauge knobGauge;
				private ChartView BaseChart;

				public BasicKnobGaugeChart(ChartView BaseChart)
				{

						knobGauge = new KnobGauge();
						this.BaseChart = BaseChart;

						knobGauge.FillSampleValues(4);

						BaseChart.Chart.Series.Add(knobGauge);

						knobGauge.MinorTicks.Visible = false;
						knobGauge.Ticks.Visible = false;

						BaseChart.Chart.Header.Visible = false;
						BaseChart.Chart.Axes.Left.Labels.Visible = true;

						knobGauge.Axis.Increment = 10;

				}

    }
}
