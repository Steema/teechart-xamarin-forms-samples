using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Languages;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class SlopeProFunctionChart : SeriesModel
    {

				private Area area;
				private Line line;
				private SlopeFunction slopeFunction;
				private Variables.Variables var;

				public SlopeProFunctionChart(ChartView BaseChart)
				{

						area = new Area();
						line = new Line();
						slopeFunction = new SlopeFunction();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Slope";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Visible = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Left.Increment = 30;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Axes.Right.Visible = true;
						BaseChart.Chart.Axes.Right.AxisPen.Visible = true;
						BaseChart.Chart.Axes.Right.Automatic = true;
						BaseChart.Chart.Axes.Right.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Right.Increment = 20;

						FillSampleValues(area, 15);
						area.AreaLines.Visible = true;
						area.AreaLines.Color = var.GetPaletteBasic[0];
						area.Color = var.GetPaletteBasic[0];
						area.LinePen.Color = var.GetPaletteBasic[0].AddLuminosity(-0.2);
						area.LinePen.Width = 2;
						area.Title = "Area";
						area.HorizAxis = HorizontalAxis.Bottom;
						area.VertAxis = VerticalAxis.Left;

						line.DataSource = area;
						line.Function = slopeFunction;
						line.Title = "Line";
						line.Color = var.GetPaletteBasic[1];
						line.LinePen.Width = 3;
						line.LinePen.EndCap = PenLineCap.Round;
						line.HorizAxis = HorizontalAxis.Bottom;
						line.VertAxis = VerticalAxis.Right;

						BaseChart.Chart.Series.Add(area);
						BaseChart.Chart.Series.Add(line);

				}

    }
}
