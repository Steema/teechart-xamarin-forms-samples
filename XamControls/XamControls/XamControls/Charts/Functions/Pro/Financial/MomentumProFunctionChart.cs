using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class MomentumProFunctionChart : SeriesModel
    {

				private Line line1;
				private Line line2;
				private Momentum momentum;
				private Variables.Variables var;

				public MomentumProFunctionChart(ChartView BaseChart)
				{

						line1 = new Line();
						line2 = new Line();
						momentum = new Momentum();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Momentum";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;

						FillSampleValues(line1, 30, 600);
						line1.Color = var.GetPaletteBasic[0];
						line1.LinePen.Width = 3;
						line1.Pointer.Visible = true;
						line1.Title = "Data Source";

						line2.LinePen.Width = 3;
						line2.DataSource = line1;
						line2.Function = momentum;
						line2.Title = "Momentum";
						line2.Color = var.GetPaletteBasic[1];

						momentum.Period = 10;

						BaseChart.Chart.Series.Add(line1);
						BaseChart.Chart.Series.Add(line2);

				}

    }
}
