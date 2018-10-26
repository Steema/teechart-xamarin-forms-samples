using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using System.Drawing;
using XamControls.Styles;
using Xamarin.Forms;
using System.Linq;
using XamControls.Services.Timer;
using System.Data;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

namespace XamControls.Charts.Standard
{
	public class FLineRealTimeChartFeatures
	{

		private FastLine fastLine1;
		private FastLine fastLine2;
		private Variables.Variables var;
		private ChartView BaseChart;
		private BaseTimer Timer;
		private int tmprandom;
		private int numRepeat;
		private int pointsCreate;

		public FLineRealTimeChartFeatures(ChartView BaseChart)
		{

			fastLine1 = new FastLine();
			fastLine2 = new FastLine();
			var = new Variables.Variables();
			this.BaseChart = BaseChart;
			pointsCreate = 0;

			BaseChart.Chart.Header.Text = "Fast random picture";
			BaseChart.Chart.Series.Add(fastLine1);
			BaseChart.Chart.Series.Add(fastLine2);
			BaseChart.Chart.Legend.Visible = false;

			fastLine1.SeriesColor = var.GetPaletteBasic[0];
			fastLine1.Chart.Zoom.Allow = false;
			fastLine1.Chart.Panning.Allow = ScrollModes.None;

			fastLine1.RecalcOptions = RecalcOptions.OnModify;
			fastLine1.DefaultNullValue = 0;
			fastLine1.AutoRepaint = true;
			fastLine1.VertAxis = VerticalAxis.Both;
			fastLine1.HorizAxis = HorizontalAxis.Both;

			fastLine2.SeriesColor = var.GetPaletteBasic[var.GetPaletteBasic.Length-1];
			fastLine2.Chart.Zoom.Allow = false;
			fastLine2.Chart.Panning.Allow = ScrollModes.None;

			fastLine2.RecalcOptions = RecalcOptions.OnModify;
			fastLine2.DefaultNullValue = 0;
			fastLine2.AutoRepaint = true;
			fastLine2.VertAxis = VerticalAxis.Both;
			fastLine2.HorizAxis = HorizontalAxis.Both;

			Random r = new Random();
			int tmprandom;
			for (int t = 1; t < 1000; t++)
			{

				tmprandom = r.Next(Math.Abs(500 - t)) - (Math.Abs(500 - t) / 2);
				fastLine1.Add(1000 - t + tmprandom);
				fastLine2.Add(t + tmprandom);

			}


			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 100, BaseChart.Chart.Axes.Left.MaxYValue + 100);
			BaseChart.Chart.Axes.Bottom.SetMinMax(0, BaseChart.Chart.Axes.Bottom.MaxXValue + 3);

			BaseChart.Chart.Axes.Bottom.Increment = 5;
			BaseChart.Chart.Axes.Left.Increment = 15;

			BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0K";
			BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
			BaseChart.Chart.Axes.Left.Title.Pen = new ChartPen { Color = Xamarin.Forms.Color.Black, Width = 15 };

			BaseChart.Chart.Axes.Left.Title.Visible = false;
			BaseChart.Chart.Axes.Bottom.Title.Visible = false;

			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Xamarin.Forms.Color.FromRgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
			BaseChart.Chart.Axes.Bottom.Visible = true;

			BaseChart.Chart.Axes.Left.Title.Angle = 90;
			BaseChart.Chart.Axes.Left.Grid.Visible = false;
			BaseChart.Chart.ClickSeries += null;

			BaseChart.Chart.Panel.MarginLeft = 5;
			BaseChart.Chart.AfterDraw += Chart_AfterDraw;

			// Themes Marks
			Themes.AplicarMarksTheme1(BaseChart);

        }

		Random r = new Random();
		int color = 0;
		bool numMaxim = false;
		private void Chart_AfterDraw(object sender, Graphics3D g)
		{

			//Timer = new BaseTimer(100);
			//Timer.StartTimer(new Func<bool>(TimerFunction));

				Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
				{
					if (fastLine1 != null && fastLine2 != null && numMaxim == false)
					{
						fastLine1.Clear();
						fastLine2.Clear();

						for (int t = 0; t < 1000; t++)
						{
							tmprandom = r.Next(Math.Abs(500 - t)) - (Math.Abs(500 - t) / 2);
							fastLine1.Add(1000 - t + tmprandom);
							fastLine2.Add(t + tmprandom);
						}

						fastLine1.Color = var.GetPaletteBasic[color];
						fastLine2.Color = var.GetPaletteBasic[var.GetPaletteBasic.Length - 1 - color];
						color++;
						if (color == 8) { color = 0; }

						pointsCreate += 2000;

						return false;
					}
					else { return true; }


				});
				
				if(pointsCreate < Int32.MaxValue - 2000) { BaseChart.Chart.Header.Text = pointsCreate.ToString() + " points created in " + (Math.Round((double)((pointsCreate / 6.20) / 1000), 0)).ToString() + " seconds"; }
				else { numMaxim = true; BaseChart.Chart.Header.Text = "Finish"; }


				/*
					int tmprandom;
					bool repeat;
					int numRepeat;
					int colorReapeat;
					Random r;
					private bool TimerFunction()
					{

							if (!repeat)
							{

								fastLine1.Clear();

								for (int t = 1; t < 1000; t++)
								{
									tmprandom = r.Next(Math.Abs(500 - t)) - (Math.Abs(500 - t) / 2);
									fastLine1.Add(1000 - t + tmprandom);
								}

								//if(numRepeat % var.GetPaletteBasic.Length == ) { }

								numRepeat++;

								return false;

							}
							else { return true; }

					}
		*/
		}

		public void RemoveEvent()
		{

			BaseChart.Chart.AfterDraw -= Chart_AfterDraw;

		}

	}
}
