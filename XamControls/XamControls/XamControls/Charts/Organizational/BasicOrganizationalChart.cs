using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Xamarin.Forms;

namespace XamControls.Charts.Organizational
{
    public class BasicOrganizationalChart
    {
#if !TEE_STD
        private OrgSeries organizationalChart;

		public BasicOrganizationalChart(ChartView BaseChart)
		{

			organizationalChart = new OrgSeries();
			//organizationalChart.FillSampleValues();
			BaseChart.Chart.Series.Add(organizationalChart);

			BaseChart.Chart.Header.Transparency = 100;
			BaseChart.Chart.Header.Font.Size = 120;

			organizationalChart.Add(-1, 0, "Mike Young");
			organizationalChart.Add(0, 1, "Jay");
			organizationalChart.Add(0, 2, "Mark");
			organizationalChart.Add(1, 3, "Gold");
			organizationalChart.Add(1, 4, "Rick");

			organizationalChart.ItemSpacing = new Spacing() { Vertical = 70, Horizontal = 30 };
			organizationalChart.Pen.Width = 3;

			NodeTemplates();
			

		}

		// Aplica las propiedades a todos los nodos
		private void NodeTemplates()
		{

			for(int i = 0; i < organizationalChart.Items.Count; i++)
			{

				organizationalChart.Items[i].Format.Font.Size = 22;
				organizationalChart.Items[i].Format.TextAlign = TextAlignment.Center;
				organizationalChart.Items[i].Format.AutoSize = true;
				
			}

		}
#endif
    }
}
