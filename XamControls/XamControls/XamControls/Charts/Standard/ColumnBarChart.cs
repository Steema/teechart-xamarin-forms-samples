using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using XamControls.Styles;
using System.Drawing;
using XamControls.Tools;
using System.Threading.Tasks;

namespace XamControls.Charts.Standard
{
    public class ColumnBarChart
    {

				private Bar bar1;
				private Bar bar2;
				private Bar bar3;
				private Variables.Variables var;
				private ChartView BaseChart;
				
				public ColumnBarChart(ChartView BaseChart)
				{
						bar1 = new Bar();
						bar2 = new Bar();
						bar3 = new Bar();
						var = new Variables.Variables();
						this.BaseChart = BaseChart;

						BaseChart.Chart.Legend.Visible = true;
						BaseChart.Chart.Header.Text = "Civil status of people in the bus";
						BaseChart.Chart.Series.Add(bar1);
						BaseChart.Chart.Series.Add(bar2);
						BaseChart.Chart.Series.Add(bar3);

						bar1.Colors = new ColorList { var.GetPaletteBasic[0] };
						bar1.SeriesColor = var.GetPaletteBasic[0];
						bar1.Chart.Zoom.Allow = false;
						bar1.Chart.Panning.Allow = ScrollModes.None;
						bar1.RecalcOptions = RecalcOptions.OnModify;
						bar1.Title = "Bus 1";
						bar1.DefaultNullValue = 0;
						for (int i = 0; i < var.GetValorColumn1.Length; i++) { bar1.Add(var.GetValorColumn1[i], var.GetValorColumnX[i]); }
						bar1.MarksOnBar = true;
						bar1.Marks.Style = MarksStyles.Value;
                        bar1.BarWidthPercent = 80;
						bar1.VertAxis = VerticalAxis.Both;
						bar1.HorizAxis = HorizontalAxis.Both;

						bar2.Colors = new ColorList { var.GetPaletteBasic[1] };
						bar2.SeriesColor = var.GetPaletteBasic[1];
						bar2.Chart.Zoom.Allow = false;
						bar2.Chart.Panning.Allow = ScrollModes.None;
						bar2.RecalcOptions = RecalcOptions.OnModify;
						bar2.Title = "Bus 2";
						bar2.DefaultNullValue = 0;
						for (int i = 0; i < var.GetValorColumn2.Length; i++) { bar2.Add(var.GetValorColumn2[i], var.GetValorColumnX[i]); }
						bar2.ZOrder = 0;
						bar2.MarksOnBar = true;
						bar2.Marks.Style = MarksStyles.Value;
						bar2.BarWidthPercent = 80;
						bar2.VertAxis = VerticalAxis.Both;
						bar2.HorizAxis = HorizontalAxis.Both;

						bar3.Colors = new ColorList { var.GetPaletteBasic[2] };
						bar3.SeriesColor = var.GetPaletteBasic[2];
						bar3.Chart.Zoom.Allow = false;
						bar3.Chart.Panning.Allow = ScrollModes.None;
						bar3.RecalcOptions = RecalcOptions.OnModify;
						bar3.Title = "Bus 3";
						bar3.DefaultNullValue = 0;
						for (int i = 0; i < var.GetValorColumn3.Length; i++) { bar3.Add(var.GetValorColumn3[i], var.GetValorColumnX[i]); }
						bar3.MarksOnBar = true;
						bar3.Marks.Style = MarksStyles.Value;
                        bar3.BarWidthPercent = 80;
                        bar3.VertAxis = VerticalAxis.Both;
						bar3.HorizAxis = HorizontalAxis.Both;

						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue + 1);
						BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
						BaseChart.Chart.Axes.Left.Title = null;
						BaseChart.Chart.Axes.Bottom.Title = null;
						BaseChart.Chart.Axes.Left.Visible = false;
						BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
						BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
						BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
						BaseChart.Chart.Axes.Left.Increment = 2;
						BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
						//BaseChart.Chart.ClickSeries += Chart_ClickSeries;
						BaseChart.Chart.Axes.Left.Labels.CustomSize = 0;

						// Themes Marks
						Themes.AplicarMarksTheme1(BaseChart);

						BaseChart.Chart.Series[0].Marks.Font.Size = 14;
						BaseChart.Chart.Series[1].Marks.Font.Size = 14;
						BaseChart.Chart.Series[2].Marks.Font.Size = 14;

						bar1.Marks.Pen.Visible = false;
						bar2.Marks.Pen.Visible = false;
						bar3.Marks.Pen.Visible = false;

						BaseChart.Chart.Series[0].Marks.TextAlign = Xamarin.Forms.TextAlignment.Center;
						BaseChart.Chart.Series[0].Marks.AutoSize = true;
						BaseChart.Chart.Series[0].Marks.Color = Color.Transparent;
						BaseChart.Chart.Series[1].Marks.TextAlign = Xamarin.Forms.TextAlignment.Center;
						BaseChart.Chart.Series[1].Marks.AutoSize = true;
						BaseChart.Chart.Series[1].Marks.Color = Color.Transparent;
						BaseChart.Chart.Series[2].Marks.TextAlign = Xamarin.Forms.TextAlignment.Center;
						BaseChart.Chart.Series[2].Marks.AutoSize = true;
						BaseChart.Chart.Series[2].Marks.Color = Color.Transparent;
						BaseChart.Chart.Panel.MarginLeft = 5;

                        //BaseChart.Chart.AfterDraw += Chart_AfterDrawAsync;


                }

				// Evento que modifica el color de la barra cuando haces "click"
				public void Chart_ClickSeries(object sender, Series s, int valueIndex, Steema.TeeChart.Drawing.MouseEventArgs e)
				{

						// Ja es pot treure - if!= null <!-----------------------------------------------!>
						if (BaseChart.Chart.Title.Text == "Civil status of people in the bus")
						{
				
							ClearColorBar();
							/*
							int index = BaseChart.Chart.Series.IndexOf(s);
							for (int i = 0; i < s.Count; i++) { s[i].Color = var.GetPaletteBasic[index].AddLuminosity(-0.25); }
							*/
							var Serie = BaseChart.Chart.Series[BaseChart.Chart.Series.IndexOf(s)];
							Bar bar = (Bar)Serie;
							bar.Pen.Color = bar.Color.AddLuminosity(-0.3);
							bar.Pen.Width = 3;

						}

				}

				// Recupera los colores originales de las barras
				private void ClearColorBar()
				{

						for(int i = 0; i < BaseChart.Chart.Series.Count; i++) { ((Bar)BaseChart.Chart.Series[i]).Pen.Width = 1; ((Bar)BaseChart.Chart.Series[i]).Pen.Color.AddLuminosity(0.3); }

				}

		}

}
