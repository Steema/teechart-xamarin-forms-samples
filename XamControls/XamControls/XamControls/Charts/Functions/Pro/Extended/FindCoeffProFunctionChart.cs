using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class FindCoeffProFunctionChart
    {

		FastLine fastLineSource;
		FastLine fastLineCoe1;
		FastLine fastLineCoe2;
#if !TEE_STD
        PolyFitting polyFitting;
		PolyFitting polyFitting2;
#endif
		Variables.Variables var;

		public FindCoeffProFunctionChart(ChartView BaseChart)
		{

			fastLineSource = new FastLine();
			fastLineCoe1 = new FastLine();
			fastLineCoe2 = new FastLine();
#if !TEE_STD
            polyFitting = new PolyFitting();
			polyFitting2 = new PolyFitting();

			var = new Variables.Variables();

			BaseChart.Chart.Title.Text = "Polynomial Fitting";
			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Bottom.Automatic = true;
			BaseChart.Chart.Axes.Left.Increment = 100;

			fastLineSource.FillSampleValues(40);
			fastLineSource.LinePen.Width = 3;
			fastLineSource.Color = var.GetPaletteBasic[0];
			fastLineSource.Title = "Data Source";
            fastLineSource.Marks.DrawEvery = 4;

			fastLineCoe1.DataSource = fastLineSource;
			fastLineCoe1.Function = polyFitting;
			fastLineCoe1.LinePen.Width = 3;
			fastLineCoe1.Color = var.GetPaletteBasic[1];
			fastLineCoe1.Title = "Curve 1";
            fastLineCoe1.Marks.DrawEvery = 4;

            fastLineCoe2.DataSource = fastLineSource;
			fastLineCoe2.Function = polyFitting2;
			fastLineCoe2.LinePen.Width = 3;
			fastLineCoe2.Color = var.GetPaletteBasic[2];
			fastLineCoe2.Title = "Curve 2";
            fastLineCoe2.Marks.DrawEvery = 4;

            polyFitting.PolyDegree = 5;
			polyFitting2.PolyDegree = 14;

			BaseChart.Chart.Series.Add(fastLineSource);
			BaseChart.Chart.Series.Add(fastLineCoe1);
			BaseChart.Chart.Series.Add(fastLineCoe2);
#endif
        }

    }
}
