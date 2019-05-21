using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamControls.Charts.Pro
{
    public class HorizHistogramChart
    {
#if !TEE_STD
        private HorizHistogram horizHistoChart;
        private Variables.Variables var;

        public HorizHistogramChart(ChartView BaseChart)
        {

            horizHistoChart = new HorizHistogram();
            var = new Variables.Variables();

            horizHistoChart.FillSampleValues(17);
            horizHistoChart.Color = var.GetPaletteBasic[0];
            horizHistoChart.Marks.Visible = true;

            BaseChart.Chart.Legend.Visible = false;
            BaseChart.Chart.Axes.Left.MinorTicks.Transparency = 100;
            BaseChart.Chart.Axes.Left.Visible = true;
            BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
            BaseChart.Chart.Axes.Left.Grid.Visible = false;
            BaseChart.Chart.Axes.Left.Labels.Visible = true;
            BaseChart.Chart.Title.Text = "Horiz. Histogram series";
            BaseChart.Chart.Axes.Left.Automatic = true;
            BaseChart.Chart.Axes.Bottom.Automatic = true;
            BaseChart.Chart.Axes.Bottom.AxisPen.Transparency = 0;
            BaseChart.Chart.Axes.Bottom.Visible = true;
            BaseChart.Chart.Series.Add(horizHistoChart);

            BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue + 75);

        }
#endif
    }
}
