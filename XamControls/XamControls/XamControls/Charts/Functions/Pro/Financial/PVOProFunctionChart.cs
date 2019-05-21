using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class PVOProFunctionChart : SeriesModel
    {
#if !TEE_STD
        private Volume volume;
				private FastLine fastLine;
				private PVOFunction pvoFunction;
				private Variables.Variables var;

				public PVOProFunctionChart(ChartView BaseChart)
				{

						volume = new Volume();
						fastLine = new FastLine();
						pvoFunction = new PVOFunction();
						var = new Variables.Variables();

						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
						BaseChart.Chart.Axes.Left.Increment = 10;

						volume.FillSampleValues(15);
						volume.Color = var.GetPaletteBasic[0];
						volume.LinePen.Width = 3;
						volume.Title = "Volume";

						fastLine.Color = var.GetPaletteBasic[1];
						fastLine.DataSource = volume;
						fastLine.Function = pvoFunction;
						fastLine.LinePen.Width = 3;
						fastLine.Title = "FastLine";

						pvoFunction.Period = 12;

						BaseChart.Chart.Series.Add(volume);
						BaseChart.Chart.Series.Add(fastLine);


				}
#endif
    }
}
