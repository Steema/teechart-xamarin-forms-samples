using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class ExponentialTrendProFunctionChart : SeriesModel
    {

				private FastLine flineSource;
				private FastLine flineExpTrend;
				private ExpTrendFunction expTrendFunction;
				private FastLine flineTrend;
				private TrendFunction trendFunction;
				private Variables.Variables var;

				public ExponentialTrendProFunctionChart(ChartView BaseChart)
				{

						flineSource = new FastLine();
						flineExpTrend = new FastLine();
						expTrendFunction = new ExpTrendFunction(); 
						flineTrend = new FastLine();
						trendFunction = new TrendFunction();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Exponential Trend";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.Increment = 50;

						FillSampleValues(flineSource, 50, 800);
						flineSource.Title = "Data Source";
						flineSource.LinePen.Width = 3;
						flineSource.Color = var.GetPaletteBasic[0];

						flineExpTrend.DataSource = flineSource;
						flineExpTrend.Function = expTrendFunction;
						flineExpTrend.LinePen.Width = 3;
						flineExpTrend.Color = var.GetPaletteBasic[1];
						flineExpTrend.Title = "Exp. Trend";

						expTrendFunction.TrendStyle = TrendStyles.Exponential;
						trendFunction.TrendStyle = TrendStyles.Normal;

						flineTrend.DataSource = flineSource;
						flineTrend.Function = trendFunction;
						flineTrend.LinePen.Width = 3;
						flineTrend.Color = var.GetPaletteBasic[2];
						flineTrend.Title = "Trend";

						BaseChart.Chart.Series.Add(flineSource);
						BaseChart.Chart.Series.Add(flineTrend);
						BaseChart.Chart.Series.Add(flineExpTrend);

						((((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).Parent as TabbedPage).Title = "Exp. Trend";

				}

    }
}
