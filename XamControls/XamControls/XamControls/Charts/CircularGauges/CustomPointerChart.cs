using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace XamControls.Charts.CircularGauges
{
    public class CustomPointerChart
    {

				private CircularGauge circularGauge;
				private Variables.Variables var;

				public CustomPointerChart(ChartView BaseChart)
				{

						circularGauge = new CircularGauge();
						var = new Variables.Variables();
						GaugeSeriesPointer pointer2;

						BaseChart.Chart.Series.Add(circularGauge);
						BaseChart.Chart.Title.Visible = false;
						BaseChart.Chart.Panning.Active = true;
						BaseChart.Chart.Panning.Allow = ScrollModes.Both;
						BaseChart.Chart.Zoom.Active = true;
						BaseChart.Chart.Zoom.Allow = true;

						pointer2 = new GaugeSeriesPointer(BaseChart.Chart, BaseChart.Chart.Series[0]);

						//circularGauge.GaugeColorPalette = var.GetPaletteBasic;
						circularGauge.Title = "Custom Hand";
						circularGauge.MinorTicks.Visible = false;
						circularGauge.Ticks.Visible = false;

						circularGauge.Hand.HorizSize = 20;
						circularGauge.Hand.Color = Color.Red;
						circularGauge.Hand.Draw3D = false;
						circularGauge.Hand.Pen.Visible = false;
						circularGauge.Hand.Shadow.Visible = false;
						circularGauge.Hand.Style = PointerStyles.Arrow;
						circularGauge.Hand.Gradient.Visible = false;

						pointer2.HorizSize = 20;
						pointer2.Color = Color.FromArgb(30, 70, 230);
						pointer2.Draw3D = false;
						pointer2.Pen.Visible = false;
						pointer2.Gradient.Visible = false;
						pointer2.Shadow.Visible = false;
						pointer2.Style = PointerStyles.Arrow;
						pointer2.VertSize = 100;

						circularGauge.HandDistances.Add(80);
						circularGauge.HandOffsets.Add(0);
						circularGauge.HandOffset = 0;
						circularGauge.HandDistance = 80;

						circularGauge.Hands.Add(pointer2); 
						circularGauge.Center.Color = Color.White;
						circularGauge.Center.Gradient.Visible = false;
						circularGauge.Center.HorizSize = 30;
						circularGauge.Center.VertSize = 30;
						circularGauge.Center.Pen.Color = Color.White;
						circularGauge.Center.Draw3D = false;
						circularGauge.Center.Pen.Visible = true;
						circularGauge.Center.Shadow.Visible = false;
						circularGauge.Center.Visible = true;
						circularGauge.FaceBrush.Visible = true;
						circularGauge.FaceBrush.Solid = true;
						circularGauge.FaceBrush.Gradient.Visible = false;
						circularGauge.FaceBrush.ForegroundColor = Color.White;
						circularGauge.FaceBrush.Color = Color.White;
						circularGauge.RotateLabels = false;
						circularGauge.RedLine.Visible = false;
						circularGauge.GreenLine.Visible = false;
						circularGauge.Frame.TotalAngle = 180;
						circularGauge.Frame.Visible = true;
						circularGauge.Frame.FrameElementPercents = new double[3] { 0, 100, 0 };
						circularGauge.Frame.MiddleBand.Color = Color.FromArgb(140, 140, 140);
						circularGauge.Frame.OuterBand.Visible = false;
						circularGauge.Frame.InnerBand.Visible = false;
						circularGauge.Frame.MiddleBand.Solid = true;
						circularGauge.Frame.MiddleBand.Gradient.Visible = false;
						circularGauge.Frame.MiddleBand.Gradient.Direction = GradientDirection.DiagonalUp;
						circularGauge.Frame.RotationAngle = 0;
						circularGauge.Frame.Circled = true;
						circularGauge.Frame.Width = 2;
						circularGauge.Color = Color.White;
						circularGauge.CircleBackColor = Color.White;
						circularGauge.Axis.Labels.Font.Color = Color.Black;
						circularGauge.Maximum = 10;
						circularGauge.Axis.Increment = 2;
						circularGauge.Value = 6;
						circularGauge.TotalAngle = 180;

						circularGauge.mandatory[0] = 7;
						circularGauge.mandatory[1] = 2;
			
				}
		}
}
