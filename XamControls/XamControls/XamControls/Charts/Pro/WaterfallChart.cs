using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamControls.Charts.Pro
{
    public class WaterfallChart
    {
#if !TEE_STD
        private Waterfall waterfall;
        private Variables.Variables var;

        public WaterfallChart(ChartView BaseChart)
        {

            waterfall = new Waterfall();
            var = new Variables.Variables();

            waterfall.FillSampleValues();
            waterfall.StartColor = var.GetPaletteBasic[0].AddLuminosity(0.3);
            waterfall.MidColor = var.GetPaletteBasic[0];
            waterfall.EndColor = var.GetPaletteBasic[0].AddLuminosity(-0.3);

			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Bottom.Visible = true;
            BaseChart.Chart.Panel.MarginLeft = 3;

			BaseChart.Chart.Axes.Left.Automatic = true;
            BaseChart.Chart.Axes.Left.Increment = 1;
            BaseChart.Chart.Axes.Bottom.Automatic = true;
            BaseChart.Chart.Axes.Left.Grid.Visible = true;

            BaseChart.Chart.Title.Text = "Waterfall series";
            BaseChart.Chart.Legend.Visible = false;

            BaseChart.Chart.Series.Add(waterfall);

        }
#endif
    }
}
