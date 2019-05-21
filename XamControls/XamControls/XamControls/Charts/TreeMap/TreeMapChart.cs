using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using XamControls.Styles;
using System.Drawing;
using XamControls.Models;

namespace XamControls.Charts.TreeMap
{
    public class TreeMapChart
    {
        #if !TEE_STD
				private Steema.TeeChart.Styles.TreeMap treeMap;
				private Variables.Variables var;
				private ChartView BaseChart;

				public TreeMapChart(ChartView BaseChart)
				{

						treeMap = new Steema.TeeChart.Styles.TreeMap();
						var = new Variables.Variables();
						this.BaseChart = BaseChart;

						treeMap.FillSampleValues(10);
						BaseChart.Chart.Series.Add(treeMap);

						treeMap.ColorStyle = TreeMapColorStyle.ByLevel;
						treeMap.MapStyle = TreeMapTiling.Slice;
						treeMap.Palette.StartColor = var.GetPaletteBasic[0].AddLuminosity(0.3);
						treeMap.Palette.MidColor = var.GetPaletteBasic[0].AddLuminosity(0.1);
						treeMap.Palette.EndColor = var.GetPaletteBasic[0].AddLuminosity(-0.40);

						BaseChart.Chart.Legend.Visible = true;
						BaseChart.Chart.Header.Text = "Civil status of people in the bus";

						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 4, BaseChart.Chart.Axes.Left.MaxYValue + 2);
						BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue - 2, BaseChart.Chart.Axes.Bottom.MaxXValue + 4);
						BaseChart.Chart.Axes.Left.Title = null;
						BaseChart.Chart.Axes.Bottom.Title = null;
						BaseChart.Chart.Axes.Left.Visible = false;
						BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
						BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
						BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
						BaseChart.Chart.Axes.Left.Increment = 2;
						BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
						BaseChart.Chart.Axes.Left.Labels.CustomSize = 0;
            BaseChart.Chart.Legend.Visible = false;
            BaseChart.Chart.Title.Text = "";

            // Themes Marks
            //Themes.AplicarMarksTheme1(BaseChart);


            BaseChart.Chart.Series[0].Marks.Font.Size = 14;

						//bar1.Marks.Pen.Visible = false;

						BaseChart.Chart.Series[0].Marks.TextAlign = Xamarin.Forms.TextAlignment.Center;
						BaseChart.Chart.Series[0].Marks.AutoSize = true;
						BaseChart.Chart.Series[0].Marks.Color = Color.Transparent;
						BaseChart.Chart.Panel.MarginLeft = 5;

				}

#endif

    }
}
