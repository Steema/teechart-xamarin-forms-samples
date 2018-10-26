using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Statistical
{
    public class DataHistogramProFunctionChart
    {

				private Line line;
				private Histogram histogram;
				private Steema.TeeChart.Functions.HistogramFunction histogramFunction;
				private Variables.Variables var;

				public DataHistogramProFunctionChart(ChartView BaseChart)
				{

						line = new Line();
						histogram = new Histogram();
						histogramFunction = new HistogramFunction();
						var = new Variables.Variables();

				}

    }
}
