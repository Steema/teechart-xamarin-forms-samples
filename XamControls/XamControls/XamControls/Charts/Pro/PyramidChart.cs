using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;

namespace XamControls.Charts.Pro
{
	public class PyramidChart
	{

		private Pyramid pyramid1;
		private Variables.Variables var;
		private ChartView BaseChart;

		public PyramidChart(ChartView BaseChart)
		{

			pyramid1 = new Pyramid();
			var = new Variables.Variables();
			this.BaseChart = BaseChart;

			BaseChart.Chart.Header.Text = "Pyramid Series";
			BaseChart.Chart.Series.Add(pyramid1);
			BaseChart.Chart.Legend.Visible = true;
			BaseChart.Chart.Walls.Left.Visible = false;
			BaseChart.Chart.Walls.Left.Width = 5;

			pyramid1.SeriesColor = var.GetPaletteBasic[0];
			pyramid1.Chart.Zoom.Allow = false;
			pyramid1.Chart.Panning.Allow = ScrollModes.None;

			pyramid1.DefaultNullValue = 0;
			pyramid1.Pen.Width = 3;
			pyramid1.Pen.Visible = true;
			pyramid1.Pen.Color = Color.White;
			pyramid1.Pen.Style = DashStyle.Solid;
			pyramid1.Pen.Transparency = 50;
			pyramid1.SizePercent = 80;
			pyramid1.ColorEach = false;

			for (int i = 0; i < var.GetValorPie1.Length; i++) {

					pyramid1.Add(var.GetValorPyramidX[i], var.GetValorPyramidY[i], var.GetValorPyramidName[i], var.GetPaletteBasic[i]);

			}

			pyramid1.Title = "Feudal society";

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 50, BaseChart.Chart.Axes.Left.MaxYValue + 50);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinYValue + 0.5, BaseChart.Chart.Axes.Bottom.MaxXValue - 0.5);

			BaseChart.Chart.Axes.Bottom.Increment = 5;
			BaseChart.Chart.Axes.Left.Increment = 5;

			BaseChart.Chart.Axes.Left.Visible = false;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.FromRgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
			BaseChart.Chart.Axes.Bottom.Visible = false;

			BaseChart.Chart.Axes.Left.Grid.Visible = false;
			BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
			BaseChart.Chart.Legend.Visible = false;

			// Themes Marks
			Themes.AplicarMarksTheme1(BaseChart);

			BaseChart.Chart.Series[0].Marks.Font.Size = 18;
			BaseChart.Chart.Panel.MarginLeft = 5;
			pyramid1.Marks.Style = MarksStyles.Label;
			pyramid1.Marks.Visible = false;
			pyramid1.Marks.DrawEvery = 1;
			pyramid1.Marks.AutoPosition = true;
			pyramid1.Marks.OnTop = true;
                    

		}

	}

}
