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
    public class PolarChart
    {
#if !TEE_STD
        private Polar polar1;
        private Polar polar2;
		private Variables.Variables var;
		private ChartView BaseChart;


		public PolarChart(ChartView BaseChart)
		{

				this.BaseChart = BaseChart;
				polar1 = new Polar();
                polar2 = new Polar();
				var = new Variables.Variables();

                for(int i = 0; i < var.GetValorPolar1.Length/2; i++) { polar1.Add(var.GetValorPolar1[i, 0], var.GetValorPolar1[i, 1]); }
                for (int i = 0; i < var.GetValorPolar2.Length/2; i++) { polar2.Add(var.GetValorPolar2[i, 0], var.GetValorPolar2[i, 1]); }

                polar1.Color = var.GetPaletteBasic[0];
                polar2.Color = var.GetPaletteBasic[1];
                polar1.Circled = true;
                polar2.Circled = true;
                polar1.CloseCircle = true;
                polar2.CloseCircle = true;
                polar1.Pen.Color = Color.White;
                polar2.Pen.Color = Color.White;
                polar1.CircleLabels = true;
                polar1.CircleLabelsInside = false;
                polar2.CircleLabels = true;
                polar2.CircleLabelsInside = false;

                BaseChart.Chart.Series.Add(polar1);
                BaseChart.Chart.Series.Add(polar2);

                BaseChart.Chart.Title.Text = "Polar";
                BaseChart.Chart.Axes.Left.Visible = true;
                BaseChart.Chart.Axes.Left.MinorTicks.Transparency = 100;
                BaseChart.Chart.Axes.Bottom.MinorTicks.Transparency = 100;
                BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue - 100, BaseChart.Chart.Axes.Left.MaxYValue + 100);
                BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinYValue - 100, BaseChart.Chart.Axes.Bottom.MaxXValue + 100);

                BaseChart.Chart.Axes.Bottom.Automatic = true;
                BaseChart.Chart.Axes.Left.Labels.ValueFormat = "0";
                BaseChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
                BaseChart.Chart.Axes.Bottom.Increment = 1;
                BaseChart.Chart.Axes.Left.Increment = 100;
                BaseChart.Chart.Axes.Left.Visible = true;
                BaseChart.Chart.Axes.Left.Title = null;
                BaseChart.Chart.Axes.Bottom.Title = null;
                BaseChart.Chart.Axes.Left.AxisPen.Visible = false;
                BaseChart.Chart.Axes.Left.Ticks.Visible = false;
                BaseChart.Chart.Axes.Left.Grid.Visible = true;
                BaseChart.Chart.Legend.LegendStyle = LegendStyles.Series;
                BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
                BaseChart.Chart.Panel.MarginLeft = 5;
                BaseChart.Chart.Axes.Bottom.AxisPen.Visible = true;
                BaseChart.Chart.Axes.Bottom.Visible = true;
                BaseChart.Chart.Axes.Left.Increment = 100;

                polar1.AngleIncrement = 30;
                polar2.AngleIncrement = 30;
                polar1.CircleLabelsFont.Size += 2;
                polar2.CircleLabelsFont.Size += 2;
                polar1.RadiusIncrement = 300;
                polar2.RadiusIncrement = 300;

        }	
#endif
	}

}

