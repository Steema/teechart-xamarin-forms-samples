using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Pro
{
    public class FunnelChart
    {

				private Funnel funnel;
				private Variables.Variables var;

				public FunnelChart(ChartView BaseChart)
				{

						funnel = new Funnel();
						var = new Variables.Variables();

						for(int i = 0; i < var.GetValorFunnelLabels.Length; i++)
						{

								funnel.Add(var.GetValorsFunnel[i, 0], var.GetValorsFunnel[i, 1], var.GetValorFunnelLabels[i], var.GetPaletteBasic[0]);

						}
						funnel.Marks.Visible = true;
						funnel.Marks.TailStyle = MarksTail.None;
						funnel.Marks.Color = Xamarin.Forms.Color.White;
						funnel.Marks.Font.Color = Xamarin.Forms.Color.Black;
						funnel.Marks.Font.Size = 14;

						funnel.AboveColor = var.GetPaletteBasic[2];
						funnel.WithinColor = var.GetPaletteBasic[1];
						funnel.BelowColor = var.GetPaletteBasic[0];
						funnel.DifferenceLimit = 50;

						BaseChart.Chart.Series.Add(funnel);

						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
						BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);

						BaseChart.Chart.Axes.Left.Visible = false;
						BaseChart.Chart.Axes.Bottom.Visible = false;

						BaseChart.Chart.Title.Text = "Market quota";

						BaseChart.Chart.Legend.LegendStyle = LegendStyles.Values;
						BaseChart.Chart.Legend.TextAlign = TextAlignment.Start;
						BaseChart.Chart.Legend.TextStyle = LegendTextStyles.Plain;

				}

    }
}
