using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Xamarin.Forms;

namespace XamControls.Charts.Maps
{
    public class MapGISChart
    {
#if !TEE_STD
        private Map mapGSI;
			private ChartView BaseChart;
			private Variables.Variables var;

			public MapGISChart(ChartView BaseChart)
			{

					mapGSI = new Map();
					this.BaseChart = BaseChart;
					var = new Variables.Variables();

					BaseChart.Chart.Series.Add(mapGSI);
					mapGSI.FillSampleValues(10);

					mapGSI.VertAxis = VerticalAxis.Both;
					mapGSI.HorizAxis = HorizontalAxis.Both;
					mapGSI.Title = "Map GIS";
					mapGSI.UsePalette = false;
					mapGSI.StartColor = var.GetPaletteBasic[0].AddLuminosity(0.3);
					mapGSI.EndColor = var.GetPaletteBasic[0].AddLuminosity(-0.1);
					mapGSI.Marks.AutoSize = true;
					mapGSI.MapMarks.AutoSize = false;
					mapGSI.MapMarks.UpperCase = true;
					mapGSI.MapMarks.Centroid = true;
					mapGSI.Marks.Font.Size += 8;
					mapGSI.Marks.Font.Bold = true;
					mapGSI.Marks.TailStyle = MarksTail.None;

					BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 2, BaseChart.Chart.Axes.Left.MaxYValue + 2);
					BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue - 1, BaseChart.Chart.Axes.Bottom.MaxXValue + 1);

                    BaseChart.Chart.Axes.Left.Transparency = 0;
                    BaseChart.Chart.Axes.Bottom.Transparency = 0;
                    BaseChart.Chart.Legend.Visible = false;
                    BaseChart.Chart.Axes.Left.MinorTicks.Transparency = 100;
                    BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
                    BaseChart.Chart.Title.Text = "";

					ExisteMapToolbarItem();

			}

			// Mira si existe el item "changeMap" en el toolbar y luego lo elimina
			private void ExisteMapToolbarItem()
			{

					if (BaseChart.Parent != null)
					{
						var page = (((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage);
						if (page.ToolbarItems.Count > 1) { page.ToolbarItems.RemoveAt(0); }
					}

			}
#endif
    }
}
