using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;

namespace XamControls.Charts.Pro
{
    public class RadarChart
    {
#if !TEE_STD
        private Radar radar1;
				private Radar radar2;
				private Radar radar3;
				private ChartView BaseChart;
				private Variables.Variables var;

				public RadarChart(ChartView BaseChart)
				{

						this.BaseChart = BaseChart;
						var = new Variables.Variables();
						radar1 = new Radar();
						radar2 = new Radar();
						radar3 = new Radar();

						BaseChart.Chart.Title.Text = "Radar";
						BaseChart.Chart.Legend.Visible = false;
						BaseChart.Chart.Axes.Left.Visible = true;
						BaseChart.Chart.Axes.Bottom.Visible = true;
						BaseChart.Chart.Axes.Left.Grid.Visible = true;
						BaseChart.Chart.Axes.Bottom.Grid.Visible = true;
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.AxisPen.Visible = true;

						BaseChart.Chart.Axes.Bottom.Increment = 200;
						BaseChart.Chart.Axes.Left.Increment = 200;

						InitializeRadarSerie(radar1, 0);
						InitializeRadarSerie(radar2, 1);
						InitializeRadarSerie(radar3, 2);

						// Themes Marks
						Themes.AplicarMarksTheme1(BaseChart);

						BaseChart.Chart.Series[0].Marks.Font.Size = 18;
						BaseChart.Chart.Panel.MarginLeft = 5;

				}

				private void InitializeRadarSerie(Radar radar, int pos)
				{

						radar.FillSampleValues(5);
						radar.Color = var.GetPaletteBasic[pos];
						radar.Circled = true;
						radar.CloseCircle = true;
						radar.CircleLabels = true;
						radar.Pen.Visible = true;
						radar.Pen.Color = Color.White;
						radar.Pen.Width += 1;
						radar.LabelsMargin += 1;
						radar.CircleLabelsFont.Size += 1;

						radar.Marks.Pen.Visible = false;
						radar.Marks.FollowSeriesColor = false;
						radar.Marks.Style = MarksStyles.Percent;
						radar.AutoCircleResize = false;
						radar.Marks.Brush.Transparency = 100;
						radar.Marks.Transparent = true;
						radar.Marks.Frame.Transparency = 100;

						BaseChart.Chart.Series.Add(radar);

				}
#endif

		}
}
