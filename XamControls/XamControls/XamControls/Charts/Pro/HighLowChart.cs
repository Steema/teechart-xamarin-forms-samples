using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Pro
{
    public class HighLowChart
    {

		private HighLow highLow;
		private Variables.Variables var;

		public HighLowChart(ChartView BaseChart)
		{

			highLow = new HighLow();
			var = new Variables.Variables();
			highLow.FillSampleValues(25);
			BaseChart.Chart.Series.Add(highLow);

			highLow.Color = var.GetPaletteBasic[0];

			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Bottom.Visible = true;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Axes.Bottom.AxisPen.Visible = true;
			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Bottom.Visible = true;
            BaseChart.Chart.Axes.Left.Grid.Visible = true;

			BaseChart.Chart.Legend.Visible = false;
			BaseChart.Chart.Title.Text = "HighLow series";

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);

		}

    }
}
