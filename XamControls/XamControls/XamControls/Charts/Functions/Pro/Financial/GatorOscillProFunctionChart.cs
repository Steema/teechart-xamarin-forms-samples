using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class GatorOscillProFunctionChart : SeriesModel
    {
#if !TEE_STD
        private Candle candle;
		private Line line;
		private AlligatorFunction alligator;
		private Volume volume;
		private GatorFunction gator;
		private Variables.Variables var;
		private Axis leftAxis;

#endif

		public GatorOscillProFunctionChart(ChartView BaseChart)
		{
#if !TEE_STD
            candle = new Candle();
			line = new Line();
			alligator = new AlligatorFunction();
			volume = new Volume();
			gator = new GatorFunction();
			var = new Variables.Variables();
			leftAxis = new Axis();

			BaseChart.Chart.Title.Text = "Gator Oscillator";

			Themes.CandleGodStyle(candle);
			Themes.DoubleAxisChart(BaseChart);
			Themes.CustomAxisLeft(leftAxis);

			FillSampleValues(candle, 60, 200);

			candle.Title = "Data Source";
			candle.HorizAxis = HorizontalAxis.Bottom;
			candle.VertAxis = VerticalAxis.Left;
            candle.Marks.Transparency = 100;

			line.Title = "Alligator";
			line.DataSource = candle;
			line.Function = alligator;
			line.HorizAxis = HorizontalAxis.Bottom;
			line.VertAxis = VerticalAxis.Left;
			line.LinePen.Width = 2;
            line.Marks.DrawEvery = 8;

			FillSampleValues(volume, 15);
			volume.Title = "Gator";
			volume.UseOrigin = true;
			volume.DataSource = candle;
			volume.Function = gator;
			volume.HorizAxis = HorizontalAxis.Bottom;
			volume.VertAxis = VerticalAxis.Custom;
			volume.CustomVertAxis = leftAxis;
			volume.LinePen.Width = 2;
            volume.Marks.DrawEvery = 5;

			alligator.LipsPen.Color = var.GetPaletteBasic[2];
			alligator.LipsPen.Width = 3;
			alligator.TeethPen.Color = var.GetPaletteBasic[3];
			alligator.TeethPen.Width = 3;
            alligator.Lips.Marks.DrawEvery = 5;
            alligator.Teeth.Marks.DrawEvery = 5;

            gator.Bottom.Marks.Transparency = 100;

            leftAxis.Automatic = true;
			leftAxis.Increment = 1;
			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Custom.Add(leftAxis);
			BaseChart.Chart.Axes.Bottom.Automatic = true;
			BaseChart.Chart.Legend.Visible = false;
			BaseChart.Chart.Axes.Left.Increment = 10;
						
			BaseChart.Chart.Series.Add(candle);
			BaseChart.Chart.Series.Add(line);
			BaseChart.Chart.Series.Add(volume);
#endif

        }

    }
}
