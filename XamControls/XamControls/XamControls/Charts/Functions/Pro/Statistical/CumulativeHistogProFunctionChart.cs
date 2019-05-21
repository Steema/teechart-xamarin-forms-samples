using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Functions.Pro.Statistical
{
    public class CumulativeHistogProFunctionChart : SeriesModel
    {
#if !TEE_STD
        private Line dataLine;
		private Histogram histogram;
		private HistogramFunction histogramFunction;
		private Variables.Variables var;
        private ChartView BaseChart;

		public CumulativeHistogProFunctionChart(ChartView BaseChart)
		{

            dataLine = new Line();
			histogram = new Histogram();
			histogramFunction = new HistogramFunction();
			var = new Variables.Variables();
            this.BaseChart = BaseChart;

            Themes.AplicarTheme(BaseChart);

            BaseChart.Chart.Axes.Left.Automatic = true;
            BaseChart.Chart.Axes.Bottom.Automatic = true;
            BaseChart.Chart.Axes.Left.MinorTicks.Transparency = 100;
            BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
            BaseChart.Chart.Axes.Left.AxisPen.Transparency = 0;
            BaseChart.Chart.Axes.Bottom.Visible = true;
            BaseChart.Chart.Title.Text = "Cumulative Histogram";

            dataLine.FillSampleValues(120);
            dataLine.Color = var.GetPaletteBasic[1];
            dataLine.LinePen.Width = 2;
            dataLine.HorizAxis = HorizontalAxis.Top;
            dataLine.VertAxis = VerticalAxis.Right;
            dataLine.Title = "Data Source";
            dataLine.Marks.DrawEvery = 4;
                
            histogram.FillSampleValues(10);
            histogram.Title = "Histogram";
            histogram.Color = var.GetPaletteBasic[0];
            histogram.Function = histogramFunction;
            histogram.DataSource = dataLine;

            histogramFunction.Cumulative = true;
            histogramFunction.NumBins = 20;

            histogram.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            histogram.ColorEach = false;
            histogram.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            histogram.LinePen.Transparency = 100;
            histogram.LinesPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            histogram.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            histogram.Marks.Callout.ArrowHeadSize = 8;
            histogram.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            histogram.Marks.Callout.Distance = 0;
            histogram.Marks.Callout.Draw3D = false;
            histogram.Marks.Callout.Length = 10;
            histogram.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            histogram.XValues.DataMember = "X";
            histogram.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            histogram.YValues.DataMember = "Y";
            histogram.Marks.DrawEvery = 2;
            histogram.LinesPen.Transparency = 100;

            BaseChart.Chart.Series.Add(histogram);
            BaseChart.Chart.Series.Add(dataLine);

        }
#endif
    }
}
