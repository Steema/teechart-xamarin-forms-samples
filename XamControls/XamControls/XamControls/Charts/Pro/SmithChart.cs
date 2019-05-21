using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamControls.Charts.Pro
{
    public class SmithChart
    {
        #if !TEE_STD
		private Smith smith;
		private Variables.Variables var;

		public SmithChart(ChartView BaseChart)
		{

			smith = new Smith();
			var = new Variables.Variables();

			smith.GetHorizAxis = BaseChart.Chart.Axes.Bottom;
			smith.GetVertAxis = BaseChart.Chart.Axes.Left;

			BaseChart.Chart.Title.Text = "Smith series";
			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Bottom.Visible = true;
			BaseChart.Chart.Axes.Left.Labels.Visible = true;
			BaseChart.Chart.Axes.Bottom.Labels.Visible = true;
			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Bottom.Automatic = true;
			BaseChart.Chart.Axes.Left.Increment = 0.5;
            BaseChart.Chart.Axes.Left.Grid.Visible = true;

			smith.GetHorizAxis = BaseChart.Chart.Axes.Bottom;
			smith.GetVertAxis = BaseChart.Chart.Axes.Left;

			smith.FillSampleValues();
			smith.Circled = true;
			smith.Pointer.Visible = true;
			smith.Pointer.Color = var.GetPaletteBasic[0];
			smith.Color = var.GetPaletteBasic[0];
			smith.RLabels = true;
			smith.CLabels = true;
			smith.CLabelsFont.Size = 11;
			smith.RLabelsFont.Size = 11;

			BaseChart.Chart.Series.Add(smith);

		}
#endif
    }
}
