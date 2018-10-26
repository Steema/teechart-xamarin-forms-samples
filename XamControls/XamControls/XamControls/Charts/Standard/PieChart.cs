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
    public class PieChart
    {

				private Pie pie1;
				private Variables.Variables var;
				private ChartView BaseChart;
				private DataPointSelection tool_dataPointSelect;

				public PieChart(ChartView BaseChart)
				{

						pie1 = new Pie();
						var = new Variables.Variables();
						this.BaseChart = BaseChart;
						tool_dataPointSelect = new DataPointSelection(BaseChart);

						BaseChart.Chart.Header.Text = "Percentage of animals in the zoo (%)";
						BaseChart.Chart.Series.Add(pie1);
						BaseChart.Chart.Legend.Visible = true;

						pie1.SeriesColor = var.GetPaletteBasic[0];
						pie1.Chart.Zoom.Allow = false;
						pie1.Chart.Panning.Allow = ScrollModes.None;

						pie1.AutoCircleResize = true;
						pie1.RecalcOptions = RecalcOptions.OnModify;
						pie1.DefaultNullValue = 0;
						pie1.Circled = true;
						pie1.AutoPenColor = false;
						pie1.DarkPen = false;
						pie1.Pen.Width = 3;
						pie1.Pen.Style = DashStyle.Solid;
						pie1.Pen.Visible = true;
						pie1.Pen.Color = Color.White;
						pie1.VertAxis = VerticalAxis.Both;
						pie1.HorizAxis = HorizontalAxis.Both;

						pie1.CustomXRadius = BaseChart.Chart.Axes.Bottom.MaxXValue;
						for (int i = 0; i < var.GetValorPie1.Length; i++)
						{
							pie1.Add(var.GetValorPie1[i], var.GetPaletteBasic[i]);
						}

						pie1.Title = "pieAnimals";

						pie1.RotationAngle = 20;

						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
						BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinYValue, BaseChart.Chart.Axes.Bottom.MaxXValue);

						BaseChart.Chart.Axes.Bottom.Increment = 5;
						BaseChart.Chart.Axes.Left.Increment = 5;

						BaseChart.Chart.Axes.Left.Visible = true;
						BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
						BaseChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.FromRgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
						BaseChart.Chart.Axes.Bottom.Visible = true;

						BaseChart.Chart.Axes.Left.Title.Angle = 90;
						BaseChart.Chart.Axes.Left.Grid.Visible = false;
						BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
						BaseChart.Chart.Legend.LegendStyle = LegendStyles.Values;
						BaseChart.Chart.Legend.Alignment = LegendAlignments.Bottom;
						BaseChart.Chart.Legend.AutoSize = true;
						BaseChart.Chart.Legend.ResizeChart = true;
						BaseChart.Chart.Legend.TextAlign = TextAlignment.Center;
						BaseChart.Chart.Legend.Font.Size = 13;

						BaseChart.Chart.Legend.Symbol.Position = LegendSymbolPosition.Right;

						// Themes Marks
						Themes.AplicarMarksTheme1(BaseChart);

						pie1.Marks.Pen.Visible = false;
						pie1.Marks.FollowSeriesColor = false;
						pie1.Marks.Style = MarksStyles.Percent;
						pie1.AutoCircleResize = false;
						pie1.Marks.Brush.Transparency = 100;
						pie1.MarksPie.VertCenter = true;
						pie1.Marks.Transparent = true;
						pie1.Marks.Frame.Transparency = 100;
						BaseChart.Chart.Series[0].Marks.Font.Size = 18;
						pie1.MarksPie.InsideSlice = true;
						BaseChart.Chart.Panel.MarginLeft = 5;
						pie1.MarksPie.LegSize = 20;
						pie1.MarksPie.VertCenter = true;
						
						BaseChart.Chart.ClickSeries += tool_dataPointSelect.PieChart_ClickSeries;
        }

				// Recupera los colores originales de las barras <<<< NO SIRVE >>>> // RESIDUAL
				private void ClearStats()
				{

						for (int i = 0; i < BaseChart.Chart.Series.Count; i++)
						{

							for (int s = 0; s < BaseChart.Chart.Series[i].Count; s++)
							{

								BaseChart.Chart.Series[i][s].Color = var.GetPaletteBasic[i];

							}

						}

				}

				// Permite eliminar los eventos del Chart
				public void RemoveEvent()
				{

						BaseChart.Chart.ClickSeries -= tool_dataPointSelect.PieChart_ClickSeries;

				}

		}

}
