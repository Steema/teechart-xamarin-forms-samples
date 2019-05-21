using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;

namespace XamControls.Charts.Clock
{
    public class BasicClockChart
		{
#if !TEE_STD
        private Steema.TeeChart.Styles.Clock clock;

				public BasicClockChart(ChartView BaseChart)
				{

						clock = new Steema.TeeChart.Styles.Clock();

						clock.FillSampleValues();

                        BaseChart.Chart.Title.Text = "";

						BaseChart.Chart.Series.Add(clock);

				}

                public void RemoveTimer()
                {

                    clock.CancelTimer = true;

                }
#endif
    }
}
