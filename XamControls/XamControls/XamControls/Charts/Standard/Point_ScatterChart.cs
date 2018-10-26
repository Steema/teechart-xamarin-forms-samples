using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using XamControls.Styles;

namespace XamControls.Charts.Standard
{
    public class Point_ScatterChart
    {

				private Points point1;
				private Points point2;
				private Points point3;
				private Points point4;
				private Variables.Variables var;
				private ChartView BaseChart;

				// Constructor del "LineChart"
				public Point_ScatterChart(ChartView BaseChart)
				{
					// Variables
					point1 = new Points();
					point2 = new Points();
					point3 = new Points();
					point4 = new Points();
					var = new Variables.Variables();
					this.BaseChart = BaseChart;

					// Modificación del "Chart" base
					BaseChart.Chart.ClickSeries += null;
					BaseChart.Chart.Legend.Visible = true;
					BaseChart.Chart.Header.Text = "Pointer Series";
					BaseChart.Chart.Series.Add(point1);
					BaseChart.Chart.Series.Add(point2);
					BaseChart.Chart.Series.Add(point3);
					BaseChart.Chart.Series.Add(point4);

					for(int i = 0; i < var.GetValorPointScatter1.Length; i++) {  }
					
					point1.Add(var.GetValorPointScatter1);
					point2.Add(var.GetValorPointScatter2);
					point3.Add(var.GetValorPointScatter3);
					point4.Add(var.GetValorPointScatter4);

					// Propiedades del "point1"

					point1.LinePen.Width = 6;
					point1.LinePen.Color = var.GetPaletteBasic[0];

					point1.Pointer.Color = var.GetPaletteBasic[0];
					point1.Pointer.InflateMargins = true;
					point1.Pointer.Visible = true;
					point1.Pointer.HorizSize = 11;
					point1.Pointer.VertSize = 11;
					point1.Pointer.Pen.EndCap = PenLineCap.Round;
					point1.Pointer.Pen.Color = Color.White;
					point1.Pointer.Pen.Width = 5;
					point1.Pointer.Style = PointerStyles.Sphere;

					point1.SeriesColor = var.GetPaletteBasic[0];
					point1.Chart.Zoom.Allow = false;
					point1.Chart.Panning.Allow = ScrollModes.None;
					point1.RecalcOptions = RecalcOptions.OnModify;
					point1.Title = "Point1";
					point1.DefaultNullValue = 0;
					point1.VertAxis = VerticalAxis.Both;
					point1.HorizAxis = HorizontalAxis.Both;

					// Propiedades del "point2"
					point2.LinePen = new ChartPen { Width = 6, Color = var.GetPaletteBasic[1], };
					point2.Pointer = new SeriesPointer(BaseChart.Chart, point2) { Color = var.GetPaletteBasic[1], InflateMargins = true, HorizSize = 11, VertSize = 11, Pen = new ChartPen { EndCap = PenLineCap.Round, Color = Xamarin.Forms.Color.White, Width = 5 }, Style = PointerStyles.Sphere };
					point2.SeriesColor = var.GetPaletteBasic[1];
					point2.Chart.Zoom.Allow = false;
					point2.Chart.Panning.Allow = ScrollModes.None;
					point2.RecalcOptions = RecalcOptions.OnModify;
					point2.Title = "Point2";
					point2.VertAxis = VerticalAxis.Both;
					point2.HorizAxis = HorizontalAxis.Both;

					// Propiedades del "point3"
					point3.LinePen = new ChartPen { Width = 6, Color = var.GetPaletteBasic[1], };
					point3.Pointer = new SeriesPointer(BaseChart.Chart, point2) { Color = var.GetPaletteBasic[1], InflateMargins = true, HorizSize = 11, VertSize = 11, Pen = new ChartPen { EndCap = PenLineCap.Round, Color = Xamarin.Forms.Color.White, Width = 5 }, Style = PointerStyles.Sphere };
					point3.SeriesColor = var.GetPaletteBasic[2];
					point3.Chart.Zoom.Allow = false;
					point3.Chart.Panning.Allow = ScrollModes.None;
					point3.RecalcOptions = RecalcOptions.OnModify;
					point3.Title = "Point3";
					point3.VertAxis = VerticalAxis.Both;
					point3.HorizAxis = HorizontalAxis.Both;

					// Propiedades del "point4"
					point4.LinePen = new ChartPen { Width = 6, Color = var.GetPaletteBasic[1], };
					point4.Pointer = new SeriesPointer(BaseChart.Chart, point2) { Color = var.GetPaletteBasic[1], InflateMargins = true, HorizSize = 11, VertSize = 11, Pen = new ChartPen { EndCap = PenLineCap.Round, Color = Xamarin.Forms.Color.White, Width = 5 }, Style = PointerStyles.Sphere };
					point4.SeriesColor = var.GetPaletteBasic[3];
					point4.Chart.Zoom.Allow = false;
					point4.Chart.Panning.Allow = ScrollModes.None;
					point4.RecalcOptions = RecalcOptions.OnModify;
					point4.Title = "Point4";
					point4.VertAxis = VerticalAxis.Both;
					point4.HorizAxis = HorizontalAxis.Both;

					// Características de los ejes del "Chart" base
					BaseChart.Chart.Axes.Left.SetMinMax(0, BaseChart.Chart.Axes.Left.MaxYValue + 2);
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
					BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.Increment = 1;
					BaseChart.Chart.Axes.Left.Increment = 3;
					BaseChart.Chart.Axes.Left.Visible = true;
					BaseChart.Chart.Axes.Left.Title = null;
					BaseChart.Chart.Axes.Bottom.Title = null;
					BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
					BaseChart.Chart.Axes.Left.Grid.Visible = true;
					BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
					BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
					BaseChart.Chart.Axes.Left.Ticks.Visible = true;
					BaseChart.Chart.Panel.MarginLeft = 2;

					// Themes Marks
					Themes.AplicarMarksTheme1(BaseChart);
                }

		}
}
