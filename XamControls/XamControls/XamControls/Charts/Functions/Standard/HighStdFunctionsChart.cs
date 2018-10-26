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
    public class HighStdFunctionsChart
    {

		private Steema.TeeChart.Functions.High highFunction;
		private Bar bar1;
		private Line theHighLine;
		private Variables.Variables var;

		public HighStdFunctionsChart(ChartView BaseChart)
		{

			highFunction = new Steema.TeeChart.Functions.High();
			bar1 = new Bar();
			theHighLine = new Line();
			var = new Variables.Variables();

			for (int i = 0; i < var.GetValorStdHigh1.Length; i++) { bar1.Add(i, var.GetValorStdHigh1[i]); }

			BaseChart.Chart.Series.Add(bar1);
			BaseChart.Chart.Series.Add(theHighLine);

			theHighLine.Function = highFunction;
			theHighLine.DataSource = new object[] { bar1 };

			bar1.SeriesColor = var.GetPaletteBasic[0];
			theHighLine.SeriesColor = var.GetPaletteBasic[2];

			bar1.Title = "Data";
			bar1.MarksOnBar = true;
			bar1.MarksLocation = MarksLocation.Start;

			theHighLine.Title = "High";
			theHighLine.LinePen.Width = 6;
			theHighLine.Pointer.Style = PointerStyles.Sphere;
			theHighLine.Pointer.InflateMargins = true;
			theHighLine.Pointer.HorizSize = 5;
			theHighLine.Pointer.VertSize = 5;
			theHighLine.Pointer.Visible = true;
			theHighLine.Marks.Visible = true;
			theHighLine.Marks.DrawEvery = 2;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue + 0.23, BaseChart.Chart.Axes.Left.MaxYValue + 2);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
			BaseChart.Chart.Axes.Left.Increment = 5;
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
			BaseChart.Chart.Series[0].Marks.Color = Color.Transparent;
			BaseChart.Chart.Series[1].Marks.TailStyle = MarksTail.None;
			BaseChart.Chart.Panel.MarginLeft = 5;


		}
		
    }
}
