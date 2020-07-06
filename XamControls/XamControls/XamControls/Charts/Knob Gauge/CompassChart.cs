using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamControls.Variables;

namespace XamControls.Charts.Knob_Gauge
{
    public class CompassChart
    {

		private KnobGauge knobGauge;
		private ChartView BaseChart;
		private Variables.Variables var;
		private GaugeSeriesPointer backPointer;

		public CompassChart(ChartView BaseChart)
		{
			knobGauge = new KnobGauge();
			this.BaseChart = BaseChart;
			var = new Variables.Variables();
			backPointer = new GaugeSeriesPointer(BaseChart.Chart, knobGauge);

            try
            {
                Compass.Start(SensorSpeed.UI);
                Compass.ReadingChanged += Compass_ReadingChanged;
            }
            catch (Exception) { }

			BaseChart.Chart.Panning.Active = true;
			BaseChart.Chart.Panning.Allow = ScrollModes.Both;
			BaseChart.Chart.Zoom.Active = true;
			BaseChart.Chart.Zoom.Allow = true;

			knobGauge.FillSampleValues(4);

			BaseChart.Chart.Series.Add(knobGauge);

			knobGauge.MinorTicks.Visible = false;
			knobGauge.Ticks.Visible = true;
			knobGauge.Ticks.Color = Color.FromRgb(120, 120, 120);
			knobGauge.Ticks.Pen.Visible = false;
			knobGauge.Ticks.VertSize = 7;
			knobGauge.Ticks.HorizSize = 2;
			knobGauge.AxisInside = true;
			BaseChart.Chart.Header.Visible = false;
			BaseChart.Chart.Axes.Left.Labels.Visible = true;

			knobGauge.FaceBrush.Gradient.Visible = true;
			knobGauge.FaceBrush.Gradient.UseMiddle = true;
			knobGauge.FaceBrush.Gradient.Direction = GradientDirection.Radial;
			knobGauge.FaceBrush.Gradient.StartColor = Color.FromRgb(255, 255, 255);
			knobGauge.FaceBrush.Gradient.MiddleColor = Color.FromRgb(240, 240, 240);
			knobGauge.FaceBrush.Gradient.EndColor = Color.FromRgb(220, 220, 220);
			knobGauge.RedLine.Visible = false;
			knobGauge.GreenLine.Visible = false;
			knobGauge.CircleBackColor = Color.White;
			knobGauge.Color = Color.White;
			knobGauge.Axis.Labels.Font.Size = 17;
			knobGauge.LabelsInside = true;
			knobGauge.Axis.LabelsOnAxis = false;
			knobGauge.Value = 1;
			knobGauge.Center.SizeDouble = 10;
			knobGauge.Center.Color = Color.FromRgb(64, 64, 64);
			knobGauge.Center.Gradient.Visible = false;
			knobGauge.Center.Shadow.Visible = false;
			knobGauge.Center.Visible = false;
						
			knobGauge.HighLightBrush.Visible = false;
			knobGauge.Axis.Increment = 45;
			knobGauge.Maximum = 360;
			knobGauge.Rotate(180);
			knobGauge.TotalAngle = 360;

			knobGauge.Frame.Visible = true;
			knobGauge.Frame.OuterBand.Visible = false;
			knobGauge.Frame.MiddleBand.Visible = false;
			knobGauge.Frame.InnerBand.Visible = true;
			knobGauge.Frame.InnerBand.Solid = true;
			knobGauge.Frame.InnerBand.Color = Color.FromRgb(170, 170, 170);
			knobGauge.Frame.Width = 2;
			knobGauge.Frame.FrameElementPercents = new double[3] {0, 0, 100};
			knobGauge.Frame.TotalAngle = 360;

			backPointer.VertSize = 100;
			backPointer.Visible = true;
			backPointer.Draw3D = false;
			backPointer.Pen.Visible = false;
			backPointer.Gradient.Visible = false;
			backPointer.Shadow.Visible = false;
			backPointer.Style = PointerStyles.DownTriangle;
			backPointer.Color = Color.FromRgb(150, 150, 150);
			backPointer.HorizSize = 49;

			knobGauge.Hands.Add(backPointer);

			knobGauge.HandDistances.Add(80);
			knobGauge.HandOffsets.Add(0);
			knobGauge.HandDistance = 80;
			knobGauge.HandOffset = 0;

			knobGauge.Active = true;

			knobGauge.Hand.Color = Color.Red;
			knobGauge.Hand.Style = PointerStyles.DownTriangle;
			knobGauge.Hand.Shadow.Visible = false;

			BaseChart.Chart.Axes.Left.GetAxisDrawLabel += Left_GetAxisDrawLabel;

			knobGauge.mandatory.Capacity = 2;
			knobGauge.mandatory.Count = 2;
		}

		// Actualiza los labels del Axis para mostrar unos valores en concreto
		private int position = 0;
		private void Left_GetAxisDrawLabel(object sender, GetAxisDrawLabelEventArgs e)
		{
			if (position < 8)
			{
				e.Text = var.GetCompassAxisLabels[position];
				position++;

				if(position == 8) { position = 0; }
			}
		}

		// Detección por parte del giroscopio y actualización del gaugeValue
		private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
		{
            try
            {
                var data = e.Reading;
				var grados = data.HeadingMagneticNorth;

				knobGauge.Value = grados; knobGauge.mandatory[1] = grados + 180;
            }
			catch(Exception exception) {  }
		}

		// Permet eliminar la tool dels marks
		public void RemoveCompassEvent()
		{
			Compass.ReadingChanged -= Compass_ReadingChanged;
            Compass.Stop();
			BaseChart.Chart.Axes.Left.GetAxisDrawLabel -= Left_GetAxisDrawLabel;
		}

	}
}
