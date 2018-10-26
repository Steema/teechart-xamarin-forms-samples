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
    public class CountStdFunctionsChart
    {

		private Steema.TeeChart.Functions.Count countFunction;
		private Bar bar1;
		private Line theCountLine;
		private Variables.Variables var;

		public CountStdFunctionsChart(ChartView BaseChart)
		{

			countFunction = new Steema.TeeChart.Functions.Count();
			bar1 = new Bar();
			theCountLine = new Line();
			var = new Variables.Variables();

			for (int i = 0; i < var.GetValorStdCount1.Length; i++) { bar1.Add(i, var.GetValorStdCount1[i]); }

			BaseChart.Chart.Series.Add(bar1);
			BaseChart.Chart.Series.Add(theCountLine);

			theCountLine.Function = countFunction;
			theCountLine.DataSource = new object[] { bar1 };

			bar1.SeriesColor = var.GetPaletteBasic[0];
			theCountLine.SeriesColor = var.GetPaletteBasic[2];

			bar1.Title = "Data";
			bar1.MarksOnBar = true;
			bar1.MarksLocation = MarksLocation.Start;

			theCountLine.Title = "Count";
			theCountLine.LinePen.Width = 6;
			theCountLine.Pointer.Style = PointerStyles.Sphere;
			theCountLine.Pointer.InflateMargins = true;
			theCountLine.Pointer.HorizSize = 5;
			theCountLine.Pointer.VertSize = 5;
			theCountLine.Pointer.Visible = true;
			theCountLine.Marks.Visible = true;
			theCountLine.Marks.DrawEvery = 2;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue + 0.07, BaseChart.Chart.Axes.Left.MaxYValue + 2);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
			BaseChart.Chart.Axes.Left.Increment = 3;
			BaseChart.Chart.Axes.Bottom.Labels.Visible = false;
			BaseChart.Chart.Axes.Left.Grid.Visible = false;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Header.Visible = false;

			Themes.AplicarMarksTheme1(BaseChart);
			BaseChart.Chart.Series[0].Marks.Font.Size = 14;
			BaseChart.Chart.Series[1].Marks.Font.Size = 14;

			bar1.Marks.Pen.Visible = false;
			bar1.Marks.TailStyle = MarksTail.None;

			BaseChart.Chart.Series[0].Marks.TextAlign = TextAlignment.Center;
			BaseChart.Chart.Series[0].Marks.AutoSize = true;
			BaseChart.Chart.Series[0].Marks.Color = Xamarin.Forms.Color.Transparent;
			BaseChart.Chart.Series[1].Marks.TailStyle = MarksTail.None;
			BaseChart.Chart.Panel.MarginLeft = 5;


		}
		
    }
}
