using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using XamControls.Styles;

namespace XamControls.Charts.Pro
{
    public class RenkoChart
    {

			private Renko renko;
			private Candle candle;
			private Axis customLeftRenko;
			private Axis customBottomRenko;
			private ChartView BaseChart;
            private ChartView AuxChartView;

			public RenkoChart(ChartView BaseChart)
			{

                AuxChartView = new ChartView();
				candle = new Candle();
				renko = new Renko();
				this.BaseChart = BaseChart;
	
				candle.FillSampleValues(12);

                BaseChart.Chart.Title.Text = "Renko";

				BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
				BaseChart.Chart.Axes.Left.Visible = true;
				BaseChart.Chart.Axes.Bottom.Visible = true;
				BaseChart.Chart.Series.Add(renko);
				BaseChart.Chart.Series.Add(candle);

				//renko.Clear();
				for (int i = 0; i < candle.Count; i++)
					renko.Add(candle.CloseValues[i]);

				// box size set to 2
				//renko.BoxSize = 5;
				//renko.Pointer.Style = PointerStyles.Rectangle;
				//renko.Title = "Renko (Close values)";

				candle.Title = "Trading Data";

				candle.HorizAxis = HorizontalAxis.Bottom;
				candle.VertAxis = VerticalAxis.Left;

				BaseChart.Chart.Axes.Left.Title.Visible = false;
				BaseChart.Chart.Axes.Bottom.Title.Visible = false;
				BaseChart.Chart.Axes.Bottom.Labels.Visible = true;
                BaseChart.Chart.Axes.Left.Labels.Visible = true;

				BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
				BaseChart.Chart.Axes.Bottom.Visible = true;
				BaseChart.Chart.Axes.Bottom.Ticks.Visible = false;
				BaseChart.Chart.Axes.Left.Increment = 10;

				BaseChart.Chart.Panel.Left = 0;

				BaseChart.Chart.Axes.Bottom.RelativePosition = 53;
				BaseChart.Chart.Axes.Left.EndPosition = 47;

				customLeftRenko = CreateAxis();
				customBottomRenko = CreateAxis();
				//Themes.UpdateAxes(customLeftRenko, customBottomRenko);

				//BaseChart.Chart.Axes.Custom.Add(customLeftRenko);
				//BaseChart.Chart.Axes.Custom.Add(customBottomRenko);

				customLeftRenko.Horizontal = false;
				customLeftRenko.StartPosition = 53;
				customLeftRenko.EndPosition = 100;
				customLeftRenko.Grid = BaseChart.Chart.Axes.Left.Grid;
				customLeftRenko.AxisPen.Visible = true;
				customLeftRenko.Increment = 10;
				customLeftRenko.AxisPen.Color = customLeftRenko.AxisPen.GetColor().AddLuminosity(-0.2);
				customLeftRenko.Ticks.Transparency = 100;

				customBottomRenko.Horizontal = true;
				customBottomRenko.StartPosition = 0;
				customBottomRenko.EndPosition = 100;
				customBottomRenko.RelativePosition = 0;
				customBottomRenko.AxisPen.Visible = true;
				customBottomRenko.Ticks.Visible = false;
				customBottomRenko.AxisPen.Color = customBottomRenko.AxisPen.GetColor().AddLuminosity(-0.2);

				//renko.HorizAxis = HorizontalAxis.Bottom;
				//renko.VertAxis = VerticalAxis.Custom;
				//renko.CustomHorizAxis = customBottomRenko;
				//renko.CustomVertAxis = customLeftRenko;

				BaseChart.Chart.Axes.Bottom.Automatic = true;
				BaseChart.Chart.Axes.Bottom.AutomaticMaximum = true;
				BaseChart.Chart.Axes.Bottom.AutomaticMinimum = true;
				BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);

				customLeftRenko.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
				customBottomRenko.Automatic = true;
				customBottomRenko.AutomaticMaximum = true;
				customBottomRenko.AutomaticMinimum = true;



			}

			private Axis CreateAxis()
			{

				Axis axis = new Axis();

				axis.Visible = true;
				axis.AxisPen.Visible = true;
				axis.AxisPen.Width = 1;

				return axis;

			}

		    // Elimina las custom axis
		    public void RemoveSeriesSettings()
		    {

				BaseChart.Chart.Axes.Custom.RemoveAll();
                BaseChart.Chart.Series.RemoveAllSeries();

            }

    }
}
