using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using XamControls.Variables;
using XamControls.Styles;
using Xamarin.Forms;
using Steema.TeeChart.Drawing;

namespace XamControls.Charts.Functions.Standard
{
    public class PercentStdFunctionsChart : SeriesModel
    {

		private Steema.TeeChart.Functions.PercentChange percentFunction;
		private Area area;
		private Line thePercentLine;
		private Variables.Variables var;

		public PercentStdFunctionsChart(ChartView BaseChart)
		{

			percentFunction = new Steema.TeeChart.Functions.PercentChange();
			area = new Area();
			thePercentLine = new Line();
			var = new Variables.Variables();

			for (int i = 0; i < var.GetValorStdPercent1.Length; i++) { area.Add(i, var.GetValorStdPercent1[i]); }

			BaseChart.Chart.Series.Add(area);
			BaseChart.Chart.Series.Add(thePercentLine);

			thePercentLine.Function = percentFunction;
			thePercentLine.DataSource = new object[] { area };

			area.SeriesColor = var.GetPaletteBasic[0];
			thePercentLine.SeriesColor = var.GetPaletteBasic[2];

			area.Title = "Data";
			area.Smoothed = true;

			thePercentLine.Title = "Percent Change";
			thePercentLine.LinePen.Width = 6;
			thePercentLine.Pointer.Visible = false;
			thePercentLine.Marks.Visible = false;
			thePercentLine.VertAxis = VerticalAxis.Right;
            thePercentLine.LinePen.DashCap = PenLineCap.Round;
            thePercentLine.LinePen.EndCap = PenLineCap.Round;

            BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue + 2);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
			BaseChart.Chart.Axes.Left.Increment = 3;
			BaseChart.Chart.Axes.Bottom.Labels.Visible = false;
			BaseChart.Chart.Axes.Left.Grid.Visible = false;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Header.Visible = false;

			Themes.AplicarMarksTheme1(BaseChart);
			BaseChart.Chart.Series[0].Marks.Font.Size = 14;
			BaseChart.Chart.Series[1].Marks.Font.Size = 14;
				
			area.Marks.Pen.Visible = false;

			area.Marks.TailStyle = MarksTail.None;
			area.Transparency = 50;
			area.AreaLines.Visible = false;
			area.LinePen.Color = area.Color.AddLuminosity(-0.2);
			area.LinePen.Width = 5;
			area.LinePen.Transparency = 50;
			area.AreaLines.Width = 0;
			area.AreaLines.Transparency = 100;
			area.AreaLinesPen.Width = 1;
			area.AreaLinesPen.Visible = true;

			BaseChart.Chart.Series[0].Marks.TextAlign = TextAlignment.Center;
			BaseChart.Chart.Series[0].Marks.AutoSize = true;
			BaseChart.Chart.Series[0].Marks.Color = Xamarin.Forms.Color.Transparent;
			//BaseChart.Chart.Series[1].Marks.ShapeBounds = new Xamarin.Forms.Rectangle { Width = 85, Height = 40 };
			BaseChart.Chart.Series[1].Marks.TailStyle = MarksTail.None;
			BaseChart.Chart.Panel.MarginLeft = 3;

            ImplementiOSMarks(BaseChart.Chart);

        }
		
    }
}
