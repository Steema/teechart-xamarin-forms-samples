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
    public class BubbleTransparencyChartFeatures
    {

				private Bubble bubble1;
				private ChartView BaseChart;
				private Variables.Variables var;
				private DataPointSelection tool_dataPointSelect;

				public BubbleTransparencyChartFeatures(ChartView BaseChart)
				{

					bubble1 = new Bubble();
					this.BaseChart = BaseChart;
					var = new Variables.Variables();
					tool_dataPointSelect = new DataPointSelection(BaseChart);

					BaseChart.Chart.Header.Text = "Market share study";
					BaseChart.Chart.Series.Add(bubble1);
					BaseChart.Chart.Legend.Visible = false;

					bubble1.SeriesColor = var.GetPaletteBasic[0];
					bubble1.Chart.Zoom.Allow = false;
					bubble1.Chart.Panning.Allow = ScrollModes.None;

					bubble1.RecalcOptions = RecalcOptions.OnModify;
					bubble1.DefaultNullValue = 0;

					bubble1.ClickPointer += tool_dataPointSelect.PointValue_Click;
					bubble1.GetSeriesMark += tool_dataPointSelect.Serie_GetSeriesMark;
					for (int i = 0; i < var.GetValorBubbleTrans1.Length; i++)
					{
						bubble1.Add(var.GetValorBubbleTransX[i], var.GetValorBubbleTrans1[i], var.GetValorBubbleTrans1[i] / 4, var.GetPaletteBasic[i]);
					}

					bubble1.Pointer.Brush.Color = Color.FromArgb(255, 255, 0, 0);
					bubble1.Pointer.InflateMargins = false;
					bubble1.Pointer.Style = PointerStyles.Circle;
					bubble1.Title = "bubble1";

					bubble1.Transparency = 50;
					bubble1.VertAxis = VerticalAxis.Both;
					bubble1.HorizAxis = HorizontalAxis.Both;

					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 5, BaseChart.Chart.Axes.Left.MaxYValue + 5);
					BaseChart.Chart.Axes.Bottom.SetMinMax(0, BaseChart.Chart.Axes.Bottom.MaxXValue + 3);

					BaseChart.Chart.Axes.Bottom.Increment = 5;
					BaseChart.Chart.Axes.Left.Increment = 15;

					BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Left.Title.AutoSize = true;
					BaseChart.Chart.Axes.Left.Title.Font.Size = 14;
					BaseChart.Chart.Axes.Bottom.Title.Font.Size = 14;
					BaseChart.Chart.Axes.Left.Title.Alignment = Xamarin.Forms.TextAlignment.Center;

					BaseChart.Chart.Axes.Left.Visible = true;
					BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
					BaseChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.FromArgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
					BaseChart.Chart.Axes.Bottom.Visible = true;

					BaseChart.Chart.Axes.Left.Title.Angle = 90;
					BaseChart.Chart.Axes.Left.Grid.Visible = false;

					BaseChart.Chart.Axes.Bottom.Title.Text = "Number of products";
					BaseChart.Chart.Axes.Left.Title.Text = "Sales";

					BaseChart.Chart.ClickSeries -= Chart_ClickSeries;

					// Themes Marks
					Themes.AplicarMarksTheme1(BaseChart);

					bubble1.Marks.ArrowLength = (int)bubble1.Pointer.VertSize;
					bubble1.Marks.TextAlign = Xamarin.Forms.TextAlignment.Center;
					bubble1.Marks.Font.Color = Color.Black;
					bubble1.Marks.Font.Size = 19;
					bubble1.Marks.Frame.Width = 85;
					bubble1.Marks.Width = 85;
					bubble1.Marks.Frame.Visible = true;
					bubble1.Marks.Transparent = false;
					bubble1.Marks.Frame.Transparency = 0;
					bubble1.Marks.BackColor = Color.White;
					bubble1.Marks.Pen.Visible = true;
					bubble1.Marks.Pen.Width = 2;
					bubble1.Marks.Pen.Color = Color.Black;
					BaseChart.Chart.Axes.Left.Labels.CustomSize = 0;
					BaseChart.Chart.Panel.MarginLeft = 4;

                }

				// Evento que modifica el color de la barra cuando haces "click"
				public void Chart_ClickSeries(object sender, Series s, int valueIndex, MouseEventArgs e)
				{

					if (BaseChart.Chart.Title.Text == "Percentage of animals in the zoo (%)")
					{

						var Serie = BaseChart.Chart.Series[BaseChart.Chart.Series.IndexOf(s)][valueIndex];
						Pie pie = (Pie)BaseChart.Chart.Series[0];
						for (int i = 0; i < pie.Count; i++) { if (i != valueIndex) { pie.ExplodedSlice[i] = 0; } }
						pie.ExplodedSlice[valueIndex] = 10;

					}

				}

	}
}
