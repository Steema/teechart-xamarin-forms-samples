using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class CumulativeProFunctionChart
    {

				private Bar bar;
				private Line line;
				private Cumulative cumulative;
				private Variables.Variables var;

				public CumulativeProFunctionChart(ChartView BaseChart)
				{

						bar = new Bar();
						line = new Line();
						cumulative = new Cumulative();
						var = new Variables.Variables();

						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Title.Text = "Cumulative";
						BaseChart.Chart.Axes.Left.Increment = 100;

						bar.FillSampleValues(6);
						bar.Title = "Data Source";
						bar.Color = var.GetPaletteBasic[0];
						bar.Pen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);

						line.DataSource = bar;
						line.Function = cumulative;
						line.Title = "Cumulative";
						line.Color = var.GetPaletteBasic[1];
						line.LinePen.Width = 3;
						line.Marks.Visible = true;
						line.Marks.Arrow.Visible = false;
						line.Marks.TailStyle = MarksTail.None;

						cumulative.Period = 1;

						BaseChart.Chart.Series.Add(bar);
						BaseChart.Chart.Series.Add(line);

						bar.Marks.FollowSeriesColor = true;
						line.Marks.FollowSeriesColor = true;
						bar.MarksLocation = MarksLocation.Center;
						bar.MarksOnBar = true;
						bar.Marks.BackColor = Color.Transparent;
						bar.Marks.Color = Color.Transparent;
						bar.Marks.Pen.Color = Color.Transparent;
						bar.Marks.Font.Size += 4;
						line.Marks.Font.Size += 4;
						line.Marks.Width += 5;
						line.Marks.Height += 5;


				}

    }
}
