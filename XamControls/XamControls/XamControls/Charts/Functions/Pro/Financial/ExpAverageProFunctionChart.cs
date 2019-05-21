using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class ExpAverageProFunctionChart
    {
        #if !TEE_STD
				private Line line1;
				private Line line2;
				private ExpAverage expAverage;
				private Variables.Variables var;

				public ExpAverageProFunctionChart(ChartView BaseChart)
				{

						line1 = new Line();
						line2 = new Line();
						expAverage = new ExpAverage();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Exponential Average";

						FillSampleValues(line1);
						line1.Title = "Data Source";
						line1.Color = var.GetPaletteBasic[0];
						line1.XValues.DataMember = "X";
						line1.XValues.Order = ValueListOrder.Ascending;
						line1.YValues.DataMember = "Y";
						line1.Pointer.Color = var.GetPaletteBasic[0];
						line1.Pointer.Visible = false;
						line1.LinePen.Width = 3;

						line2.Function = expAverage;
						line2.DataSource = line1;
						line2.Color = var.GetPaletteBasic[1];
						line2.Title = "Exp. Average";
						line2.XValues.Order = ValueListOrder.Ascending;
						line2.Pointer.Color = var.GetPaletteBasic[1];
						line2.Pointer.Visible = true;
						line2.LinePen.Width = 3;

						expAverage.Period = 3D;
						expAverage.Weight = 0.1;

						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Legend.Visible = true;

						BaseChart.Chart.Axes.Left.Increment = 50;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;

						BaseChart.Chart.Series.Add(line1);
						BaseChart.Chart.Series.Add(line2);
				
				}

				// FillSampleValues Propio
				private void FillSampleValues(Line line)
				{

					bool correcte = false;

					while (!correcte)
					{

						line1.FillSampleValues(25);
						int i = 0;
						bool trobat = false;

						while (i < line.mandatory.Count && !trobat)
						{

							if (line.mandatory[i] > 800) { trobat = true; }
							i++;

						}

						if (!trobat) { correcte = true; }

					}

				}
#endif
		}
}
