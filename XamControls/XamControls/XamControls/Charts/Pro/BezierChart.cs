using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;
using XamControls.ViewModels.Base;

namespace XamControls.Charts.Pro
{
    public class BezierChart
    {

		private Bezier bezier;
		private Variables.Variables var;

		public BezierChart(ChartView BaseChart)
		{

			bezier = new Bezier();
			var = new Variables.Variables();

			BaseChart.Chart.Title.Text = "Bezier series";

			bezier.FillSampleValues(10);
            

            bezier.LinePen.Visible = true;
            bezier.LinePen.Transparency = 0;
            bezier.LinePen.Width = 2;
            bezier.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.1);
            

            bezier.Smoothed = true;

			BaseChart.Chart.Series.Add(bezier);

			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Bottom.Visible = true;

            BaseChart.Chart.Axes.Left.Increment = 20;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Legend.Visible = false;
			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Bottom.Visible = true;
			BaseChart.Chart.Axes.Bottom.AxisPen.Visible = true;
            BaseChart.Chart.Axes.Left.Grid.Visible = true;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
			BaseChart.Chart.Axes.Bottom.SetMinMax(0, BaseChart.Chart.Axes.Bottom.MaxXValue);

		}

    }
}
