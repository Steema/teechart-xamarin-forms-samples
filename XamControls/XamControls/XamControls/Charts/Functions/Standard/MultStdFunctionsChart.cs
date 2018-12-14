using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using XamControls.Styles;
using Xamarin.Forms;

namespace XamControls.Charts.Functions.Standard
{
    public class MultStdFunctionsChart : SeriesModel
    {

		private Steema.TeeChart.Functions.Multiply multFunction;
		private Bar bar1;
		private Bar bar2;
		private Line theMultLine;
		private Variables.Variables var;

		public MultStdFunctionsChart(ChartView BaseChart)
		{

			multFunction = new Steema.TeeChart.Functions.Multiply();
			bar1 = new Bar();
			bar2 = new Bar();
			theMultLine = new Line();
			var = new Variables.Variables();

			for (int i = 0; i < var.GetValorStdMult1.Length; i++) { bar1.Add(i, var.GetValorStdMult1[i]); }
			for (int i = 0; i < var.GetValorStdMult2.Length; i++) { bar2.Add(i, var.GetValorStdMult2[i]); }

			BaseChart.Chart.Series.Add(bar1);
			BaseChart.Chart.Series.Add(bar2);
			BaseChart.Chart.Series.Add(theMultLine);

			theMultLine.Function = multFunction;
			theMultLine.DataSource = new object[] { bar1, bar2 };

			bar1.SeriesColor = var.GetPaletteBasic[0];
			bar2.SeriesColor = var.GetPaletteBasic[1];
			theMultLine.SeriesColor = var.GetPaletteBasic[2];

			bar1.Title = "Data 1";
			bar1.MarksOnBar = true;
			bar1.MarksLocation = MarksLocation.Start;

			bar2.Title = "Data 2";
			bar2.MarksOnBar = true;
			bar2.MarksLocation = MarksLocation.Start;

			theMultLine.Title = "Multiply";
			theMultLine.LinePen.Width = 6;
			theMultLine.Pointer.Style = PointerStyles.Sphere;
			theMultLine.Pointer.InflateMargins = true;
			theMultLine.Pointer.HorizSize = 5;
			theMultLine.Pointer.VertSize = 5;
			theMultLine.Pointer.Visible = true;
			theMultLine.Marks.Visible = true;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue + 0.1, BaseChart.Chart.Axes.Left.MaxYValue + 2);
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
			bar2.Marks.Pen.Visible = false;

			bar1.Marks.TailStyle = MarksTail.None;
			bar2.Marks.TailStyle = MarksTail.None;

			BaseChart.Chart.Series[0].Marks.TextAlign = TextAlignment.Center;
			BaseChart.Chart.Series[0].Marks.AutoSize = true;
			BaseChart.Chart.Series[0].Marks.Color = Xamarin.Forms.Color.Transparent;
			BaseChart.Chart.Series[1].Marks.TextAlign = TextAlignment.Center;
			BaseChart.Chart.Series[1].Marks.AutoSize = true;
			BaseChart.Chart.Series[1].Marks.Color = Xamarin.Forms.Color.Transparent;
			//BaseChart.Chart.Series[2].Marks.ShapeBounds = new Xamarin.Forms.Rectangle { Width = 80, Height = 50 };
			BaseChart.Chart.Series[2].Marks.TailStyle = MarksTail.None;
			BaseChart.Chart.Panel.MarginLeft = 5;

            ImplementiOSMarks(BaseChart.Chart);

        }
		
    }
}
