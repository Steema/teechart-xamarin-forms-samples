using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class PerformanceProFunctionChart : SeriesModel
    {

				private Bar bar;
				private Line line;
				private Performance performance;
				private Variables.Variables var;

				public PerformanceProFunctionChart(ChartView BaseChart)
				{

						bar = new Bar();
						line = new Line();
						performance = new Performance();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Performance";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;

						FillSampleValues(bar, 7, 400);
						bar.Color = var.GetPaletteBasic[0];
						bar.Pen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.15);
						bar.Marks.Visible = true;
						bar.Marks.FollowSeriesColor = true;
						bar.Marks.Font.Size += 5;
						bar.Marks.TailStyle = MarksTail.None;
						bar.Title = "Data Source";

						line.DataSource = bar;
						line.Function = performance;
						line.Color = var.GetPaletteBasic[1];
						line.LinePen.Width = 3;
						line.Title = "Performance";

						performance.Period = 1;

						BaseChart.Chart.Series.Add(bar);
						BaseChart.Chart.Series.Add(line);

				}

    }
}
