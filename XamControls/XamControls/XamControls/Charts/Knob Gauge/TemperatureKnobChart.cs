using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Charts.Knob_Gauge
{
    class TemperatureKnobChart
    {

				private KnobGauge knobGauge;
				private ChartView BaseChart;
				private Annotation annotationCold;
				private Annotation annotationHot;

				public TemperatureKnobChart(ChartView BaseChart)
				{

					knobGauge = new KnobGauge();
					this.BaseChart = BaseChart;
					this.annotationCold = new Annotation();
					this.annotationHot = new Annotation();

					annotationCold.Active = false;
					annotationHot.Active = false;

					knobGauge.FillSampleValues(4);

					BaseChart.Chart.Series.Add(knobGauge);

					knobGauge.MinorTicks.Visible = false;
					knobGauge.Ticks.Visible = false;
					BaseChart.Chart.Header.Visible = false;
					BaseChart.Chart.Axes.Left.Labels.Visible = false;

					BaseChart.Chart.Tools.Add(annotationCold);
					BaseChart.Chart.Tools.Add(annotationHot);

					knobGauge.FaceBrush.Gradient.Visible = false;
					knobGauge.FaceBrush.ForegroundColor = Color.White;
					knobGauge.GreenLineStartValue = 0;
					knobGauge.GreenLineEndValue = 0.5;
					knobGauge.RedLineStartValue = 0.5;
					knobGauge.RedLineEndValue = 1;
					knobGauge.RedLine.Gradient.Visible = true;
					knobGauge.RedLine.Gradient.Direction = Steema.TeeChart.Drawing.GradientDirection.TopBottom;
					knobGauge.RedLine.Gradient.StartColor = Color.FromRgb(255, 0, 0);
					knobGauge.RedLine.Gradient.EndColor = Color.FromRgb(255, 255, 192);
					knobGauge.RedLine.HorizSize = 10;
					knobGauge.GreenLine.Gradient.Visible = true;
					knobGauge.GreenLine.Gradient.Direction = Steema.TeeChart.Drawing.GradientDirection.BottomTop;
					knobGauge.GreenLine.Gradient.StartColor = Color.FromRgb(192, 255, 255);
					knobGauge.GreenLine.Gradient.EndColor = Color.FromRgb(0, 0, 255);
					knobGauge.GreenLine.HorizSize = 10;
					knobGauge.CircleBackColor = Color.White;
					knobGauge.Color = Color.White;
					knobGauge.FaceBrush.Color = Color.White;
					knobGauge.Axis.Labels.Font.Size = 17;
					knobGauge.LabelsInside = false;
					knobGauge.Axis.LabelsOnAxis = false;
					knobGauge.Value = 0.38;
					knobGauge.Center.SizeDouble = 40;
					knobGauge.Center.Color = Color.FromRgb(64, 64, 64);
					knobGauge.Center.Gradient.Visible = false;
					knobGauge.Axis.Increment = 1;
					knobGauge.Maximum = 1;

					annotationCold.Active = true;
					annotationCold.AutoSize = true;
					annotationCold.Text = "Cold";
					annotationCold.Left = BaseChart.Width / 4;
					annotationCold.Top = (((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).Height + 250;
					annotationCold.Shape.Shadow.Visible = false;
					annotationCold.Shape.Font.Size = 20;
					annotationCold.Shape.Pen.Visible = false;
					annotationCold.Shape.Color = Color.Transparent;
					annotationCold.Shape.Font.Color = knobGauge.GreenLine.Gradient.EndColor;

					annotationHot.Active = true;
					annotationHot.AutoSize = true;
					annotationHot.Text = "Hot";
					annotationHot.Left = BaseChart.Width + BaseChart.Width / 2;
					annotationHot.Top = (((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).Height + 250;
					annotationHot.Shape.Shadow.Visible = false;
					annotationHot.Shape.Font.Size = 20;
					annotationHot.Shape.Pen.Visible = false;
					annotationHot.Shape.Color = Color.Transparent;
					annotationHot.Shape.Font.Color = knobGauge.RedLine.Gradient.StartColor;

					ChangeHandColor();

				}

				public void ChangeHandColor()
				{

						if (knobGauge.Value < 0.25) { knobGauge.Hand.Color = knobGauge.GreenLine.Gradient.EndColor; }
						else if (knobGauge.Value < 0.5) { knobGauge.Hand.Color = knobGauge.GreenLine.Gradient.StartColor; }
						else if (knobGauge.Value == 0.5) { knobGauge.Hand.Color = Color.White; }
						else if (knobGauge.Value < 0.75) { knobGauge.Hand.Color = knobGauge.RedLine.Gradient.EndColor; }
						else { knobGauge.Hand.Color = knobGauge.RedLine.Gradient.StartColor; }

				}

				// Permet eliminar la tool dels marks
				public void RemoveAnnoTool()
				{

					for (int i = BaseChart.Chart.Tools.Count - 1; i >= 0; i--) { BaseChart.Chart.Tools.RemoveAt(i); }

				}

		}
}
