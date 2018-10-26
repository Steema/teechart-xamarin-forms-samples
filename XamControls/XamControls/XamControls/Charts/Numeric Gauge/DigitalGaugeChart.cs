using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Charts.Numeric_Gauge
{
    public class DigitalGaugeChart
    {

				private NumericGauge digitalGauge;
				private ChartView BaseChart;

				public DigitalGaugeChart(ChartView BaseChart) {

						digitalGauge = new NumericGauge();
						this.BaseChart = BaseChart;
						digitalGauge.FillSampleValues();

						BaseChart.Chart.Header.Visible = false;

						BaseChart.Chart.Series.Add(digitalGauge);
		
						digitalGauge.GaugeColorPalette = null;
						digitalGauge.Markers[0].UsePalette = false;
						digitalGauge.Markers[1].Active = false;
						digitalGauge.Markers[2].Active = false;
						digitalGauge.FaceBrush.Gradient.Visible = false;
						digitalGauge.FaceBrush.ForegroundColor = Color.FromRgb(40, 40, 40);
						digitalGauge.FaceBrush.Color = Color.FromRgb(40, 40, 40);
						digitalGauge.FaceBrush.Solid = true;
						digitalGauge.FaceBrush.Visible = true;
						digitalGauge.Markers[0].Active = true;
						digitalGauge.Markers[0].UsePalette = false;
						digitalGauge.Markers[0].Shape.Color = Color.FromRgb(40, 40, 40);
						digitalGauge.Markers[0].Shape.Font.Color = Color.Red;
						digitalGauge.Markers[0].TextAlign = TextAlignment.End;
						digitalGauge.Markers[0].Centered = true;
						digitalGauge.TextMarker.Shape.Font.Color = Color.White;
						digitalGauge.FaceBrush.Visible = false;
						digitalGauge.Markers[0].Shape.Font.Size = 40;
						digitalGauge.Markers[0].Position = AnnotationPositions.LeftTop;


				}

				// Permet eliminar la tool dels marks
				public void RemoveMarkTool()
				{

						for (int i = BaseChart.Chart.Tools.Count - 1; i >= 0; i--) { BaseChart.Chart.Tools.RemoveAt(i); }

				}

		}
}
