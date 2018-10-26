using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Drawing;
using System.Drawing;
using XamControls.Styles;
using XamControls.Tools;

namespace XamControls.Charts.Standard
{
    public class HorizontalAreaChart
    {

				private HorizArea horizArea1;
				private Variables.Variables var;
				private DataPointSelection tool_dataPointSelect;

				public HorizontalAreaChart(ChartView BaseChart)
				{

						horizArea1 = new HorizArea();
						var = new Variables.Variables();
						tool_dataPointSelect = new DataPointSelection(BaseChart);
	
						BaseChart.Chart.Header.Text = "People in different countries";
						BaseChart.Chart.Series.Add(horizArea1);
						BaseChart.Chart.Legend.Visible = false;

						horizArea1.SeriesColor = var.GetPaletteBasic[0];
						horizArea1.Chart.Zoom.Allow = false;
						horizArea1.Chart.Panning.Allow = ScrollModes.None;

						horizArea1.RecalcOptions = RecalcOptions.OnModify;
						horizArea1.DefaultNullValue = 0;
						horizArea1.AreaLines.Visible = false;
						horizArea1.Pointer.Visible = true;
						horizArea1.ClickableLine = true;
						horizArea1.LinePen.Width = 5;
						horizArea1.ClickPointer += tool_dataPointSelect.PointValue_Click;
						horizArea1.GetSeriesMark += tool_dataPointSelect.Serie_GetSeriesMark;

						horizArea1.Pointer.Style = PointerStyles.Nothing;
						horizArea1.Pointer.InflateMargins = false;
						horizArea1.ClickTolerance = 30;
						horizArea1.LinePen.Style = DashStyle.Solid;
						horizArea1.LinePen.EndCap = PenLineCap.Flat;
						horizArea1.LinePen.DashCap = PenLineCap.Flat;
						horizArea1.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);
						horizArea1.VertAxis = VerticalAxis.Both;
						horizArea1.HorizAxis = HorizontalAxis.Both;

						for (int i = 0; i < var.GetValorHorizArea1.Length; i++)
						{
							horizArea1.Add(var.GetValorHorizArea1[i], var.GetValorHorizAreaX[i]);
						}

						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue-0.001, BaseChart.Chart.Axes.Left.MaxYValue+0.01);
						BaseChart.Chart.Axes.Bottom.SetMinMax(0, BaseChart.Chart.Axes.Bottom.MaxXValue + 20000);

						BaseChart.Chart.Axes.Bottom.Increment = 30000;

						BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
						BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0K";
						BaseChart.Chart.Axes.Left.Title.Pen = new ChartPen { Color = Color.Black, Width = 15 };

						BaseChart.Chart.Axes.Left.Visible = true;
						BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
						BaseChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.FromArgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
						BaseChart.Chart.Axes.Bottom.Visible = true;

						BaseChart.Chart.Axes.Left.Title.Angle = 90;
						BaseChart.Chart.Axes.Left.Grid.Visible = false;
						BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
						BaseChart.Chart.Axes.Left.Title.Text = "Countries";
						BaseChart.Chart.Axes.Bottom.Title.Text = "People (K)";
						BaseChart.Chart.Axes.Left.Title.Font.Size = 14;
						BaseChart.Chart.Axes.Bottom.Title.Font.Size = 14;
						BaseChart.Chart.Axes.Left.Title.CustomSize = 50;
						BaseChart.Chart.Axes.Left.LabelsOnAxis = true;
						BaseChart.Chart.Axes.Left.Labels.AutoSize = true;
						BaseChart.Chart.Title.AutoSize = true;
						BaseChart.Chart.Axes.Left.StartPosition = 1;
						BaseChart.Chart.ClickSeries += null;
						BaseChart.Chart.Panel.MarginLeft = 6;
						BaseChart.Chart.Axes.Left.Title.Visible = false;

						Themes.AplicarMarksTheme1(BaseChart);

						BaseChart.Chart.Series[0].Marks.Height = 35;
						BaseChart.Chart.Series[0].Marks.Width = 110;
						BaseChart.Chart.Series[0].Marks.Font.Size = 12;

                }

		}

}
