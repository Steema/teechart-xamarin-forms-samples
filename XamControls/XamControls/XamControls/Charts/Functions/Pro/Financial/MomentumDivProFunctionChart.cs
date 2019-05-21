using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class MomentumDivProFunctionChart : SeriesModel
    {
        #if !TEE_STD
        private Line line1;
				private Line line2;
				private MomentumDivision momentumDivision;
				private Variables.Variables var;
				private Axis leftAxis;

				public MomentumDivProFunctionChart(ChartView BaseChart)
				{

						line1 = new Line();
						line2 = new Line();
						momentumDivision = new MomentumDivision();
						var = new Variables.Variables();
						leftAxis = new Axis();

						Themes.DoubleAxisChart(BaseChart);
						Themes.CustomAxisLeft(leftAxis);

						BaseChart.Chart.Title.Text = "Momentum";
						leftAxis.Automatic = true;
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Custom.Add(leftAxis);

						FillSampleValues(line1, 30, 600);
						line1.Color = var.GetPaletteBasic[0];
						line1.LinePen.Width = 3;
						line1.Pointer.Visible = true;
						line1.Title = "Data Source";
						line1.HorizAxis = HorizontalAxis.Bottom;
						line1.VertAxis = VerticalAxis.Left;

						line2.LinePen.Width = 3;
						line2.DataSource = line1;
						line2.Function = momentumDivision;
						line2.Title = "Momentum Divison";
						line2.HorizAxis = HorizontalAxis.Bottom;
						line2.VertAxis = VerticalAxis.Custom;
						line2.CustomVertAxis = leftAxis;
						line2.Color = var.GetPaletteBasic[1];

						momentumDivision.Period = 10;

						BaseChart.Chart.Series.Add(line1);
						BaseChart.Chart.Series.Add(line2);

				}
    #endif
    }
}
