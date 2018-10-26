using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using System.Drawing;
using XamControls.Styles;

namespace XamControls.Charts.Standard
{
    public class ZoomPanningChartFeatures
    {

				private Line line1;
				private Variables.Variables var;
				private ChartView BaseChart;
				private Tools.DataPointSelection tool_dataPointSelect;

				public ZoomPanningChartFeatures(ChartView BaseChart)
				{

						// Variables
						line1 = new Line();
						var = new Variables.Variables();
						this.BaseChart = BaseChart;
						tool_dataPointSelect = new Tools.DataPointSelection(BaseChart);

						// Modificación del "Chart" base
						BaseChart.Chart.ClickSeries += null;
						BaseChart.Chart.Legend.Visible = true;
						BaseChart.Chart.Panning.Allow = ScrollModes.Both;
						BaseChart.Chart.Panning.Active = true;
						BaseChart.Chart.Panning.Chart = BaseChart.Chart;
						BaseChart.Chart.Zoom.Active = true;
						BaseChart.Chart.Zoom.Zoomed = true;
						BaseChart.Chart.Zoom.Allow = true;
						BaseChart.Chart.Zoom.Chart = BaseChart.Chart;
						BaseChart.Chart.Header.Text = "Zoom and Panning a Chart";
						BaseChart.Chart.Series.Add(line1);

						line1.FillSampleValues(30);

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
						line1.ClickTolerance = 40;
						line1.RecalcOptions = RecalcOptions.OnModify;
						line1.Title = "Births";
						line1.DefaultNullValue = 0;
						line1.ClickPointer += tool_dataPointSelect.PointValue_Click;
						line1.GetSeriesMark += tool_dataPointSelect.Serie_GetSeriesMark;
						line1.VertAxis = VerticalAxis.Both;
						line1.HorizAxis = HorizontalAxis.Both;

						// Características de los ejes del "Chart" base
						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 50, BaseChart.Chart.Axes.Left.MaxYValue + 50);
						BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue + 20, BaseChart.Chart.Axes.Bottom.MaxXValue - 20);
						BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
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
						BaseChart.Chart.Legend.Visible = false;
						BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
						BaseChart.Chart.Panel.MarginLeft = 5;

						// Themes Marks
						Themes.AplicarMarksTheme1(BaseChart);
						BaseChart.Chart.Series[0].Marks.Font.Size = 18;

                }
		}
}
