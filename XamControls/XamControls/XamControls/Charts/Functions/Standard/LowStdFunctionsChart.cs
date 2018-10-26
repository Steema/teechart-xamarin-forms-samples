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
    public class LowStdFunctionsChart
    {

		private Steema.TeeChart.Functions.Low lowFunction;
		private Bar bar1;
		private Line theLowLine;
		private Variables.Variables var;

		public LowStdFunctionsChart(ChartView BaseChart)
		{

			lowFunction = new Steema.TeeChart.Functions.Low();
			bar1 = new Bar();
			theLowLine = new Line();
			var = new Variables.Variables();

			for (int i = 0; i < var.GetValorStdLow1.Length; i++) { bar1.Add(i, var.GetValorStdLow1[i]); }

			BaseChart.Chart.Series.Add(bar1);
			BaseChart.Chart.Series.Add(theLowLine);

			theLowLine.Function = lowFunction;
			theLowLine.DataSource = new object[] { bar1 };

			bar1.SeriesColor = var.GetPaletteBasic[0];
			theLowLine.SeriesColor = var.GetPaletteBasic[2];

			bar1.Title = "Data";
			bar1.MarksOnBar = true;
			bar1.MarksLocation = MarksLocation.Start;

			theLowLine.Title = "Low";
			theLowLine.LinePen.Width = 6;
			theLowLine.Pointer.Style = PointerStyles.Sphere;
			theLowLine.Pointer.InflateMargins = true;
			theLowLine.Pointer.HorizSize = 5;
			theLowLine.Pointer.VertSize = 5;
			theLowLine.Pointer.Visible = true;
			theLowLine.Marks.Visible = true;
			theLowLine.Marks.DrawEvery = 2;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue + 0.15, BaseChart.Chart.Axes.Left.MaxYValue + 2);
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
