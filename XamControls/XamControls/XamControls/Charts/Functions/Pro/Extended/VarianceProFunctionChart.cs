using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class VarianceProFunctionChart : SeriesModel
    {

				private Points points;
				private Line line;
				private VarianceFunction variance;
				private Variables.Variables var;

				public VarianceProFunctionChart(ChartView BaseChart)
				{

						points = new Points();
						line = new Line();
						variance = new VarianceFunction();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Variance";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Right.Automatic = true;
						BaseChart.Chart.Axes.Left.Increment = 40;

						FillSampleValues(points, 30, 600, 0);
						points.Title = "Data Source";
						points.Pointer.HorizSize += 3;
						points.Pointer.VertSize += 3;
						points.Pointer.Style = PointerStyles.Circle;
						points.Color = var.GetPaletteBasic[0];

						line.DataSource = points;
						line.Function = variance;
						line.Title = "Variance";
						line.LinePen.Width = 3;
						line.Color = var.GetPaletteBasic[1];
						line.VertAxis = VerticalAxis.Right;
						line.Marks.Visible = true;
						line.Marks.DrawEvery = 2;
						line.Marks.FollowSeriesColor = true;
						line.Marks.AutoPosition = false;
						line.Marks.TailStyle = MarksTail.None;
						line.Marks.Left += 300;
						line.Marks.Width += 20;
						line.Marks.Height += 25;
						line.Marks.Font.Size += 4;

						BaseChart.Chart.Series.Add(points);
						BaseChart.Chart.Series.Add(line);

				}

    }
}
