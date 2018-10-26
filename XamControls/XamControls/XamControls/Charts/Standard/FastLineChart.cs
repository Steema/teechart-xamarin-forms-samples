using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Drawing;
using System.Drawing;
using XamControls.Styles;

namespace XamControls.Charts.Standard
{
    public class FastLineChart
    {

	    private FastLine fastLine1;
	    private FastLine fastLine2;
	    private Variables.Variables var;

	    public FastLineChart(ChartView BaseChart)
	    {

			    fastLine1 = new FastLine();
			    fastLine2 = new FastLine();
			    var = new Variables.Variables();

			    BaseChart.Chart.Header.Text = "Fast random picture";
			    BaseChart.Chart.Series.Add(fastLine1);
			    BaseChart.Chart.Series.Add(fastLine2);
			    BaseChart.Chart.Legend.Visible = false;

			    fastLine1.SeriesColor = var.GetPaletteBasic[0];
			    fastLine1.Chart.Zoom.Allow = false;
			    fastLine1.Chart.Panning.Allow = ScrollModes.None;

			    fastLine1.RecalcOptions = RecalcOptions.OnModify;
			    fastLine1.DefaultNullValue = 0;
			    fastLine1.AutoRepaint = true;
			    fastLine1.VertAxis = VerticalAxis.Both;
			    fastLine1.HorizAxis = HorizontalAxis.Both;
			    /*for (int i = 0; i < var.GetValorBubble1.Length; i++)
			    {
				    fastLine1.Add(var.GetValorBubbleX[i], var.GetValorBubble1[i], var.GetPaletteBasic[i]);
			    }*/

			    fastLine2.Title = "fastLine2";

			    fastLine2.SeriesColor = var.GetPaletteBasic[1];
			    fastLine2.Chart.Zoom.Allow = false;
			    fastLine2.Chart.Panning.Allow = ScrollModes.None;
			    fastLine2.AutoRepaint = true;
			    fastLine2.RecalcOptions = RecalcOptions.OnModify;
			    fastLine2.DefaultNullValue = 0;
			    Random r = new Random();
			    int tmprandom;
			    for (int t = 1; t < 1000; t++)
			    {
				    tmprandom = r.Next(Math.Abs(500 - t)) - (Math.Abs(500 - t) / 2);
				    fastLine1.Add(1000 - t + tmprandom);
				    fastLine2.Add(t + tmprandom);
			    }
			    fastLine2.VertAxis = VerticalAxis.Both;
			    fastLine2.HorizAxis = HorizontalAxis.Both;
			    fastLine2.Title = "fastLine2";

			    BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 5, BaseChart.Chart.Axes.Left.MaxYValue + 5);
			    BaseChart.Chart.Axes.Bottom.SetMinMax(0, BaseChart.Chart.Axes.Bottom.MaxXValue + 3);

			    BaseChart.Chart.Axes.Bottom.Increment = 5;
			    BaseChart.Chart.Axes.Left.Increment = 15;

			    BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0K";
			    BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
			    BaseChart.Chart.Axes.Left.Title.Pen = new ChartPen { Color = Color.Black, Width = 15 };

			    BaseChart.Chart.Axes.Left.Title.Visible = false;
			    BaseChart.Chart.Axes.Bottom.Title.Visible = false;

			    BaseChart.Chart.Axes.Left.Visible = true;
			    BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			    BaseChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.FromArgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
			    BaseChart.Chart.Axes.Bottom.Visible = true;

			    BaseChart.Chart.Axes.Left.Title.Angle = 90;
			    BaseChart.Chart.Axes.Left.Grid.Visible = false;
			    BaseChart.Chart.ClickSeries += null;

			    BaseChart.Chart.Panel.MarginLeft = 5;

                // Themes Marks
                Themes.AplicarMarksTheme1(BaseChart);

        }

	}
}
