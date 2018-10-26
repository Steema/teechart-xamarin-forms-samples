using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;

namespace XamControls.Charts.Standard
{
    public class GradientBarChartFeatures
    {

				private Bar bar1;
				private Bar bar2;
				private Variables.Variables var;
				private ChartView BaseChart;

				public GradientBarChartFeatures(ChartView BaseChart)
				{

					bar1 = new Bar();
					bar2 = new Bar();
					var = new Variables.Variables();
					this.BaseChart = BaseChart;

					BaseChart.Chart.Legend.Visible = true;
					BaseChart.Chart.Header.Text = "Time spent on certain activities";
					BaseChart.Chart.Series.Add(bar1);
					BaseChart.Chart.Series.Add(bar2);

					bar1.Colors = new ColorList { var.GetPaletteBasic[0] };
					bar1.SeriesColor = var.GetPaletteBasic[0];
					bar1.Chart.Zoom.Allow = false;
					bar1.Chart.Panning.Allow = ScrollModes.None;
					bar1.RecalcOptions = RecalcOptions.OnModify;
					bar1.Title = "Man 1";
					bar1.DefaultNullValue = 0;
					for (int i = 0; i < var.GetValorColumn1.Length; i++) { bar1.Add(var.GetValorGradientBar1[i], var.GetValorGradientBarX[i]); }
					bar1.MarksOnBar = true;
					bar1.MarksLocation = MarksLocation.Start;
					bar1.Marks.Style = MarksStyles.Value;
                    bar1.BarWidthPercent = 80;
					bar1.Gradient.Visible = true;
					bar1.Gradient.Direction = GradientDirection.TopBottom;
					bar1.Gradient.StartColor = var.GetPaletteBasic[0].AddLuminosity(-0.25);
					bar1.Gradient.MiddleColor = var.GetPaletteBasic[0];
					bar1.Gradient.EndColor = var.GetPaletteBasic[0].AddLuminosity(0.25);
					bar1.VertAxis = VerticalAxis.Both;
					bar1.HorizAxis = HorizontalAxis.Both;

					bar2.Colors = new ColorList { var.GetPaletteBasic[1] };
					bar2.SeriesColor = var.GetPaletteBasic[1];
					bar2.Chart.Zoom.Allow = false;
					bar2.Chart.Panning.Allow = ScrollModes.None;
					bar2.RecalcOptions = RecalcOptions.OnModify;
					bar2.Title = "Man 2";
					bar2.DefaultNullValue = 0;
					for (int i = 0; i < var.GetValorColumn2.Length; i++) { bar2.Add(var.GetValorGradientBar2[i], var.GetValorGradientBarX[i]); }
					bar2.ZOrder = 0;
					bar2.MarksOnBar = true;
					bar2.Marks.Style = MarksStyles.Value;
					bar2.MarksLocation = MarksLocation.Start;
                    bar2.BarWidthPercent = 80;
					bar2.Gradient.Visible = true;
					bar2.Gradient.Direction = GradientDirection.TopBottom;
					bar2.Gradient.StartColor = var.GetPaletteBasic[1].AddLuminosity(-0.25);
					bar2.Gradient.MiddleColor = var.GetPaletteBasic[1];
					bar2.Gradient.EndColor = var.GetPaletteBasic[1].AddLuminosity(0.25);
					bar2.VertAxis = VerticalAxis.Both;
					bar2.HorizAxis = HorizontalAxis.Both;

					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue + 10);
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
					BaseChart.Chart.Axes.Left.Title = null;
					BaseChart.Chart.Axes.Bottom.Title = null;
					BaseChart.Chart.Axes.Left.Visible = false;
					BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
					BaseChart.Chart.Axes.Left.Increment = 2;
					BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
					//BaseChart.Chart.ClickSeries += Chart_ClickSeries;
					BaseChart.Chart.Axes.Left.Labels.CustomSize = 0;

					// Themes Marks
					Themes.AplicarMarksTheme1(BaseChart);

					BaseChart.Chart.Series[0].Marks.Font.Size = 14;
					BaseChart.Chart.Series[1].Marks.Font.Size = 14;

					bar1.Marks.Pen.Visible = false;
					bar2.Marks.Pen.Visible = false;

					BaseChart.Chart.Series[0].Marks.TextAlign = Xamarin.Forms.TextAlignment.Center;
					BaseChart.Chart.Series[0].Marks.AutoSize = true;
					BaseChart.Chart.Series[0].Marks.Color = Color.Transparent;
					BaseChart.Chart.Series[1].Marks.TextAlign = Xamarin.Forms.TextAlignment.Center;
					BaseChart.Chart.Series[1].Marks.AutoSize = true;
					BaseChart.Chart.Series[1].Marks.Color = Color.Transparent;
					BaseChart.Chart.Panel.MarginLeft = 5;

                }

		}
}
