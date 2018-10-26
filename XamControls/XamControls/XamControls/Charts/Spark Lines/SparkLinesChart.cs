using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace XamControls.Charts.Spark_Lines
{
    public class SparkLinesChart
    {

				private Line sparkLine;

				public SparkLinesChart(ChartView BaseChart)
				{

						sparkLine = new Line();
						sparkLine.FillSampleValues();

						BaseChart.Chart.Series.Add(sparkLine);

				}
				

    }
}
