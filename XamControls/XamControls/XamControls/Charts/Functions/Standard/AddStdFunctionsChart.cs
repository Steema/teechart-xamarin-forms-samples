using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using XamControls.Variables;
using System.Drawing;
using XamControls.Styles;

namespace XamControls.Charts.Functions.Standard
{
    public class AddStdFunctionsChart : SeriesModel
    {

		private Steema.TeeChart.Functions.Add addFunction;
		private Bar bar;
		private Line theAddLine;
		private Variables.Variables var;

		public AddStdFunctionsChart(ChartView BaseChart)
		{

			addFunction = new Steema.TeeChart.Functions.Add();
			bar = new Bar();
			theAddLine = new Line();
			var = new Variables.Variables();

			BaseChart.Chart.Series.Add(bar);
			BaseChart.Chart.Series.Add(theAddLine);

			bar.Title = "Data";
			bar.SeriesColor = var.GetPaletteBasic[0];
			theAddLine.Title = "Add";
			theAddLine.LinePen.Width = 6;
			theAddLine.Color = var.GetPaletteBasic[2];
						
			for(int i = 0; i < var.GetValorStdAdd1.Length; i++)
			{

					bar.Add(i, var.GetValorStdAdd1[i]);

			}

			theAddLine.Function = addFunction;
			theAddLine.DataSource = bar;

			BaseChart.Chart.Axes.Left.SetMinMax(BaseChart.Chart.Axes.Left.MinYValue, BaseChart.Chart.Axes.Left.MaxYValue + 100);
			BaseChart.Chart.Axes.Bottom.SetMinMax(BaseChart.Chart.Axes.Bottom.MinXValue, BaseChart.Chart.Axes.Bottom.MaxXValue);
			BaseChart.Chart.Axes.Left.Increment = 500;
			BaseChart.Chart.Axes.Bottom.Labels.Visible = false;
			BaseChart.Chart.Axes.Left.Grid.Visible = false;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Header.Visible = false;

			Themes.AplicarMarksTheme1(BaseChart);
			theAddLine.Marks.Visible = true;
			theAddLine.Marks.Width += 40;
			theAddLine.Marks.DrawEvery = 2;

            ImplementiOSMarks(BaseChart.Chart);

		}


	}
}
