using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using XamControls.Variables;
using XamControls.Styles;
using Xamarin.Forms;

namespace XamControls.Charts.Functions.Standard
{
    public class AvgStdFunctionsChart : SeriesModel
    {

		private Steema.TeeChart.Functions.Average avgFunction;
		private Bar bar1;
		private Line theAvgLine;
		private Variables.Variables var;

		public AvgStdFunctionsChart(ChartView BaseChart)
		{

			avgFunction = new Steema.TeeChart.Functions.Average();
			bar1 = new Bar();
			theAvgLine = new Line();
			var = new Variables.Variables();

			for (int i = 0; i < var.GetValorStdAvg1.Length; i++) { bar1.Add(i, var.GetValorStdAvg1[i]); }

			BaseChart.Chart.Series.Add(bar1);
			BaseChart.Chart.Series.Add(theAvgLine);

			theAvgLine.Function = avgFunction;
			theAvgLine.DataSource = new object[] { bar1 };

			bar1.SeriesColor = var.GetPaletteBasic[0];
			theAvgLine.SeriesColor = var.GetPaletteBasic[2];

			bar1.Title = "Data";
			bar1.MarksOnBar = true;
			bar1.MarksLocation = MarksLocation.Start;

			theAvgLine.Title = "Average";
			theAvgLine.LinePen.Width = 6;
			theAvgLine.Pointer.Style = PointerStyles.Sphere;
			theAvgLine.Pointer.InflateMargins = true;
			theAvgLine.Pointer.HorizSize = 5;
			theAvgLine.Pointer.VertSize = 5;
			theAvgLine.Pointer.Visible = true;
			theAvgLine.Marks.Visible = true;
			theAvgLine.Marks.DrawEvery = 2;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue + 1.6, BaseChart.Chart.Axes.Left.MaxYValue + 2);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
			BaseChart.Chart.Axes.Left.Increment = 20;
			BaseChart.Chart.Axes.Bottom.Labels.Visible = false;
			BaseChart.Chart.Axes.Left.Grid.Visible = false;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Header.Visible = false;

            theAvgLine.Marks.AutoSize = true;
            theAvgLine.Marks.FollowSeriesColor = true;
            theAvgLine.Marks.Pen.Width = 1;
            theAvgLine.Marks.Pen.Color = theAvgLine.Color.AddLuminosity(-0.3);
            theAvgLine.Marks.Font.Size = 13;

            bar1.Marks.Font.Size = 14;
            bar1.Marks.Pen.Visible = false;
			bar1.Marks.TailStyle = MarksTail.None;
            bar1.Marks.TextAlign = TextAlignment.Center;
            bar1.Marks.AutoSize = true;
            bar1.Marks.BackColor = Color.Transparent;
            bar1.Marks.Font.Color = Color.White;
            bar1.Marks.TailStyle = MarksTail.None;

			BaseChart.Chart.Panel.MarginLeft = 5;

            ImplementiOSMarks(BaseChart.Chart);

        }
		
    }
}
