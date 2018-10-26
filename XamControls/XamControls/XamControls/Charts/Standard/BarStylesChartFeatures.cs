using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Standard
{
    public class BarStylesChartFeatures
    {

			private Bar bar1;
			private Variables.Variables var;
			private ChartView BaseChart;

			public BarStylesChartFeatures(ChartView BaseChart)
			{
				bar1 = new Bar();
				var = new Variables.Variables();
				this.BaseChart = BaseChart;

				BaseChart.Chart.Legend.Visible = true;
				BaseChart.Chart.Header.Text = "Product sale";
				BaseChart.Chart.Series.Add(bar1);

				bar1.Colors = new ColorList { var.GetPaletteBasic[0] };
				bar1.SeriesColor = var.GetPaletteBasic[0];
				bar1.Chart.Zoom.Allow = false;
				bar1.Chart.Panning.Allow = ScrollModes.None;
				bar1.RecalcOptions = RecalcOptions.OnModify;
				bar1.Title = "ConeBar1";
				bar1.DefaultNullValue = 0;
				for (int i = 0; i < var.GetValorConeBar1.Length; i++) { bar1.Add(var.GetValorConeBar1[i], var.GetValorConeBarX[i]); }
				bar1.MarksOnBar = false;
				bar1.Marks.Style = MarksStyles.Value;
				bar1.BarWidthPercent = 90;
				bar1.BarStyle = BarStyles.Arrow;
				bar1.VertAxis = VerticalAxis.Both;
				bar1.HorizAxis = HorizontalAxis.Both;

				BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
				BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
				BaseChart.Chart.Axes.Left.Ticks.Visible = false;
				BaseChart.Chart.Axes.Left.Title = null;
				BaseChart.Chart.Axes.Bottom.Title = null;
				BaseChart.Chart.Axes.Left.Ticks.Visible = false;
				BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
				BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
				BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
				BaseChart.Chart.Axes.Left.Grid.Visible = false;
				BaseChart.Chart.Axes.Left.Increment = 2;
				BaseChart.Chart.Legend.Visible = false;
				BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
				BaseChart.Chart.ClickSeries += Chart_ClickSeries;
				BaseChart.Chart.Axes.Left.Labels.CustomSize = 0;
				BaseChart.Chart.Axes.Bottom.LabelsOnAxis = true;
				BaseChart.Chart.Footer.Visible = true;
				BaseChart.Chart.Footer.Font.Size = 18;
				BaseChart.Chart.Footer.Font.Color = Color.FromArgb(110, 110, 110);
				BaseChart.Chart.Footer.Height = 110;

				// Themes Marks
				Themes.AplicarMarksTheme1(BaseChart);

				BaseChart.Chart.Series[0].Marks.Font.Size = 14;

				bar1.Marks.Pen.Visible = false;

				BaseChart.Chart.Series[0].Marks.TextAlign = Xamarin.Forms.TextAlignment.Center;
				BaseChart.Chart.Series[0].Marks.AutoSize = true;
				BaseChart.Chart.Series[0].Marks.Color = Color.Transparent;
				BaseChart.Chart.Panel.MarginLeft = 5;

				BaseChart.Chart.Axes.Left.Visible = false;

            }

			// Evento que modifica el color de la barra cuando haces "click"

			int lastValueIndex = -1;
			public void Chart_ClickSeries(object sender, Series s, int valueIndex, Steema.TeeChart.Drawing.MouseEventArgs e)
			{

				if (BaseChart.Chart.Title.Text == BaseChart.Chart.Title.Text)
				{

					if (lastValueIndex != valueIndex)
					{

							BaseChart.Chart.Footer.Visible = true;

							ClearColorBar(valueIndex, s);
									
							var Serie = BaseChart.Chart.Series[BaseChart.Chart.Series.IndexOf(s)];
							Bar bar = (Bar)Serie;
							bar[valueIndex].Color = bar[valueIndex].Color.AddLuminosity(-0.2);

							BaseChart.Chart.Footer.Text = "Year: " + bar[valueIndex].Label + " | Items sale: " + bar[valueIndex].Y;
							lastValueIndex = valueIndex;

					}
					else { ClearColorBar(valueIndex, s); BaseChart.Chart.Footer.Visible = false; lastValueIndex = -1; }

				}

			}

			// Recupera los colores originales de las barras
			private void ClearColorBar(int valueIndex, Series s)
			{

					var Serie = BaseChart.Chart.Series[BaseChart.Chart.Series.IndexOf(s)];
					Bar bar = (Bar)Serie;
					for (int i = 0; i < bar.Labels.Count; i++)
					{
						bar[i].Color = var.GetPaletteBasic[0];
					}

			}

			// Permite eliminar el evento de la tool "DataPointSelection"
			public void RemoveEvent()
			{

					BaseChart.Chart.ClickSeries -= Chart_ClickSeries;

			}

	}

}
