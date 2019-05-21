using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class SARProFunctionChart : SeriesModel
    {
#if !TEE_STD
        private Candle candle;
		private Line line;
		private SARFunction sarFunction;
		private Variables.Variables var;

		public SARProFunctionChart(ChartView BaseChart)
		{

			candle = new Candle();
			line = new Line();
			sarFunction = new SARFunction();
			var = new Variables.Variables();

			Themes.CandleGodStyle(candle);

			BaseChart.Chart.Title.Text = "Stop-And-Reversal";
			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Bottom.Automatic = true;

			FillSampleValues(candle, 10);
			candle.Title = "Data Source";

			line.DataSource = candle;
			line.Function = sarFunction;
			line.Title = "SAR";
			line.Color = var.GetPaletteBasic[2];
			line.LinePen.Width = 3;
			line.Pointer.Visible = true;
			line.Marks.Visible = true;

			sarFunction.AccelerationFactor = 0.019999999552965164;
			sarFunction.MaxStep = 0.30000001192092896;

			BaseChart.Chart.Series.Add(candle);
			BaseChart.Chart.Series.Add(line);

			line.Marks.Font.Size = 12;
			line.Marks.TailStyle = MarksTail.None;
            line.Marks.FollowSeriesColor = true;

		}
#endif

    }
}
