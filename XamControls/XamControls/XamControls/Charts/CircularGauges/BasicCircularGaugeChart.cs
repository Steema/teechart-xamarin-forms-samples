using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using System.Drawing;
using System.Threading;

namespace XamControls.Charts.CircularGauges
{
		public class BasicCircularGaugeChart
		{

				private CircularGauge circularGauge;
				private Variables.Variables var;

				public BasicCircularGaugeChart(ChartView BaseChart)
				{

					circularGauge = new CircularGauge();
					var = new Variables.Variables();
					

					BaseChart.Chart.Series.Add(circularGauge);

					BaseChart.Chart.Title.Visible = false;

					//circularGauge.GaugeColorPalette = var.GetPaletteBasic;
					circularGauge.MinorTicks.Visible = false;
					circularGauge.Title = "Basic Circular Gauge";
					circularGauge.Ticks.Visible = false;
					circularGauge.HandDistance = 70;
					circularGauge.HandOffset = 0;
					circularGauge.Hand.HorizSize = 6;
					circularGauge.Hand.Color = var.GetPaletteBasic[0];
					circularGauge.Hand.Draw3D = false;
					circularGauge.Hand.Pen.Visible = false;
					circularGauge.Hand.Gradient.Visible = false;
					circularGauge.Hand.Shadow.Visible = false;
					circularGauge.Center.Color = var.GetPaletteBasic[0];
					circularGauge.Center.Gradient.Visible = false;
					circularGauge.Center.HorizSize = 15;
					circularGauge.Center.VertSize = 15;
					circularGauge.Center.Draw3D = false;
					circularGauge.Center.Pen.Visible = false;
					circularGauge.Center.Shadow.Visible = false;
					circularGauge.FaceBrush.Color = Color.White;
					circularGauge.FaceBrush.Visible = true;
					circularGauge.FaceBrush.Solid = true;
					circularGauge.FaceBrush.Gradient.Visible = false;
					circularGauge.FaceBrush.ForegroundColor = Color.White;
					circularGauge.RotateLabels = false;
					circularGauge.RedLine.Visible = false;
					circularGauge.GreenLine.Visible = false;
					circularGauge.Frame.TotalAngle = 290;
					circularGauge.Frame.Visible = true;
					circularGauge.Frame.FrameElementPercents = new double[3] { 0, 100, 0 };
					circularGauge.Frame.MiddleBand.Color = Color.FromArgb(190, 190, 190);
					circularGauge.Frame.OuterBand.Visible = false;
					circularGauge.Frame.InnerBand.Visible = false;
					circularGauge.Frame.MiddleBand.Solid = true;
					circularGauge.Frame.MiddleBand.Gradient.Visible = false;
					circularGauge.Frame.RotationAngle = 305;
					circularGauge.Frame.Circled = true;
					circularGauge.Frame.Width = 2;
					circularGauge.CircleBackColor = Color.White;
					circularGauge.Color = Color.White;
					circularGauge.Axis.Labels.Font.Color = Color.Black;
					circularGauge.Value = 65;
					circularGauge.Maximum = 100;
					circularGauge.Axis.Increment = 10;

					
			}
		}

		
	}
