using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using XamControls.Variables;
using Steema.TeeChart.Tools;
using XamControls.Styles;
using System.Drawing;
using XamControls.Tools;

namespace XamControls.Charts.Standard
{
    public class LineChart : SeriesModel
    {

		private Line line1;
		private Line line2;
		private Variables.Variables var;
		private ChartView BaseChart;
		private DataPointSelection tool_dataPointSelect;

		// Constructor del "LineChart"
		public LineChart(ChartView BaseChart)
		{
				// Variables
				line1 = new Line();
				line2 = new Line();
				var = new Variables.Variables();
				this.BaseChart = BaseChart;
				tool_dataPointSelect = new DataPointSelection(BaseChart);

                // Modificación del "Chart" base
                BaseChart.Chart.ClickSeries += null;
                BaseChart.Chart.BeforeDraw += Chart_BeforeDraw;
				BaseChart.Chart.Legend.Visible = true;
				BaseChart.Chart.Header.Text = "Deaths and Births in Spain";
				BaseChart.Chart.Series.Add(line1);
				BaseChart.Chart.Series.Add(line2);	

				line1.Add(var.GetValorLineX, var.GetValorLine1, true);
				line2.Add(var.GetValorLineX, var.GetValorLine2, true);

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
				line1.ClickTolerance = 30;
				line1.RecalcOptions = RecalcOptions.OnModify;
				line1.Title = "Births";
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
				line2.ClickTolerance = 30;
				line2.RecalcOptions = RecalcOptions.OnModify;
				line2.Title = "Deaths";
				line2.VertAxis = VerticalAxis.Both;
				line2.HorizAxis = HorizontalAxis.Both;

				// Características de los ejes del "Chart" base
				BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 10, BaseChart.Chart.Axes.Left.MaxYValue + 10);
				BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
				BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0K";
				BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
				BaseChart.Chart.Axes.Bottom.Increment = 1;
				BaseChart.Chart.Axes.Left.Increment = 10;
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
				BaseChart.Chart.Series[0].Marks.Font.Size = 18;
				BaseChart.Chart.Series[1].Marks.Font.Size = 18;

                ImplementiOSMarks(BaseChart.Chart);

        }

        private void Chart_BeforeDraw(object sender, Graphics3D g)
        {

            if (BaseChart.Chart.Aspect.View3D)
            {

                line1.Pointer.Visible = false;
                line2.Pointer.Visible = false;

            }
            else
            {

                line1.Pointer.Visible = true;
                line2.Pointer.Visible = true;

            }

        }
    }
}
