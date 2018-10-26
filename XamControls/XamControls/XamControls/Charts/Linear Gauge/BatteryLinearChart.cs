	using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using Steema.TeeChart.Animations.EasingFunctions;
using XamControls.Styles;

namespace XamControls.Charts.Linear_Gauge
{
    public class BatteryLinearChart
    {

			private LinearGauge linearGauge;
			private Annotation simulationMark;
			private ChartView BaseChart;

			public BatteryLinearChart(ChartView BaseChart)
			{

				linearGauge = new LinearGauge();
				var value = Battery.ChargeLevel * 100;
				Battery.BatteryChanged += Battery_BatteryChanged;
				simulationMark = new Annotation();
				this.BaseChart = BaseChart;

				BaseChart.Chart.Series.Add(linearGauge);
				BaseChart.Chart.Footer.Visible = true;
				BaseChart.Chart.Footer.Font.Size = 20;

				linearGauge.Value = 100 - value;
				linearGauge.Maximum = 100;
				linearGauge.Minimum = 0;

				linearGauge.Axis.AxisPen.Color = Color.Black;
				linearGauge.Axis.MinorGrid.Visible = true;
				linearGauge.Axis.Labels.Font.Size = 12;
				linearGauge.Axis.Labels.Color = Color.Blue;
				linearGauge.Axis.Ticks.Visible = true;
				linearGauge.Axis.Increment = 10;

				BaseChart.Rotation = 90;
				BaseChart.BackgroundColor = Color.White;

				BaseChart.Chart.Axes.Bottom.Labels.Font.Size = 16;
				BaseChart.Chart.Axes.Bottom.Labels.Font.Color = Color.Black;
				BaseChart.Chart.Axes.Bottom.Labels.Transparency = 100;
				BaseChart.Chart.Axes.Bottom.MinorTicks.Visible = false;
				BaseChart.Chart.Axes.Bottom.MinorTicks.Length = 20;
				BaseChart.Chart.Axes.Bottom.MinorTicks.Width = 1;
				BaseChart.Chart.Axes.Bottom.MinorTicks.Transparency = 100;
				BaseChart.Chart.Axes.Bottom.Ticks.Visible = false;

				linearGauge.Hand.Gradient.Visible = false;
				linearGauge.Hand.Color = Color.White;
				linearGauge.Hand.Transparency = 0;

				linearGauge.GreenLine.Visible = false;
				linearGauge.RedLine.Visible = false;

				linearGauge.MinorTicks.Visible = false;

				linearGauge.Ticks.Visible = true;
				linearGauge.Ticks.VertSize = 150;
				linearGauge.Ticks.HorizSize = 2.5;
				linearGauge.Ticks.Color = Color.White;
				linearGauge.Ticks.Pen.Color = Color.White;

				linearGauge.MaxValueIndicator.Visible = false;

				linearGauge.FaceBrush.Gradient.Visible = false;
				linearGauge.FaceBrush.Color = Color.White;

				linearGauge.ValueAreaBrush.Visible = true;

				AddFaceBrushColor(value);

				linearGauge.IsoVertAxes = false;
				linearGauge.IsoHorizAxes = false;

				linearGauge.Marks.Visible = false;

				Themes.AplicarMarksTheme1(BaseChart);
				linearGauge.Marks.Angle = 90;
				linearGauge.Marks.TailStyle = MarksTail.None;
				linearGauge.Marks.BackColor = Color.White;
				linearGauge.Marks.Width += 50;
				linearGauge.Marks.Font.Color = Color.Black;
				linearGauge.GetSeriesMark += LinearGauge_GetSeriesMark;
				BaseChart.Chart.AfterDraw += Chart_AfterDraw;

			}

