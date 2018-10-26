using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class RMSProFunctionChart
    {

				private Line line1;
				private Line line2;
				private RootMeanSquare rootMeanSquare;
				private Variables.Variables var;

				public RMSProFunctionChart(ChartView BaseChart)
				{

						line1 = new Line();
						line2 = new Line();
						rootMeanSquare = new RootMeanSquare();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Root Mean Square";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.Increment = 100;

						line1.FillSampleValues(30);
						line1.Title = "Data Source";
						line1.LinePen.Width = 3;
						line1.Color = var.GetPaletteBasic[0];

						line2.DataSource = line1;
						line2.Function = rootMeanSquare;
						line2.Title = "RMS";
						line2.LinePen.Width = 3;
						line2.Color = var.GetPaletteBasic[1];

						rootMeanSquare.Complete = true;

						BaseChart.Chart.Series.Add(line1);
						BaseChart.Chart.Series.Add(line2);


				}

    }
}
