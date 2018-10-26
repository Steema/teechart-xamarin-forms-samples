using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Charts.CircularGauges
{
    public class CarFuelChart
    {

				private CircularGauge circularGauge;
				private Variables.Variables var;

				public CarFuelChart(ChartView BaseChart)
				{

						circularGauge = new CircularGauge();
						var = new Variables.Variables();

						BaseChart.Chart.Series.Add(circularGauge);
						//BaseChart.Chart.AfterDraw += Chart_AfterDraw;
						BaseChart.Chart.Title.Visible = false;

						//circularGauge.GaugeColorPalette = var.GetPaletteBasic;
						circularGauge.Title = "Car Fuel";
						circularGauge.MinorTicks.Visible = true;
						circularGauge.MinorTickDistance = 2;
						circularGauge.MinorTicks.Color = Xamarin.Forms.Color.White;
						circularGauge.MinorTicks.VertSize = 4;
						circularGauge.MinorTicks.HorizSize = 3;
						circularGauge.MinorTicks.Pen.Visible = false;
						//circularGauge.MinorTicks.SizeDouble = 5;
						circularGauge.Ticks.Visible = true;
						circularGauge.Ticks.Color = Xamarin.Forms.Color.White;
						
						circularGauge.HandDistance = 60;
						circularGauge.HandOffset = 0;
						circularGauge.Hand.HorizSize = 10;
						circularGauge.Hand.Color = Xamarin.Forms.Color.FromRgb(220, 220, 220);
						circularGauge.Hand.Draw3D = false;
						circularGauge.Hand.Pen.Visible = false;
						circularGauge.Hand.Gradient.Visible = false;
						circularGauge.Hand.Shadow.Visible = true;
						circularGauge.Center.Color = Xamarin.Forms.Color.FromRgb(220, 220, 220);
						circularGauge.Center.Gradient.Visible = true;
						circularGauge.Center.HorizSize = 25;
						circularGauge.Center.VertSize = 25;
						circularGauge.Center.Draw3D = false;
						circularGauge.Center.Pen.Visible = true;
						circularGauge.Center.Shadow.Visible = true;
						//circularGauge.FaceBrush.ForegroundColor = basicColorFaceBrush;
						circularGauge.RotateLabels = false;
						circularGauge.RedLine.Visible = false;
						circularGauge.GreenLine.Visible = true;
						circularGauge.GreenLine.Gradient.Visible = true;
						circularGauge.GreenLine.Gradient.UseMiddle = true;
						circularGauge.GreenLine.Gradient.StartColor = Xamarin.Forms.Color.Red;
						circularGauge.GreenLine.Gradient.EndColor = Xamarin.Forms.Color.LightGreen;
						circularGauge.GreenLine.Gradient.Direction = Steema.TeeChart.Drawing.GradientDirection.FromBottomLeft;
						circularGauge.GreenLineStartValue = 0;
						circularGauge.GreenLineEndValue = 1;
						circularGauge.GreenLine.InflateMargins = true;
						circularGauge.Frame.Visible = true;
						circularGauge.Frame.FrameElementPercents = new double[3] { 0, 60, 40 };
						circularGauge.Frame.MiddleBand.Color = Xamarin.Forms.Color.FromRgb(190, 190, 190);
						circularGauge.Frame.OuterBand.Visible = false;
						circularGauge.Frame.InnerBand.Visible = true;
						circularGauge.Frame.InnerBand.Gradient.Visible = false;
						circularGauge.Frame.InnerBand.Solid = true;
						circularGauge.Frame.InnerBand.Color = Xamarin.Forms.Color.FromRgb(120, 120, 120);
                        circularGauge.Frame.MiddleBand.Visible = false;
						circularGauge.Frame.MiddleBand.Solid = true;
						circularGauge.Frame.MiddleBand.Gradient.Visible = true;
						circularGauge.Frame.MiddleBand.Gradient.StartColor = Xamarin.Forms.Color.FromRgb(100, 100, 100);
						circularGauge.Frame.MiddleBand.Gradient.MiddleColor = Xamarin.Forms.Color.FromRgb(50, 50, 50);
						circularGauge.Frame.MiddleBand.Gradient.EndColor = Xamarin.Forms.Color.FromRgb(20, 20, 20);
						circularGauge.Frame.MiddleBand.Gradient.Direction = Steema.TeeChart.Drawing.GradientDirection.DiagonalDown;
						circularGauge.Frame.RotationAngle = 0;
						circularGauge.Frame.Circled = true;
						circularGauge.Frame.Width = 2;
						circularGauge.CircleBackColor = Xamarin.Forms.Color.White;
						circularGauge.Axis.Labels.Font.Color = Xamarin.Forms.Color.White;
						circularGauge.Maximum = 1;
						circularGauge.Axis.Increment = 0.25;
						circularGauge.Value = 0.75;
						circularGauge.TotalAngle = 180;
						circularGauge.Hand.Style = PointerStyles.DownTriangle;
						circularGauge.FaceBrush.Visible = false;
						circularGauge.FaceBrush.Solid = false;
						circularGauge.FaceBrush.Gradient.Visible = false;
                        circularGauge.DisplayTotalAngle = 180;
                        circularGauge.CircleBackColor = Xamarin.Forms.Color.Black;
                        circularGauge.Frame.TotalAngle = 180;

                        BaseChart.Chart.Axes.Bottom.Ticks.Transparency = 100;
						//BaseChart.Chart.AfterDraw += Chart_AfterDraw;

				}

				private void Chart_AfterDraw(object sender, Graphics3D g)
				{

						var chart = sender as ChartView;

						g.Rectangle(new Xamarin.Forms.Rectangle() { Width = 100, Height = 100, });
						//g.Draw(0, 0, new Image { Source = ImageSource.FromResource("tower.png") } );

				}

		}
}
