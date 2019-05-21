using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace XamControls.Charts.TagCloud
{
    public class TagCloudChart
    {
        #if !TEE_STD
				private Steema.TeeChart.Styles.TagCloud tagCloud;

				public TagCloudChart(ChartView BaseChart)
				{

						tagCloud = new Steema.TeeChart.Styles.TagCloud();
						tagCloud.FillSampleValues(40);

						BaseChart.Chart.Header.Font.Size = 60;
						BaseChart.Chart.Header.Transparency = 100;

						BaseChart.Chart.Series.Add(tagCloud);
						tagCloud.TagSeparation = 5;

				}
#endif
    }
}
