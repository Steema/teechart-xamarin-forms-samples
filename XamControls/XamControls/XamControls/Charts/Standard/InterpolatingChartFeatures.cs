using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Standard
{
    public class InterpolatingChartFeatures
    {

				private Line line1;
				private Variables.Variables var;
				private ChartView BaseChart;
				private Tools.InterpolatingLine tool_interpolatingLine;
        #if !TEE_STD
				private CursorTool cursor;
        #endif

				private Annotation annotation = new Annotation();

				// Constructor del "LineChart"
				public InterpolatingChartFeatures(ChartView BaseChart)
				{

					// Variables
					line1 = new Line();
					var = new Variables.Variables();
					this.BaseChart = BaseChart;
					tool_interpolatingLine = new Tools.InterpolatingLine(BaseChart);

					// -------------------------------------------------------
					// PROPIEDADES DEL "BASECHART"
					// -------------------------------------------------------

					//
					// ADD SERIES
					//

					BaseChart.Chart.Series.Add(line1);
					//BaseChart.Chart.Series.Add(line2);
					//BaseChart.Chart.Series.Add(line3);

					//
					// LEFT AXES
					//

					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue + 100);
					BaseChart.Chart.Axes.Left.Visible = true;
					BaseChart.Chart.Axes.Left.Title.Visible = false;
					BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Left.Increment = 10;
					BaseChart.Chart.Axes.Left.AxisPen.Visible = false;
					BaseChart.Chart.Axes.Left.Ticks.Visible = false;
					BaseChart.Chart.Axes.Left.Grid.Visible = true;

					//
					// BOTTOM AXES
					//

					BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue + 50);
					BaseChart.Chart.Axes.Bottom.Title.Visible = false;
					BaseChart.Chart.Axes.Left.Increment = 10;
					BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
					BaseChart.Chart.Axes.Bottom.Visible = true;
					BaseChart.Chart.Axes.Bottom.Ticks.Visible = true;
					BaseChart.Chart.Axes.Bottom.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.FromArgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };

					//
					// HEADER
					//

					BaseChart.Chart.Header.Text = "Interpolating Line";

					//
					// LEGEND
					//

					BaseChart.Chart.Legend.Visible = false;
					BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;

					//
					// PANEL
					//

					BaseChart.Chart.Panel.MarginLeft = 4;

					//
					// EVENTOS
					//

					BaseChart.Chart.ClickSeries += null;

					// -------------------------------------------------------
					// SERIES
					// -------------------------------------------------------

					//
					// LINE 1
					//

					line1.SeriesColor = var.GetPaletteBasic[0];
					line1.RecalcOptions = RecalcOptions.OnModify;
					line1.Title = "Line1";
					line1.ClickableLine = true;
					line1.DefaultNullValue = 0;
					line1.Color = var.GetPaletteBasic[0];
					line1.SeriesColor = var.GetPaletteBasic[0];
					line1.Visible = true;
					for (int i = 0; i < var.GetValorInterpolLine1.Length; i++) { line1.Add(var.GetValorInterpolLine1[i]); }
					line1.Chart.Zoom.Allow = false;
					line1.Chart.Panning.Allow = ScrollModes.None;
					line1.Pointer.Visible = true;
					line1.VertAxis = VerticalAxis.Both;
					line1.HorizAxis = HorizontalAxis.Both;

					//
					// MARKS
					//

					Themes.AplicarMarksTheme1(BaseChart);
            #if !TEE_STD
					AddCursorTool();
            #endif

                }
#if !TEE_STD
				private void AddCursorTool()
				{

					// Use of the Cursor Tool            
					cursor = new CursorTool(BaseChart.Chart.chart);
					cursor.SnapChange += Cursor_SnapChange;
					cursor.CursorClickTolerance = 1000;
					cursor.Style = CursorToolStyles.Vertical;
					cursor.Pen.Color = Color.Blue;
					cursor.Snap = true;
					cursor.Series = BaseChart.Chart.Series[0];
					cursor.FollowMouse = false;
					//cursor.FastCursor = true;            
					// In the case to Active the CursorTool Panning ScrollMode has to be set to None            
					//tChart1.Panning.Allow = ScrollModes.None;            
					cursor.Active = true;
					//cursor.Change += Cursor_Change;

				}

				public void RemCursorTool()
				{

					// Use of the Cursor Tool            
					annotation = null;
					BaseChart.Chart.Header.Text = "";
					BaseChart.Chart.Tools.Remove(cursor);

				}

				public void Cursor_SnapChange(object sender, CursorChangeEventArgs e)
				{
					if (e.SnapPoint != -1)
					{
						//BaseChart.Chart.Header.Text = "Snap Point : " + e.SnapPoint.ToString();
						BaseChart.Chart.Header.Text = "Point -> X: " + e.XValue + " Y: " + annotation.Text;
						annotation.Text = BaseChart.Chart.Series[0].YValues[e.SnapPoint].ToString();
						annotation.Left = e.x - (annotation.Shape.Width / 2); annotation.Top = BaseChart.Chart.Series[0].CalcYPos(e.SnapPoint);
					}
				}
#endif
		
	}
}
