using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;

namespace XamControls.Charts.Pro
{
    public class ArrowChart
    {

	    private Arrow arrow1;
	    private Variables.Variables var;
	    private ChartView BaseChart;

	    public ArrowChart(ChartView BaseChart)
	    {

		    // Variables
		    arrow1 = new Arrow();
		    var = new Variables.Variables();
		    this.BaseChart = BaseChart;

		    // Modificación del "Chart" base
		    BaseChart.Chart.ClickSeries += null;
		    BaseChart.Chart.Legend.Visible = false;
		    BaseChart.Chart.Panning.Allow = ScrollModes.None;
		    BaseChart.Chart.Panning.Active = false;
		    BaseChart.Chart.Zoom.Active = false;
		    BaseChart.Chart.Zoom.Zoomed = false;
		    BaseChart.Chart.Zoom.Allow = false;
		    BaseChart.Chart.Header.Text = "A lot of Arrows";
		    BaseChart.Chart.Axes.Left.Visible = true;
		    BaseChart.Chart.Axes.Bottom.Visible = true;
		    BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
		    BaseChart.Chart.Series.Add(arrow1);

		    for (int i = 0; i < var.GetValorArrow1X.Length; i++) { arrow1.Add(var.GetValorArrow1X[i], var.GetValorArrow1Y[i], var.GetValorArrow1endX[i], var.GetValorArrow1endY[i]); }


		    // Propiedades de la "line1"

		    arrow1.LinePen.Width = 6;
		    arrow1.LinePen.Color = var.GetPaletteBasic[0];

		    arrow1.Pointer.Color = var.GetPaletteBasic[0];
		    arrow1.Pointer.InflateMargins = true;
		    arrow1.Pointer.Visible = true;
		    arrow1.Pointer.HorizSize = 11;
		    arrow1.Pointer.VertSize = 11;
		    arrow1.Pointer.Pen.EndCap = PenLineCap.Round;
		    arrow1.Pointer.Pen.Color = Color.White;
		    arrow1.Pointer.Pen.Width = 5;
		    arrow1.Pointer.Style = PointerStyles.Sphere;

		    arrow1.SeriesColor = var.GetPaletteBasic[0];
		    arrow1.ClickTolerance = 40;
		    arrow1.RecalcOptions = RecalcOptions.OnModify;
		    arrow1.Title = "Births";
		    arrow1.DefaultNullValue = 0;
		    arrow1.VertAxis = VerticalAxis.Both;
		    arrow1.HorizAxis = HorizontalAxis.Both;

            // Características de los ejes del "Chart" base
            BaseChart.Chart.Axes.Bottom.Automatic = true;
		    BaseChart.Chart.Axes.Left.SetMinMax(0, BaseChart.Chart.Axes.Left.MaxYValue + 50);
		    BaseChart.Chart.Axes.Bottom.SetMinMax(0, BaseChart.Chart.Axes.Bottom.MaxXValue);
		    BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
		    BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
		    BaseChart.Chart.Axes.Bottom.Increment = 1;
		    BaseChart.Chart.Axes.Left.Increment = 100;
		    BaseChart.Chart.Axes.Left.Visible = true;
		    BaseChart.Chart.Axes.Left.Title = null;
		    BaseChart.Chart.Axes.Bottom.Title = null;
		    BaseChart.Chart.Axes.Left.AxisPen.Visible = false;
		    BaseChart.Chart.Axes.Left.Ticks.Visible = false;
		    BaseChart.Chart.Axes.Left.Grid.Visible = true;
		    BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
		    BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
		    BaseChart.Chart.Panel.MarginLeft = 5;
		    BaseChart.Chart.Axes.Bottom.AxisPen.Visible = true;
		    BaseChart.Chart.Axes.Bottom.Visible = true;
		    BaseChart.Chart.Axes.Left.Increment = 100;

            // Themes Marks
            arrow1.Marks.AutoSize = true;
            arrow1.Marks.Font.Size = 15;

	    }

	}
}
