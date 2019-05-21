using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Pro
{
    public class PolarBarChart
    {
#if !TEE_STD
        private PolarBar polarBar;
#endif
        private Variables.Variables var;

        public PolarBarChart(ChartView BaseChart)
        {
#if !TEE_STD
            polarBar = new PolarBar();
            var = new Variables.Variables();

            polarBar.FillSampleValues(30);
            polarBar.Color = var.GetPaletteBasic[0];
            polarBar.Marks.Visible = false;
            polarBar.Circled = true;
            polarBar.CloseCircle = true;
            polarBar.Pen.Width = 5;
            polarBar.Pointer.Visible = false;
            polarBar.CircleLabelsInside = false;
            polarBar.CircleLabels = true;

            Themes.AplicarTheme(BaseChart);

            BaseChart.Chart.Title.Text = "Polar Bar series";
            BaseChart.Chart.Legend.Visible = false;
            BaseChart.Chart.Axes.Left.MinorTicks.Transparency = 100;
            BaseChart.Chart.Axes.Left.Visible = false;
            BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
            BaseChart.Chart.Axes.Left.Grid.Visible = true;
            BaseChart.Chart.Axes.Left.Labels.Visible = true;
            BaseChart.Chart.Axes.Left.Automatic = true;
            BaseChart.Chart.Axes.Left.Increment = 10;
            BaseChart.Chart.Axes.Bottom.Increment = 10;
            BaseChart.Chart.Axes.Bottom.Automatic = true;
            BaseChart.Chart.Series.Add(polarBar);

#endif

        }

    }
}
