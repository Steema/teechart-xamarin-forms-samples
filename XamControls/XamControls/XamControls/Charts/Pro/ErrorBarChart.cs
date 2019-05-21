using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Styles;
using XamControls.Tools;
using XamControls.Variables;

namespace XamControls.Charts.Pro
{
    public class ErrorBarChart
    {
#if !TEE_STD
        private ErrorBar errorBar;
			private Variables.Variables var;
			private Tools.DataPointSelection tool_dataPointSelection;
			private ChartView BaseChart;

			public ErrorBarChart(ChartView BaseChart)
			{

					errorBar = new ErrorBar();
					var = new Variables.Variables();
					tool_dataPointSelection = new DataPointSelection(BaseChart);
					this.BaseChart = BaseChart;

					BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
					BaseChart.Chart.Axes.Left.Visible = true;
					BaseChart.Chart.Axes.Bottom.Visible = true;

					for (int i = 0; i < var.GetValorsErrorBar.Length / 3; i++)
					{

							errorBar.Add(var.GetValorsErrorBar[i, 0], var.GetValorsErrorBar[i, 1], var.GetValorsErrorBar[i, 2], var.GetPaletteBasic[i]);	

					}

					errorBar.ErrorPen.Width = 2;
					errorBar.ErrorPen.Color = Color.Black;
						
					BaseChart.Chart.Series.Add(errorBar);

					BaseChart.Chart.Header.Text = "Error Bar";

					BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
					BaseChart.Chart.Axes.Left.Visible = true;
                    BaseChart.Chart.Axes.Left.Grid.Visible = true;
					BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;

					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
					BaseChart.Chart.Axes.Bottom.SetMinMax(0, BaseChart.Chart.Axes.Bottom.MaxXValue);
					BaseChart.Chart.Axes.Left.Increment = 50;

					BaseChart.Chart.Legend.Visible = false;

					errorBar.GetBarStyle += ErrorBar_GetBarStyle;
					BaseChart.Chart.ClickSeries += tool_dataPointSelection.ErrorBarSeries_Click;
					errorBar.GetSeriesMark += tool_dataPointSelection.SerieErrorBar_GetSeriesMark;

					errorBar.Marks.Visible = false;
					errorBar.MarksOnBar = true;
					errorBar.MarksLocation = MarksLocation.End;
					errorBar.Marks.TailStyle = MarksTail.None;
					errorBar.Marks.Font.Size = 12;
					errorBar.Marks.Frame.Color = Color.Transparent;
					errorBar.Marks.Pen.Color = Color.Black;
					errorBar.Marks.Color = Color.White;
					errorBar.Marks.Height += 10;
					errorBar.Marks.Shadow.Visible = false;

			}

			private void ErrorBar_GetBarStyle(CustomBar sender, CustomBar.GetBarStyleEventArgs e)
			{

					var bar = sender as CustomBar;
					bar.Pen.Color = var.GetPaletteBasic[e.ValueIndex].AddLuminosity(-0.35);
					(bar as ErrorBar).ErrorPen.Color = var.GetPaletteBasic[e.ValueIndex].AddLuminosity(-0.33);

			}

			// Permite eliminar el evento onClickSeries
			public void RemoveEvent()
			{

					BaseChart.Chart.ClickSeries -= tool_dataPointSelection.ErrorBarSeries_Click;

			}
#endif
	}
}
