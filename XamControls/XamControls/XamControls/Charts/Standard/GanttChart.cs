using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Styles;
using XamControls.Tools;
using static Steema.TeeChart.Axis;

namespace XamControls.Charts.Standard
{
    public class GanttChart
    {

			private Gantt gantt1;
			private Variables.Variables var;
			private ChartView BaseChart;

			// Constructor del "LineChart"
			public GanttChart(ChartView BaseChart)
			{
				// Variables
				gantt1 = new Gantt();
				var = new Variables.Variables();
				this.BaseChart = BaseChart;

				// Modificación del "Chart" base
				BaseChart.Chart.ClickSeries += null;
				BaseChart.Chart.Legend.Visible = true;
				BaseChart.Chart.Header.Text = "The development of the product";
				BaseChart.Chart.Series.Add(gantt1);

				//gantt1.FillSampleValues(10);

				for (int i = 0; i < var.GetValorGantt1.Length; i++)
				{

						gantt1.Add(var.GetValorTimeSGantt[i], var.GetValorTimeEGantt[i], i+1, var.GetValorGantt1[i]);

				}

				// Propiedades de la "line1"

				gantt1.LinePen.Width = 6;
				gantt1.LinePen.Color = var.GetPaletteBasic[0];

				gantt1.Pointer.Color = var.GetPaletteBasic[0];
				gantt1.Pointer.InflateMargins = true;
				gantt1.Pointer.Visible = true;
				gantt1.Pointer.HorizSize = 11;
				gantt1.Pointer.VertSize = 11;
				gantt1.Pointer.Pen.EndCap = PenLineCap.Round;
				gantt1.Pointer.Pen.Color = Color.White;
				gantt1.Pointer.Pen.Width = 1;
				gantt1.Pointer.Style = PointerStyles.Rectangle;

				gantt1.SeriesColor = var.GetPaletteBasic[0];
				gantt1.Chart.Zoom.Allow = false;
				gantt1.Chart.Panning.Allow = ScrollModes.None;
				gantt1.RecalcOptions = RecalcOptions.OnModify;
				gantt1.Title = "Product 1";
				gantt1.DefaultNullValue = 0;
				gantt1.ConnectingPen.Visible = true;
				gantt1.ConnectingPen.Color = Color.Black;
				gantt1.ConnectingPen.Width = 2;
				gantt1.NextTasks[0] = 1;
				gantt1.NextTasks[1] = 2;
				gantt1.NextTasks[2] = 5;
				gantt1.NextTasks[3] = 4;
				gantt1.NextTasks[4] = 6;

				gantt1.VertAxis = VerticalAxis.Both;
				gantt1.HorizAxis = HorizontalAxis.Both;


				// Características de los ejes del "Chart" base
				BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue+1);
				BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
				BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
				BaseChart.Chart.Axes.Bottom.Labels.DateTimeFormat = "dd/MM/yy";
				BaseChart.Chart.Axes.Bottom.Increment = 15;
				BaseChart.Chart.Axes.Left.Increment = 1;
				BaseChart.Chart.Axes.Left.Visible = true;
				BaseChart.Chart.Axes.Left.Title = null;
				BaseChart.Chart.Axes.Bottom.Title = null;
				BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
				BaseChart.Chart.Axes.Left.Ticks.Visible = false;
				BaseChart.Chart.Axes.Left.Grid.Visible = true;
				BaseChart.Chart.Legend.Visible = false;
				BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
				BaseChart.Chart.Panel.MarginLeft = 13;
				BaseChart.Chart.Panel.MarginRight = 6;
				BaseChart.Chart.Axes.Left.LabelsOnAxis = true;
				BaseChart.Chart.Axes.Left.Ticks = new TicksPen { Width = 2, Visible = true, Color = Color.White, EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };

				// Themes Marks
				Themes.AplicarMarksTheme1(BaseChart);

            }

	}
}
