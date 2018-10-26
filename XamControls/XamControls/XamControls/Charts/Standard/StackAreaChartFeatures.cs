using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Styles;
using XamControls.Tools;

namespace XamControls.Charts.Standard
{
    public class StackAreaChartFeatures
    {

				private Area area1;
				private Area area2;
				private Variables.Variables var;
				private DataPointSelection tool_dataPointSelect;

				// Constructor
				public StackAreaChartFeatures(ChartView BaseChart)
				{

					// Inicializar variables
					area1 = new Area();
					area2 = new Area();
					var = new Variables.Variables();
					tool_dataPointSelect = new DataPointSelection(BaseChart);

					// Propiedades del "Chart" base
					BaseChart.Chart.Series.Add(area2);
					BaseChart.Chart.Series.Add(area1);
					BaseChart.Chart.Legend.Visible = true;
					BaseChart.Chart.Header.Text = "Mensual sells by two companies";
					BaseChart.Chart.Axes.Bottom.LabelsOnAxis = true;

					// Propiedades de la "area1"
					area1.Title = "Company 1";
					area1.SeriesColor = var.GetPaletteBasic[0];
					area1.Chart.Zoom.Allow = false;
					area1.Chart.Panning.Allow = ScrollModes.None;
					area1.RecalcOptions = RecalcOptions.OnModify;
					area1.DefaultNullValue = 0;
					area1.ClickableLine = true;
					area1.AreaLines.Visible = false;
					area1.LinePen.Width = 5;
					area1.Pointer.Visible = true;
					area1.Pointer.Style = PointerStyles.Nothing;
					area1.Pointer.InflateMargins = false;
					area1.LinePen.Style = DashStyle.Solid;
					area1.LinePen.EndCap = PenLineCap.Flat;
					area1.LinePen.DashCap = PenLineCap.Flat;
					area1.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);
					area1.ClickTolerance = 30;
					area1.ClickPointer += tool_dataPointSelect.PointValue_Click;
					area1.GetSeriesMark += tool_dataPointSelect.Serie_GetSeriesMark;
					for (int i = 0; i < var.GetValorArea1.Length; i++) { area1.Add(var.GetValorArea1[i], var.GetValorAreaX[i]); }
					area1.VertAxis = VerticalAxis.Both;
					area1.HorizAxis = HorizontalAxis.Both;
                    area1.Marks.OnTop = true;

					// Propiedades de la "area2"
					area2.Title = "Company 2";
					area2.SeriesColor = var.GetPaletteBasic[1];
					area2.Chart.Zoom.Allow = false;
					area2.Chart.Panning.Allow = ScrollModes.None;
					area2.RecalcOptions = RecalcOptions.OnModify;
					area2.DefaultNullValue = 0;
					area2.ClickableLine = true;
					area2.ClickTolerance = 30;
					area2.Pointer.Visible = true;
					area2.Pointer.Style = PointerStyles.Nothing;
					area2.LinePen.Style = DashStyle.Solid;
					area2.LinePen.EndCap = PenLineCap.Flat;
					area2.LinePen.DashCap = PenLineCap.Flat;
					area2.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);
					area2.LinePen.Color = var.GetPaletteBasic[1].AddLuminosity(-0.2);
					area2.AreaLines.Visible = false;
					area2.LinePen.Width = 5;
					area2.ClickPointer += tool_dataPointSelect.PointValue_Click;
					area2.GetSeriesMark += tool_dataPointSelect.Serie_GetSeriesMark;
					for (int i = 0; i < var.GetValorArea2.Length; i++) { area2.Add(var.GetValorArea2[i], var.GetValorAreaX[i]); }
					area2.VertAxis = VerticalAxis.Both;
					area2.HorizAxis = HorizontalAxis.Both;
                    area2.Marks.OnTop = true;

					area1.Stacked = CustomStack.Stack;
					area2.Stacked = CustomStack.Stack;
					area1.StackGroup = 1;
					area2.StackGroup = 1;

					// Propieades de los ejes del "Chart" base
					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue + 20);
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
					BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.Labels.TextAlign = Xamarin.Forms.TextAlignment.Start;
					BaseChart.Chart.Axes.Left.Visible = true;
					BaseChart.Chart.Axes.Left.Increment = 20;
					BaseChart.Chart.Axes.Left.Title.Visible = false;
					BaseChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.FromArgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10 };
					BaseChart.Chart.Axes.Left.LabelsOnAxis = true;

					BaseChart.Chart.Axes.Left.Labels.CustomSize = 10;
					BaseChart.Chart.Axes.Bottom.Title.Visible = false;
					BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
					BaseChart.Chart.Axes.Left.Grid.Visible = false;
					BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
					BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
					BaseChart.Chart.Panel.MarginRight = 5;
					BaseChart.Chart.ClickSeries += null;
					BaseChart.Chart.Panel.MarginLeft = 4;

					// Themes Marks
					Themes.AplicarMarksTheme1(BaseChart);
					area1.Marks.Width = 82;
					area2.Marks.Width = 82;
                    //area2.Marks.
                    //area1.Marks.ZPosition = 1;


                }

		}
}
