using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Charts.Organizational
{
    public class CustomOrgChart
    {

				private OrgSeries organizationalChart;

				public CustomOrgChart(ChartView BaseChart)
				{

					organizationalChart = new OrgSeries();
					//organizationalChart.FillSampleValues();
					BaseChart.Chart.Series.Add(organizationalChart);

					BaseChart.HorizontalOptions = LayoutOptions.FillAndExpand;
					BaseChart.VerticalOptions = LayoutOptions.FillAndExpand;
					BaseChart.Chart.Header.Transparency = 100;
					BaseChart.Chart.Header.Font.Size = 60;
					BaseChart.Chart.Panning.Active = true;
					BaseChart.Chart.Panning.Allow = ScrollModes.Both;
					BaseChart.Chart.Zoom.Active = true;
					BaseChart.Chart.Zoom.Allow = true;
					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 1, BaseChart.Chart.Axes.Left.MaxYValue + 1);
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue - 1, BaseChart.Chart.Axes.Bottom.MaxXValue + 1);

					organizationalChart.Add(-1, 0, "Mike Young");
					organizationalChart.Add(0, 1, "Jay");
					organizationalChart.Add(1, 2, "Molt");
					organizationalChart.Add(2, 3, "Ferran");
					organizationalChart.Add(0, 4, "Mark");
					organizationalChart.Add(3, 5, "Gold");
					organizationalChart.Add(3, 6, "Rick");
					organizationalChart.Add(0, 7, "Chris");
					organizationalChart.Add(4, 8, "Gary");
					organizationalChart.Add(5, 9, "Michael");
					organizationalChart.Add(5, 10, "Marta");
					organizationalChart.Add(6, 11, "Ryn");
					organizationalChart.Add(7, 12, "Xayah");
					organizationalChart.Add(7, 13, "Jonn");

					organizationalChart.ItemSpacing = new Spacing() { Vertical = 70, Horizontal = 30 };
					organizationalChart.Pen.Width = 5;

					NodeTemplates();

				}

				// Aplica las propiedades a todos los nodos
				private void NodeTemplates()
				{

					for (int i = 0; i < organizationalChart.Items.Count; i++)
					{

						organizationalChart.Items[i].Format.Font.Size = 18;
						organizationalChart.Items[i].Format.TextAlign = TextAlignment.Center;
						organizationalChart.Items[i].Format.AutoSize = false;
						if (i == 0) { organizationalChart.Items[i].Format.Width = 230; }
						else { organizationalChart.Items[i].Format.Width = 200; }
						organizationalChart.Items[i].Format.Height = 60;
						if (i == 1 || i == 2) { organizationalChart.Items[i].Format.BorderRound = 180; }
						//organizationalChart.LineStyle = OrgLineStyle.lsSquared;

					}

				}

		}
}
