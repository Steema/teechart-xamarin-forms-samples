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
    public class CCIProFunctionChart
    {
#if !TEE_STD
        private Candle candle;
				private Line line;
				private CCIFunction cciFunction;
				private Variables.Variables var;
				private Axis leftAxis;

				public CCIProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						line = new Line();
						cciFunction = new CCIFunction();
						var = new Variables.Variables();
						leftAxis = new Axis();

						Themes.CandleGodStyle(candle);

						BaseChart.Chart.Header.Text = "Commodity Channel Index (CCI)";

						BaseChart.Chart.Series.Add(candle);
						BaseChart.Chart.Series.Add(line);

						Themes.DoubleAxisChart(BaseChart);
						Themes.CustomAxisLeft(leftAxis);

						candle.FillSampleValues(15);
						candle.HorizAxis = HorizontalAxis.Bottom;
						candle.VertAxis = VerticalAxis.Left;
						candle.Title = "Data Source";

						line.DataSource = candle;
						line.Function = cciFunction;
						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Custom;
						line.CustomVertAxis = leftAxis;
						line.Title = "CCI";
						line.LinePen.Width = 3;
						line.Color = var.GetPaletteBasic[2];

						cciFunction.Series = candle;
						cciFunction.Period = 4;
						cciFunction.Constant = 0.005;
						cciFunction.PeriodStyle = PeriodStyles.Range;

						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 30, BaseChart.Chart.Axes.Left.MaxYValue + 30);
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Custom.Add(leftAxis);

						leftAxis.Automatic = true;


				}
#endif
    }
}
