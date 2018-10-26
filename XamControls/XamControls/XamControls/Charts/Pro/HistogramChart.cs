using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Styles;
using XamControls.Tools;
using XamControls.Variables;

namespace XamControls.Charts.Pro
{
    public class HistogramChart
    {

		private Histogram histogram;
		private Variables.Variables var;
		private Tools.DataPointSelection tool_dataPointSelection;
        private ChartView BaseChart;

		public HistogramChart(ChartView BaseChart)
		{

			histogram = new Histogram();
			var = new Variables.Variables();
			tool_dataPointSelection = new DataPointSelection(BaseChart);
            this.BaseChart = BaseChart;

            BaseChart.Chart.Title.Text = "Histogram";
						
			for(int i = 0; i < var.GetValorsHistogram.Length/2; i++)
			{

				histogram.Add(var.GetValorsHistogram[i, 0], var.GetValorsHistogram[i, 1], var.GetPaletteBasic[0]);

			}

			BaseChart.Chart.Series.Add(histogram);
			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Bottom.Visible = true;
			BaseChart.Chart.Axes.Left.SetMinMax(0, BaseChart.Chart.Axes.Left.MaxYValue + 5);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);

			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Left.Increment = 5;
            BaseChart.Chart.Axes.Left.Grid.Visible = true;
			BaseChart.Chart.Legend.Visible = false;

			Themes.AplicarMarksTheme1(BaseChart);

			histogram.Marks.TailParams.Align = TailAlignment.BottomCenter;
			histogram.Marks.BackColor = var.GetPaletteBasic[0].AddLuminosity(-0.2);
			histogram.Marks.Width -= 15;
			histogram.Color = var.GetPaletteBasic[0];
			histogram.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.3);
			histogram.LinesPen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.3);

			BaseChart.Chart.ClickSeries += tool_dataPointSelection.HistoSeries_Click;
			histogram.GetSeriesMark += tool_dataPointSelection.SerieHistogram_GetSeriesMark;

		}

        // Permite eliminar el evento
        public void RemoveEvent()
        {

            BaseChart.Chart.ClickSeries -= tool_dataPointSelection.HistoSeries_Click;
            histogram.GetSeriesMark -= tool_dataPointSelection.SerieHistogram_GetSeriesMark;

        }

    }
}