			// Evento después de pintar
			private void Chart_AfterDraw(object sender, Graphics3D g)
			{


					//simulationMark.Shape.Font.Size = 15;
					g.Font.Size = 22;

					g.RotateLabel(linearGauge.Chart.ChartRect.Center.Y - 210, linearGauge.Chart.ChartRect.Center.X + 85, Math.Round((100 - Convert.ToDouble(linearGauge.Value)), 2).ToString() + " %", 90);

			/*
					simulationMark.TextAlign = TextAlignment.Center;
					simulationMark.Active = true;
					simulationMark.Shape.Size = new ShapeSize() { Height = 140, Width = 300 };
					simulationMark.Text = Math.Round(linearGauge.Value, 2).ToString();
					simulationMark.Shape.Color = Color.Black;
					simulationMark.Shape.Pen.Color = Color.FromRgb(250, 220, 140);
					simulationMark.Shape.Shadow.Visible = false;
					simulationMark.Width = (int)g.TextWidth(simulationMark.Text) + 10;
					simulationMark.Height = (int)g.TextHeight(simulationMark.Text) + 5;
					simulationMark.Left = 0;//BaseChart.Width / 2 - 20;
					simulationMark.Top = 0;//BaseChart.Height - 40;
					*/
					//BaseChart.Refresh();

					/*
					simulationMark.Active = false;
					if (linearGauge.Value > 10) { simulationMark.Text = (100 - linearGauge.Value).ToString(); }
					else { simulationMark.Text = Math.Round((100 - linearGauge.Value), 1).ToString(); };
					simulationMark.Shape.Font.Size = 16;
					simulationMark.Shape.Color = Color.Red;
					simulationMark.Left = BaseChart.Height * 1.25;
					simulationMark.Top = BaseChart.Width * 1.5 - 10;
					simulationMark.Shape.Font.Color = Color.White;
					simulationMark.Shape.Shadow.Visible = false;

					BaseChart.Chart.Tools.Add(simulationMark);

					simulationMark.Shape.Width = 430;

					simulationMark.Width = 430;//g.TextWidth(simulationMark.Text) + 430;
					simulationMark.Height = g.TextHeight(simulationMark.Text) + 110;
					simulationMark.Shape.DrawRectRotated(g, simulationMark.Bounds, 90, 100);

					//g.RotateLabel(simulationMark.Bounds.X, simulationMark.Bounds.Y - 10, simulationMark.Text, 90);
					//g.Rectangle(simulationMark.Bounds);
					//g.RotateRectangle(simulationMark.Bounds, 90, simulationMark.Bounds.Center);

					g.Font.Size = 16;
					g.RotateLabel(simulationMark.Left, simulationMark.Top, simulationMark.Text.ToString(), 90);
					*/

		}

			// Evento para actualizar el valor de la mark
			private void LinearGauge_GetSeriesMark(Series series, GetSeriesMarkEventArgs e)
			{
				
					e.MarkText = (100 - linearGauge.Value).ToString();

			}

			// Evento que ocurre cuando el valor de bateria se modifica
			private void Battery_BatteryChanged(object sender, BatteryChangedEventArgs e)
			{

					linearGauge.Value = 100 - (e.ChargeLevel * 100);
					linearGauge.Marks.Text = (100 - linearGauge.Value).ToString();

			}

			// Modifica el color del "FaceBrush" según la bateria restante
			public void AddFaceBrushColor(double value)
			{

					if (value >= 0 && value < 25) { linearGauge.ValueAreaBrush.Color = Color.FromRgb(255, 0, 0); }
					else if (value >= 25 && value < 50) { linearGauge.ValueAreaBrush.Color = Color.FromRgb(255, 140, 0); }
					else if (value >= 50 && value < 75) { linearGauge.ValueAreaBrush.Color = Color.FromRgb(255, 208, 0); }
					else { linearGauge.ValueAreaBrush.Color = Color.FromRgb(0, 195, 10); }

			}

			// Permet eliminar la tool dels marks
			public void RemoveAnnoTool()
			{

				for (int i = BaseChart.Chart.Tools.Count - 1; i >= 0; i--) { BaseChart.Chart.Tools.RemoveAt(i); }
				BaseChart.Chart.AfterDraw -= Chart_AfterDraw;

			}


		}
}
