using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamControls.Charts.Pro
{
    public class BoxPlotChart
    {
#if !TEE_STD
        private Box boxPlot;

				public BoxPlotChart(ChartView BaseChart)
				{

						boxPlot = new Box();
						boxPlot.FillSampleValues();
						BaseChart.Chart.Series.Add(boxPlot);
				
				}
#endif
    }
}
