using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Styles;
using static Steema.TeeChart.Axis;

namespace XamControls.Charts.Standard
{
    public class ShapeChart
    {

				private Steema.TeeChart.Styles.Shape shape1;
				private Steema.TeeChart.Styles.Shape shape2;
				private Steema.TeeChart.Styles.Shape shape3;
				private Steema.TeeChart.Styles.Shape shape4;
				private Variables.Variables var;
				private ChartView BaseChart;

				// Constructor del "LineChart"
				public ShapeChart(ChartView BaseChart)
				{
					// Variables
					shape1 = new Steema.TeeChart.Styles.Shape();
					shape2 = new Steema.TeeChart.Styles.Shape();
					shape3 = new Steema.TeeChart.Styles.Shape();
					shape4 = new Steema.TeeChart.Styles.Shape();
					var = new Variables.Variables();
					this.BaseChart = BaseChart;

					// -------------------------------------------------------
					// PROPIEDADES DEL "BASECHART"
					// -------------------------------------------------------

					//
					// ADD SERIES
					//

					BaseChart.Chart.Series.Add(shape4);
					BaseChart.Chart.Series.Add(shape3);
					BaseChart.Chart.Series.Add(shape2);
					BaseChart.Chart.Series.Add(shape1);
					

					//
					// LEFT AXES
					//

					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue+100);
					BaseChart.Chart.Axes.Left.Visible = true;
					BaseChart.Chart.Axes.Left.Title.Visible = false;
					BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Left.Increment = 10;
					BaseChart.Chart.Axes.Left.AxisPen.Visible = false;
					BaseChart.Chart.Axes.Left.Ticks.Visible = true;
					BaseChart.Chart.Axes.Left.Ticks = new TicksPen { Width = 2, Visible = true, Color = Color.FromArgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
					BaseChart.Chart.Axes.Left.Grid.Visible = true;

					//
					// BOTTOM AXES
					//

					BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue+100);
					BaseChart.Chart.Axes.Bottom.Title.Visible = false;
					BaseChart.Chart.Axes.Left.Increment = 10;
					BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
					BaseChart.Chart.Axes.Bottom.Visible = true;
					BaseChart.Chart.Axes.Bottom.Ticks.Visible = true;
					BaseChart.Chart.Axes.Left.Ticks = new TicksPen { Width = 2, Visible = true, Color = Color.FromArgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };

					//
					// HEADER
					//

					BaseChart.Chart.Header.Text = "Some shapes";

					//
					// LEGEND
					//

					BaseChart.Chart.Legend.Visible = true;
					BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
					BaseChart.Chart.Legend.TextSymbolGap = 30;

					//
					// PANEL
					//

					BaseChart.Chart.Panel.MarginLeft = 2;

					//
					// EVENTOS
					//

					BaseChart.Chart.ClickSeries += null;

					// -------------------------------------------------------
					// SERIES
					// -------------------------------------------------------

					//
					// SHAPE 1
					//
			
					shape1.SeriesColor = var.GetPaletteBasic[0];
					shape1.RecalcOptions = RecalcOptions.OnModify;
					shape1.Title = "Diamond";
					shape1.DefaultNullValue = 0;
					shape1.Style = ShapeStyles.Diamond;
					shape1.Color = var.GetPaletteBasic[0];
					shape1.SeriesColor = var.GetPaletteBasic[0];
					shape1.Visible = true;
					for(int i = 0; i < var.GetValorShape1X.Length; i++) { shape1.Add(var.GetValorShape1X[i], var.GetValorShape1Y[i]); }
					shape1.Chart.Zoom.Allow = false;
					shape1.Chart.Panning.Allow = ScrollModes.None;
					shape1.VertAxis = VerticalAxis.Both;
					shape1.HorizAxis = HorizontalAxis.Both;

					//
					// SHAPE 2
					//

					shape2.SeriesColor = var.GetPaletteBasic[1];
					shape2.RecalcOptions = RecalcOptions.OnModify;
					shape2.Title = "Circle";
					shape2.DefaultNullValue = 0;
					shape2.Style = ShapeStyles.Circle;
					shape2.Color = var.GetPaletteBasic[1];
					shape2.SeriesColor = var.GetPaletteBasic[1];
					shape2.Visible = true;
					for (int i = 0; i < var.GetValorShape2X.Length; i++) { shape2.Add(var.GetValorShape2X[i], var.GetValorShape2Y[i]); }
					shape2.Chart.Zoom.Allow = false;
					shape2.Chart.Panning.Allow = ScrollModes.None;
					shape2.VertAxis = VerticalAxis.Both;
					shape2.HorizAxis = HorizontalAxis.Both;

					//
					// SHAPE 3
					//

					shape3.SeriesColor = var.GetPaletteBasic[2];
					shape3.RecalcOptions = RecalcOptions.OnModify;
					shape3.Title = "Star";
					shape3.DefaultNullValue = 0;
					shape3.Style = ShapeStyles.Star;
					shape3.Color = var.GetPaletteBasic[2];
					shape3.SeriesColor = var.GetPaletteBasic[2];
					shape3.Visible = true;
					for (int i = 0; i < var.GetValorShape3X.Length; i++) { shape3.Add(var.GetValorShape3X[i], var.GetValorShape3Y[i]); }
					shape3.Chart.Zoom.Allow = false;
					shape3.Chart.Panning.Allow = ScrollModes.None;
					shape3.VertAxis = VerticalAxis.Both;
					shape3.HorizAxis = HorizontalAxis.Both;

					//
					// SHAPE 4
					//

					shape4.SeriesColor = var.GetPaletteBasic[3];
					shape4.RecalcOptions = RecalcOptions.OnModify;
					shape4.Title = "Cube";
					shape4.DefaultNullValue = 0;
					shape4.Style = ShapeStyles.Cube;
					shape4.Color = var.GetPaletteBasic[3];
					shape4.SeriesColor = var.GetPaletteBasic[3];
					shape4.Visible = true;
					for (int i = 0; i < var.GetValorShape4X.Length; i++) { shape4.Add(var.GetValorShape4X[i], var.GetValorShape4Y[i]); }
					shape4.Chart.Zoom.Allow = false;
					shape4.Chart.Panning.Allow = ScrollModes.None;
					shape4.VertAxis = VerticalAxis.Both;
					shape4.HorizAxis = HorizontalAxis.Both;

					//
					// MARKS
					//

					Themes.AplicarMarksTheme1(BaseChart);

        }

	}
}
