using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Pro
{
    public class ErrorChart
    {

				private Error errorChart;
				private Variables.Variables var;

				public ErrorChart(ChartView BaseChart)
				{

						errorChart = new Error();
						var = new Variables.Variables();
						
						for(int i = 0; i < var.GetValorErrorLabels.Length; i++) { errorChart.Add(var.GetValorsError[i, 0], var.GetValorsError[i, 1], var.GetValorsError[i, 2], var.GetPaletteBasic[i]); }
			
						BaseChart.Chart.Series.Add(errorChart);

						BaseChart.Chart.Axes.Left.Visible = true;
						BaseChart.Chart.Axes.Bottom.Visible = true;

						BaseChart.Chart.Header.Text = "Error";

						BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
						BaseChart.Chart.Axes.Left.Visible = true;
						BaseChart.Chart.Axes.Left.Ticks.Visible = true;
						BaseChart.Chart.Axes.Left.Grid.Visible = true;
						BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
						BaseChart.Chart.Axes.Left.Increment = 20;
						BaseChart.Chart.Axes.Left.Title.Visible = false;

						BaseChart.Chart.Axes.Bottom.Visible = true;
						BaseChart.Chart.Axes.Bottom.AxisPen.Visible = true;
						BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
						BaseChart.Chart.Axes.Bottom.Title.Visible = false;

						errorChart.ErrorWidth = 80;
						errorChart.ErrorPen.Width = 6;
						errorChart.ErrorPen.EndCap = PenLineCap.Square;
						errorChart.ErrorStyle = ErrorStyles.TopBottom;

						BaseChart.Chart.Legend.Visible = false;

						BaseChart.Chart.Axes.Left.SetMinMax(0, BaseChart.Chart.Axes.Left.MaxYValue + 5);
						BaseChart.Chart.Axes.Bottom.SetMinMax(0, BaseChart.Chart.Axes.Bottom.MaxXValue);

				}

    }
}
