using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Charts.Numeric_Gauge
{
		public class NumericGaugeChart
		{

				private NumericGauge numericGauge;
				private ChartView BaseChart;

				public NumericGaugeChart(ChartView BaseChart) {

					numericGauge = new NumericGauge();
					this.BaseChart = BaseChart;

					numericGauge.FillSampleValues();

					BaseChart.Chart.Series.Add(numericGauge);
					BaseChart.Chart.Header.Visible = false;

					numericGauge.GaugeColorPalette = null;
					numericGauge.FaceBrush.Gradient.Visible = false;
					numericGauge.FaceBrush.ForegroundColor = Color.FromRgb(8, 81, 137);
					numericGauge.FaceBrush.Color = Color.FromRgb(8, 81, 137);
					numericGauge.FaceBrush.Solid = true;
					numericGauge.FaceBrush.Visible = true;
					numericGauge.Markers[0].Active = true;
					numericGauge.Markers[1].Active = true;
					numericGauge.Markers[2].Active = true;
					numericGauge.Markers[0].UsePalette = false;
					numericGauge.Markers[1].UsePalette = false;
					numericGauge.Markers[2].UsePalette = false;
					numericGauge.Markers[0].Shape.Color = Color.FromRgb(8, 81, 137);
					numericGauge.Markers[1].Shape.Color = Color.FromRgb(8, 81, 137);
					numericGauge.Markers[2].Shape.Color = Color.FromRgb(8, 81, 137);
					numericGauge.Markers[0].Shape.Font.Color = Color.White;
					numericGauge.Markers[1].Shape.Font.Color = Color.White;
					numericGauge.Markers[2].Shape.Font.Color = Color.White;
					numericGauge.Markers[0].TextAlign = TextAlignment.End;
					numericGauge.Markers[1].TextAlign = TextAlignment.Center;
					numericGauge.Markers[2].TextAlign = TextAlignment.Center;
					numericGauge.TextMarker.Shape.Font.Color = Color.White;

				}

				// Permet eliminar la tool dels marks
				public void RemoveMarkTool()
				{
		
						for(int i = BaseChart.Chart.Tools.Count-1; i >= 0; i--) { BaseChart.Chart.Tools.RemoveAt(i); }

				}
		}
}
