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
    public class DivStdFunctionsChart
    {

		private Steema.TeeChart.Functions.Divide divFunction;
		private Bar bar1;
		private Bar bar2;
		private Line theDivLine;
		private Variables.Variables var;

		public DivStdFunctionsChart(ChartView BaseChart)
		{

			divFunction = new Steema.TeeChart.Functions.Divide();
			bar1 = new Bar();
			bar2 = new Bar();
			theDivLine = new Line();
			var = new Variables.Variables();

			for (int i = 0; i < var.GetValorStdDiv1.Length; i++) { bar1.Add(i, var.GetValorStdDiv1[i]); }
			for (int i = 0; i < var.GetValorStdDiv2.Length; i++) { bar2.Add(i, var.GetValorStdDiv2[i]); }

			BaseChart.Chart.Series.Add(bar1);
			BaseChart.Chart.Series.Add(bar2);
			BaseChart.Chart.Series.Add(theDivLine);

			theDivLine.Function = divFunction;
			theDivLine.DataSource = new object[] { bar1, bar2 };

			bar1.SeriesColor = var.GetPaletteBasic[0];
			bar2.SeriesColor = var.GetPaletteBasic[1];
			theDivLine.SeriesColor = var.GetPaletteBasic[2];

			bar1.Title = "Data 1";
			bar1.MarksOnBar = true;
			bar1.MarksLocation = MarksLocation.Start;

			bar2.Title = "Data 2";
			bar2.MarksOnBar = true;
			bar2.MarksLocation = MarksLocation.Start;

			theDivLine.Title = "Divide";
			theDivLine.LinePen.Width = 6;
			theDivLine.Pointer.Style = PointerStyles.Sphere;
			theDivLine.Pointer.InflateMargins = true;
			theDivLine.Pointer.HorizSize = 5;
			theDivLine.Pointer.VertSize = 5;
			theDivLine.Pointer.Visible = true;
			theDivLine.Marks.Visible = true;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue + 0.1, BaseChart.Chart.Axes.Left.MaxYValue + 2);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
			BaseChart.Chart.Axes.Left.Increment = 3;
			BaseChart.Chart.Axes.Bottom.Labels.Visible = false;
			BaseChart.Chart.Axes.Left.Grid.Visible = false;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Header.Visible = false;

            bar1.Marks.Font.Size = 14;
            bar1.Marks.Pen.Visible = false;
            bar1.Marks.TailStyle = MarksTail.None;
            bar1.Marks.Height += 4;
            bar1.Marks.TextAlign = TextAlignment.Center;
            bar1.Marks.BackColor = Xamarin.Forms.Color.Transparent;
            bar1.Marks.Font.Color = Color.White;

            bar2.Marks.Font.Size = 14;
            bar2.Marks.TailStyle = MarksTail.None;
            bar2.Marks.TextAlign = TextAlignment.Center;
            bar2.Marks.BackColor = Xamarin.Forms.Color.Transparent;
            bar2.Marks.Height += 4;
            bar2.Marks.Pen.Visible = false;
            bar2.Marks.Font.Color = Color.White;

            theDivLine.Marks.Font.Size = 15;
            theDivLine.Marks.FollowSeriesColor = true;
            theDivLine.Marks.TailStyle = MarksTail.None;
            theDivLine.Marks.Pen.Width = 1;
            theDivLine.Marks.Pen.Color = theDivLine.Color.AddLuminosity(-0.3);

            BaseChart.Chart.Panel.MarginLeft = 5;


		}

    }
}
