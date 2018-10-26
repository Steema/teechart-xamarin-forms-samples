using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Standard
{
    public class Semi_DonutChartFeatures
    {

				private Donut donut1;
				private Variables.Variables var;
				private ChartView BaseChart;
				private Tools.DataPointSelection tool_dataPointSelect;

				public Semi_DonutChartFeatures(ChartView BaseChart)
				{

					donut1 = new Donut();
					var = new Variables.Variables();
					this.BaseChart = BaseChart;
					tool_dataPointSelect = new Tools.DataPointSelection(BaseChart);

					BaseChart.Chart.Header.Text = "How old are the workers";
					BaseChart.Chart.Series.Add(donut1);
					BaseChart.Chart.Legend.Visible = true;

					donut1.SeriesColor = var.GetPaletteBasic[0];
					donut1.Chart.Zoom.Allow = false;
					donut1.Chart.Panning.Allow = ScrollModes.None;

					donut1.AutoCircleResize = true;
					donut1.RecalcOptions = RecalcOptions.OnModify;
					donut1.DefaultNullValue = 0;
					donut1.Circled = true;
					donut1.AutoPenColor = false;
					donut1.DarkPen = false;
					donut1.Pen.Width = 3;
					donut1.Pen.Style = DashStyle.Solid;
					donut1.Pen.Visible = true;
					donut1.Pen.Color = Color.White;
					donut1.AngleSize = 180;
					donut1.VertAxis = VerticalAxis.Both;
					donut1.HorizAxis = HorizontalAxis.Both;

					donut1.CustomXRadius = BaseChart.Chart.Axes.Bottom.MaxXValue;
					for (int i = 0; i < var.GetValorDonut1.Length; i++)
					{
						donut1.Add(var.GetValorDonut1[i], var.GetPaletteBasic[i]);
					}

					donut1.Title = "pieAnimals";

					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinYValue, BaseChart.Chart.Axes.Bottom.MaxXValue);

					BaseChart.Chart.Axes.Bottom.Increment = 5;
					BaseChart.Chart.Axes.Left.Increment = 5;

					BaseChart.Chart.Axes.Left.Visible = true;
					BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
					BaseChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.FromArgb(0, 200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
					BaseChart.Chart.Axes.Bottom.Visible = true;

					BaseChart.Chart.Axes.Left.Title.Angle = 90;
					BaseChart.Chart.Axes.Left.Grid.Visible = false;
					BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
					BaseChart.Chart.Panel.MarginLeft = 5;

					BaseChart.Chart.Legend.LegendStyle = LegendStyles.Values;
					BaseChart.Chart.Legend.Symbol.Position = LegendSymbolPosition.Right;

					BaseChart.Chart.SubHeader.Visible = true;
					BaseChart.Chart.SubHeader.Text = "A";
					BaseChart.Chart.SubHeader.Font.Size = 80;
					BaseChart.Chart.SubHeader.Color = Color.White;
					BaseChart.Chart.SubHeader.Transparency = 100;

					// Themes Marks
					Themes.AplicarMarksTheme1(BaseChart);

					donut1.Marks.Pen.Visible = false;
					donut1.Marks.FollowSeriesColor = false;
					donut1.Marks.Style = MarksStyles.Percent;
					donut1.Marks.Brush.Transparency = 100;
					donut1.MarksPie.VertCenter = true;
					donut1.Marks.Transparent = true;
					donut1.Marks.Frame.Transparency = 100;
					BaseChart.Chart.Series[0].Marks.Font.Size = 18;
					donut1.MarksPie.InsideSlice = true;
                    if (App.ScreenWidth < 600) donut1.Marks.Font.Size = 15;
                    else donut1.Marks.Font.Size = 18;
                    BaseChart.Chart.ClickSeries += tool_dataPointSelect.DonutChart_ClickSeries;

                }

				// Permite eliminar el evento "clickSeries" del Chart
				public void RemoveEvent()
				{

					BaseChart.Chart.ClickSeries -= tool_dataPointSelect.DonutChart_ClickSeries;

				}

	}
}
