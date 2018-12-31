using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;

namespace XamControls.Charts.Standard
{
    public class MultiplePiesChartFeatures
    {

		private Pie pie1;
		private Pie pie2;
		private Pie pie3;
		private Pie pie4;
		private Variables.Variables var;
		private ChartView BaseChart;

		public MultiplePiesChartFeatures(ChartView BaseChart)
		{

			pie1 = new Pie();
			pie2 = new Pie();
			pie3 = new Pie();
			pie4 = new Pie();
			var = new Variables.Variables();
			this.BaseChart = BaseChart;
			Pie[] multiPie = new Pie[4] { pie1, pie2, pie3, pie4 };

			BaseChart.Chart.Header.Text = "Objects in different house";
			BaseChart.Chart.Legend.Visible = true;
			BaseChart.Chart.Panel.MarginLeft = 3;

			// Añadir todos los "pie" al Chart
			for (int i = 0; i < 4; i++) { CrearPie(multiPie[i], i); }

			// Themes Marks
			Themes.AplicarMarksTheme1(BaseChart);
			for(int i = 0; i < BaseChart.Chart.Series.Count; i++) { BaseChart.Chart.Series[i].Marks.Style = MarksStyles.Label; BaseChart.Chart.Series[i].Marks.Font.Size = 12; }
			pie2.RotationAngle = 25;
			pie4.RotationAngle = 25;

        }

		private void CrearPie(Pie pie, int position)
		{

			double[] arrayValues;

			BaseChart.Chart.Series.Add(pie);

			pie.MultiPie = MultiPies.Automatic;
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                pie.CustomXRadius = (App.ScreenWidth / 2) - (App.ScreenWidth / 5);
                pie.CustomYRadius = (App.ScreenHeight / 2) - (App.ScreenHeight / 3);
            }
            else
            {
                pie.CustomXRadius = (App.ScreenWidth / 2) - (App.ScreenWidth / 3);
                pie.CustomYRadius = (App.ScreenHeight / 2) - (App.ScreenHeight / 2.6) ;
            }
            pie.MarksPie.InsideSlice = true;
			pie.Chart.Zoom.Allow = false;
			pie.Chart.Panning.Allow = ScrollModes.None;
			pie.MultiPie = MultiPies.Automatic;
			pie.AutoCircleResize = true;
			pie.RecalcOptions = RecalcOptions.OnModify;
			pie.DefaultNullValue = 0;
			pie.AutoPenColor = false;
			pie.DarkPen = false;
			pie.Pen.Width = 3;
			pie.Pen.Style = DashStyle.Solid;
			pie.Pen.Visible = true;
			pie.Pen.Color = Color.White;
			pie.DefaultNullValue = 0;
			pie.VertAxis = VerticalAxis.Both;
			pie.HorizAxis = HorizontalAxis.Both;
            pie.UniqueCustomRadius = true;

			// Encuentra el array con los valores que debe usar para cada pie
			switch (position) {

				case 0:
					arrayValues = var.GetValorMultiPie1;
					break;
				case 1:
					arrayValues = var.GetValorMultiPie2;
					break;
				case 2:
					arrayValues = var.GetValorMultiPie3;
					break;
				default:
					arrayValues = var.GetValorMultiPie4;
					break;
			}
						
			for (int i = 0; i < 3; i++)
			{
				if (arrayValues[i] != 0) { pie.Add(position, arrayValues[i], var.GetValorMultiPieItems[i], var.GetPaletteBasic[i]); };
			}

			pie.Title = "House " + (position + 1);
			MarksAplicar(pie);

		}

		// Acción que aplica una series de propiedades a los "Marks"
		private void MarksAplicar(Pie pie)
		{

			pie.Marks.Pen.Visible = false;
			pie.Marks.FollowSeriesColor = false;
			pie.Marks.Style = MarksStyles.Percent;
			pie.AutoCircleResize = false;
			pie.Marks.Brush.Transparency = 100;
			pie.MarksPie.VertCenter = true;
			pie.Marks.Transparent = true;
			pie.Marks.Frame.Transparency = 100;
            if (App.ScreenWidth < 600) pie.Marks.Font.Size = 15;
            else pie.Marks.Font.Size = 18;

			pie.MarksPie.InsideSlice = true;
			pie.MarksPie.LegSize = 20;
			pie.MarksPie.VertCenter = true;

		}

	}

}
