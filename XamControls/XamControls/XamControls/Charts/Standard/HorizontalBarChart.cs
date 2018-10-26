using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Xamarin.Forms;
using XamControls.Styles;

namespace XamControls.Charts.Standard
{
    public class HorizontalBarChart
    {

				private HorizBar bar1;
				private Variables.Variables var;
				private ChartView BaseChart;

				public HorizontalBarChart(ChartView BaseChart)
				{
					bar1 = new HorizBar();
					var = new Variables.Variables();
					this.BaseChart = BaseChart;

					BaseChart.Chart.Legend.Visible = true;
					BaseChart.Chart.Header.Text = "Number of Museum Visitors (2008-2011)";
					BaseChart.Chart.Series.Add(bar1);
					//BaseChart.Chart.Series.Add(bar2);

					bar1.Colors = new ColorList { var.GetPaletteBasic[0] };
					bar1.SeriesColor = var.GetPaletteBasic[0];
					bar1.Chart.Zoom.Allow = false;
					bar1.Chart.Panning.Allow = ScrollModes.None;
					bar1.RecalcOptions = RecalcOptions.OnModify;
					bar1.Title = "National Gallery";
					bar1.DefaultNullValue = 0;
					for (int i = 0; i < var.GetValorHorizBar1.Length; i++) { bar1.Add(var.GetValorHorizBar1[i], var.GetValorHorizBarX[i]); }
					bar1.MarksOnBar = true;
					bar1.Marks.Style = MarksStyles.Value;
					bar1.VertAxis = VerticalAxis.Both;
					bar1.HorizAxis = HorizontalAxis.Both;

					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
					BaseChart.Chart.Axes.Left.Title.Visible = false;
					BaseChart.Chart.Axes.Bottom.Title.Text = "Annual Visitors (M)";
					BaseChart.Chart.Axes.Left.Visible = false;
					BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
					BaseChart.Chart.Axes.Bottom.Increment = 1;
					BaseChart.Chart.Axes.Left.Increment = 1;
					BaseChart.Chart.Axes.Bottom.Grid.Visible = true;
					BaseChart.Chart.Legend.Visible = true;
					BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
					BaseChart.Chart.ClickSeries += null;
					BaseChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.White, EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
					BaseChart.Chart.Axes.Left.Visible = true;
					BaseChart.Chart.Axes.Left.Labels.Visible = true;
					BaseChart.Chart.Axes.Bottom.Title.Visible = true;
					BaseChart.Chart.Axes.Left.Labels.Angle = 0;

					BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
					BaseChart.Chart.Axes.Left.Grid.Visible = false;
					BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
					BaseChart.Chart.Panel.MarginLeft = 5;

					// Themes Marks
					Themes.AplicarMarksTheme1(BaseChart);

					BaseChart.Chart.Series[0].Marks.Font.Size = 14;

					bar1.Marks.Pen.Visible = false;
					

					BaseChart.Chart.Series[0].Marks.TextAlign = TextAlignment.Center;
					BaseChart.Chart.Series[0].Marks.AutoSize = true;
					BaseChart.Chart.Series[0].Marks.Color = Color.Transparent;

					BaseChart.Chart.ClickSeries += null;

                }

		}

}
