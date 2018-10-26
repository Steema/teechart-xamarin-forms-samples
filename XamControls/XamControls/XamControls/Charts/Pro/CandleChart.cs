using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Pro
{
    public class CandleChart
    {

		private Candle candle;
		private Variables.Variables var;

		public CandleChart(ChartView BaseChart)
		{

				candle = new Candle();
				var = new Variables.Variables();

				//candle.Style = CandleStyles.CandleStick;
				//candle.CandleWidth = 8;
				BaseChart.Chart.Series.Add(candle);
				BaseChart.Chart.Title.Text = "Stock exchange about two companies";
				BaseChart.Chart.Axes.Left.Visible = true;
				BaseChart.Chart.Axes.Bottom.Visible = true;
				BaseChart.Chart.Axes.Left.AxisPen.Visible = true;

				for (int i = 0; i < var.GetValorCandleTime.Length; i++)
				{

						candle.Add(var.GetValorCandleTime[i], var.GetValorsCandle[i, 0], var.GetValorsCandle[i, 1],
												var.GetValorsCandle[i, 2], var.GetValorsCandle[i, 3]);

				}

				candle.Color = var.GetPaletteBasic[0];

				candle.Style = CandleStyles.CandleStick;
				candle.CandleWidth = 40;

				candle.HighLowPen.Width = 3;
				candle.Pen.Width = 3;
				candle.UpCloseColor = var.GetPaletteBasic[0];
				candle.DownCloseColor = var.GetPaletteBasic[1];

				BaseChart.Chart.Axes.Left.Visible = true;
				BaseChart.Chart.Axes.Bottom.Visible = true;
				BaseChart.Chart.Axes.Visible = true;
				BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 5, BaseChart.Chart.Axes.Left.MaxYValue + 5);
				BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue - 0.5, BaseChart.Chart.Axes.Bottom.MaxXValue + 0.5);
				BaseChart.Chart.Panel.MarginRight = 5;
				BaseChart.Chart.Axes.Bottom.Increment = 1;
				BaseChart.Chart.Axes.Bottom.Grid.Visible = true;
				BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
				BaseChart.Chart.Axes.Left.Ticks.Visible = true;
				BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
				BaseChart.Chart.Axes.Left.MinorTicks.Visible = false;
				BaseChart.Chart.Axes.Left.Increment = 10;
				BaseChart.Chart.Axes.Left.Grid.Visible = true;
				BaseChart.Chart.Legend.Visible = false;

                BaseChart.Chart.Axes.Left.Title.Visible = true;
				BaseChart.Chart.Axes.Left.Title.Text = "Money ($)";
                BaseChart.Chart.Axes.Bottom.Title.Visible = true;
				BaseChart.Chart.Axes.Bottom.Title.Text = "Date";
				BaseChart.Chart.Axes.Left.Title.Font.Size = 15;
				BaseChart.Chart.Axes.Left.Title.Angle = 90;
				BaseChart.Chart.Axes.Bottom.Title.Font.Size = 15;

				BaseChart.Chart.Axes.Bottom.Labels.DateTimeFormat = "dd/MM";

				candle.GetPointerStyle += Candle_GetPointerStyle;

		}

		private void Candle_GetPointerStyle(CustomPoint series, GetPointerStyleEventArgs e)
		{

				if(e.Color == var.GetPaletteBasic[0]) { series.Pointer.Pen.Color = var.GetPaletteBasic[0]; }
				else { series.Pointer.Pen.Color = var.GetPaletteBasic[1]; }

		}

		}
}
