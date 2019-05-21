using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Pro
{
    public class VolumeChart : SeriesModel
    {
#if !TEE_STD
        private Volume volume;
        private Variables.Variables var;
        private ChartView BaseChart;

        public VolumeChart(ChartView BaseChart)
        {

            volume = new Volume();
            var = new Variables.Variables();
            this.BaseChart = BaseChart;

            volume.FillSampleValues(8);
            volume.Color = var.GetPaletteBasic[0];
            volume.LinePen.Width = 3;
            volume.Marks.Visible = true;
            volume.Marks.Color = var.GetPaletteBasic[0];
            volume.Marks.TailStyle = MarksTail.None;

            Themes.AplicarTheme(BaseChart);
            Themes.AplicarMarksTheme1(BaseChart);

            BaseChart.Chart.Legend.Visible = false;
            BaseChart.Chart.Axes.Left.MinorTicks.Transparency = 100;
            BaseChart.Chart.Axes.Left.Visible = false;
            BaseChart.Chart.Axes.Left.AxisPen.Visible = false;
            BaseChart.Chart.Axes.Left.Grid.Visible = false;
            BaseChart.Chart.Axes.Left.Labels.Visible = true;
            BaseChart.Chart.Title.Text = "Volume series";
            BaseChart.Chart.Axes.Left.Automatic = true;
            BaseChart.Chart.Axes.Left.Increment = 10;
            BaseChart.Chart.Axes.Bottom.Automatic = true;
            BaseChart.Chart.Axes.Bottom.AxisPen.Visible = true;
            BaseChart.Chart.Axes.Bottom.Visible = true;
            BaseChart.Chart.Series.Add(volume);

            base.IsRepainted = false;

            BaseChart.Chart.AfterDraw += Chart_AfterDraw;

        }

        private void Chart_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {

            base.MaxValueAxisLeft = 10;

            base.OnAfterDraw(sender, g);

        }
#endif
    }
}
