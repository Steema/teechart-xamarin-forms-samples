using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;
using XamControls.Tools;

namespace XamControls.Charts.Standard
{
		public class HorizontalLineChart
		{

				private HorizLine line1;
				private HorizLine line2;
				private Variables.Variables var;
				private ChartView BaseChart;
				private DataPointSelection tool_dataPointSelect;

				// Constructor del "LineChart"
				public HorizontalLineChart(ChartView BaseChart)
				{
					// Variables
					line1 = new HorizLine();
					line2 = new HorizLine();
					var = new Variables.Variables();
					this.BaseChart = BaseChart;
					tool_dataPointSelect = new DataPointSelection(BaseChart);

					// Modificación del "Chart" base
					BaseChart.Chart.ClickSeries += null;
					BaseChart.Chart.Legend.Visible = true;
					BaseChart.Chart.Header.Text = "Bear population in two forests";
					BaseChart.Chart.Series.Add(line1);
					BaseChart.Chart.Series.Add(line2);

					line1.Add(var.GetValorHorizLine1, var.GetValorHorizLineY, true);
					line2.Add(var.GetValorHorizLine2, var.GetValorHorizLineY,  true);

					// Propiedades de la "line1"

					line1.LinePen.Width = 6;
					line1.LinePen.Color = var.GetPaletteBasic[0];

					line1.Pointer.Color = var.GetPaletteBasic[0];
					line1.Pointer.InflateMargins = true;
					line1.Pointer.Visible = true;
					line1.Pointer.HorizSize = 11;
					line1.Pointer.VertSize = 11;
					line1.Pointer.Pen.EndCap = PenLineCap.Round;
					line1.Pointer.Pen.Color = Color.White;
					line1.Pointer.Pen.Width = 5;
					line1.Pointer.Style = PointerStyles.Sphere;

					line1.SeriesColor = var.GetPaletteBasic[0];
					line1.Chart.Zoom.Allow = false;
					line1.Chart.Panning.Allow = ScrollModes.None;
					line1.LineHeight = 25;
					line1.ClickableLine = true;
					line1.ClickPointer += tool_dataPointSelect.PointValue_Click;
					line1.GetSeriesMark += tool_dataPointSelect.Serie_GetSeriesMark;
					line1.ClickTolerance = 40;
					line1.RecalcOptions = RecalcOptions.OnModify;
					line1.Title = "Forest 1";
					line1.DefaultNullValue = 0;
					line1.VertAxis = VerticalAxis.Both;
					line1.HorizAxis = HorizontalAxis.Both;

					// Propiedades de la "line2"
					line2.LinePen = new ChartPen { Width = 6, Color = var.GetPaletteBasic[1], };
					line2.Pointer = new SeriesPointer(BaseChart.Chart, line2) { Color = var.GetPaletteBasic[1], InflateMargins = true, HorizSize = 11, VertSize = 11, Pen = new ChartPen { EndCap = PenLineCap.Round, Color = Xamarin.Forms.Color.White, Width = 5 }, Style = PointerStyles.Sphere };
					line2.SeriesColor = var.GetPaletteBasic[1];
					line2.Chart.Zoom.Allow = false;
					line2.Chart.Panning.Allow = ScrollModes.None;
					line2.LineHeight = 25;
					line2.ClickableLine = true;
					line2.ClickPointer += tool_dataPointSelect.PointValue_Click;
					line2.GetSeriesMark += tool_dataPointSelect.Serie_GetSeriesMark;
					line2.ClickTolerance = 40;
					line2.RecalcOptions = RecalcOptions.OnModify;
					line2.Title = "Forest 2";
					line2.VertAxis = VerticalAxis.Both;
					line2.HorizAxis = HorizontalAxis.Both;

					// Características de los ejes del "Chart" base
					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
					BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.Increment = 20;
					BaseChart.Chart.Axes.Left.Increment = 1;
					BaseChart.Chart.Axes.Left.Visible = true;
					BaseChart.Chart.Axes.Left.Title = null;
					BaseChart.Chart.Axes.Bottom.Title = null;
					BaseChart.Chart.Axes.Left.AxisPen.Visible = false;
					BaseChart.Chart.Axes.Left.Ticks.Visible = false;
					BaseChart.Chart.Axes.Left.Grid.Visible = true;
					BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
					BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
					BaseChart.Chart.Panel.MarginLeft = 5;


					// Themes Marks
					Themes.AplicarMarksTheme1(BaseChart);
					line1.Marks.Font.Size = 18;
					line2.Marks.Font.Size = 18;
					line1.Marks.TailParams.PointerWidth = 0;
					line1.Marks.Arrow.Visible = false;
					line2.Marks.TailParams.PointerWidth = 0;
					line2.Marks.Arrow.Visible = false;
					line1.Marks.ArrowLength = 0;
					line2.Marks.ArrowLength = 0;
					line1.Marks.TailParams.PointerHeight = 0;
					line2.Marks.TailParams.PointerHeight = 0;


        }
	}
}
