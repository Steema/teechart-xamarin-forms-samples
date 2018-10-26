using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Charts.Pro
{
    public class Point_FigureChart
    {

				private PointFigure pointFigure;

				public Point_FigureChart(ChartView BaseChart)
				{

						pointFigure = new PointFigure();
						pointFigure.FillSampleValues(50);
						BaseChart.Chart.Series.Add(pointFigure);
						BaseChart.Chart.Title.Text = "Point and Figure";
			
						pointFigure.BoxSize = 1;
						pointFigure.ReversalAmount = 1;
						pointFigure.BoxType = CustomTimeOHLC.BoxTypes.Standard;
						pointFigure.ShowMonths = true;
						pointFigure.Marks.Visible = true;
						pointFigure.MonthFont.Size = 18;
						pointFigure.ClickableLine = false;


						pointFigure.Marks.Font.Size = 20;
					
						BaseChart.Chart.Axes.Left.Visible = true;
						BaseChart.Chart.Axes.Bottom.Visible = false;
						BaseChart.Chart.Axes.Visible = true;
						BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue);
						BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
						BaseChart.Chart.Panel.MarginRight = 5;
						BaseChart.Chart.Panel.Left = 0;
						BaseChart.Chart.Axes.Bottom.Grid.Visible = false;
						BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
						BaseChart.Chart.Axes.Left.Ticks.Visible = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Left.MinorTicks.Visible = false;
						BaseChart.Chart.Axes.Left.Increment = 2;
						BaseChart.Chart.Axes.Left.Grid.Visible = true;
						BaseChart.Chart.Legend.Visible = false;

						BaseChart.Chart.Axes.Left.Title.Visible = false;
						BaseChart.Chart.Axes.Bottom.Title.Visible = false;

				}

    }
}
