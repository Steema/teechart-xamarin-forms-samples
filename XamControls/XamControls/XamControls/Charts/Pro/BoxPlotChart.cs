using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamControls.Charts.Pro
{
    public class BoxPlotChart
    {

				private Box boxPlot;

				public BoxPlotChart(ChartView BaseChart)
				{

						boxPlot = new Box();
						boxPlot.FillSampleValues();
						BaseChart.Chart.Series.Add(boxPlot);
				
				}

    }
}
