using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class StdDeviationProFunctionChart
    {
#if !TEE_STD
        private Line line1;
				private Line line2;
				private StdDeviation stdDeviation;
				private Variables.Variables var;

				public StdDeviationProFunctionChart(ChartView BaseChart)
				{

						line1 = new Line();
						line2 = new Line();
						stdDeviation = new StdDeviation();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Standard Deviation";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;

						line1.FillSampleValues(30);
						line1.Title = "Data Source";
						line1.LinePen.Width = 3;
						line1.Color = var.GetPaletteBasic[0];

						line2.DataSource = line1;
						line2.Function = stdDeviation;
						line2.Title = "Deviation";
						line2.LinePen.Width = 3;
						line2.Color = var.GetPaletteBasic[1];

						stdDeviation.Complete = false;

						BaseChart.Chart.Series.Add(line1);
						BaseChart.Chart.Series.Add(line2);

				}
#endif
    }
}
