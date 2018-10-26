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
    public class MedianStdFunctionsChart
    {

		private Steema.TeeChart.Functions.MedianFunction medianFunction;
		private Line line;
		private Line theMedianLine;
		private Variables.Variables var;

		public MedianStdFunctionsChart(ChartView BaseChart)
		{

			medianFunction = new Steema.TeeChart.Functions.MedianFunction();
			line = new Line();
			theMedianLine = new Line();
			var = new Variables.Variables();

			for (int i = 0; i < var.GetValorStdMedian1.Length; i++) { line.Add(i, var.GetValorStdMedian1[i]); }

			BaseChart.Chart.Series.Add(line);
			BaseChart.Chart.Series.Add(theMedianLine);

			theMedianLine.Function = medianFunction;
			theMedianLine.DataSource = new object[] { line };

			line.SeriesColor = var.GetPaletteBasic[0];
			theMedianLine.SeriesColor = var.GetPaletteBasic[2];

			line.Title = "Data";
			line.Marks.Visible = false;
			line.LinePen.Width = 4;

			theMedianLine.Title = "Median";
			theMedianLine.LinePen.Width = 6;
			theMedianLine.Pointer.Visible = true;
			theMedianLine.Marks.Visible = true;
			theMedianLine.Marks.DrawEvery = 2;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue + 2);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
			BaseChart.Chart.Axes.Left.Increment = 10;
			BaseChart.Chart.Axes.Bottom.Labels.Visible = false;
			BaseChart.Chart.Axes.Left.Grid.Visible = false;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Header.Visible = false;

			Themes.AplicarMarksTheme1(BaseChart);
			BaseChart.Chart.Series[0].Marks.Font.Size = 14;
			BaseChart.Chart.Series[1].Marks.Font.Size = 14;

			BaseChart.Chart.Series[0].Marks.TextAlign = TextAlignment.Center;
			BaseChart.Chart.Series[0].Marks.AutoSize = true;
			BaseChart.Chart.Series[0].Marks.Color = Xamarin.Forms.Color.Transparent;
			BaseChart.Chart.Series[1].Marks.TailStyle = MarksTail.None;
			BaseChart.Chart.Panel.MarginLeft = 5;


		}
		
    }
}
