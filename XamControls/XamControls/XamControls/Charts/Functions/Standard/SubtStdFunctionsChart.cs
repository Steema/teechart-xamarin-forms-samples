using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using XamControls.Variables;
using Steema.TeeChart.Themes;
using XamControls.Styles;
using System.Drawing;
using Xamarin.Forms;

namespace XamControls.Charts.Functions.Standard
{
    public class SubtStdFunctionsChart
    {

		private Steema.TeeChart.Functions.Subtract subtFunction;
		private Bar bar1;
		private Bar bar2;
		private Line theSubtLine;
		private Variables.Variables var;

		public SubtStdFunctionsChart(ChartView BaseChart)
		{

			subtFunction = new Steema.TeeChart.Functions.Subtract();
			bar1 = new Bar();
			bar2 = new Bar();
			theSubtLine = new Line();
			var = new Variables.Variables();

			for(int i = 0; i < var.GetValorStdSubs1.Length; i++) { bar1.Add(i, var.GetValorStdSubs1[i]); }
			for(int i = 0; i < var.GetValorStdSubs2.Length; i++) { bar2.Add(i, var.GetValorStdSubs2[i]); }

			BaseChart.Chart.Series.Add(bar1);
			BaseChart.Chart.Series.Add(bar2);
			BaseChart.Chart.Series.Add(theSubtLine);
			
			theSubtLine.Function = subtFunction;
			theSubtLine.DataSource = new object[] { bar1, bar2 };

			bar1.Title = "Data 1";
			bar1.MarksOnBar = true;
			bar1.MarksLocation = MarksLocation.Start;
			bar1.SeriesColor = var.GetPaletteBasic[0];

			bar2.Title = "Data 2";
			bar2.MarksOnBar = true;
			bar2.MarksLocation = MarksLocation.Start;
			bar2.SeriesColor = var.GetPaletteBasic[1];

			theSubtLine.Title = "Subtract";
			theSubtLine.LinePen.Width = 6;
			theSubtLine.Pointer.Style = PointerStyles.Sphere;
			theSubtLine.Pointer.InflateMargins = true;
			theSubtLine.Pointer.HorizSize = 5;
			theSubtLine.Pointer.VertSize = 5;
			theSubtLine.TreatNulls = TreatNullsStyle.DoNotPaint;
			theSubtLine.Pointer.Visible = true;
			theSubtLine.Marks.Visible = true;
			theSubtLine.SeriesColor = var.GetPaletteBasic[2];

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue + 0.3, BaseChart.Chart.Axes.Left.MaxYValue + 3);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
			BaseChart.Chart.Axes.Left.Increment = 10;
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
			BaseChart.Chart.Series[2].Marks.TailStyle = MarksTail.None;
			BaseChart.Chart.Panel.MarginLeft = 5;
						

		}	
		
    }
}
