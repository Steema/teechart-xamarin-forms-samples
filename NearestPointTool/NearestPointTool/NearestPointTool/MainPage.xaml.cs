using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;

namespace NearestPointTool
{
	public partial class MainPage : ContentPage
	{

		ChartView LineChart = new ChartView();
		public MainPage()
		{
			InitializeComponent();

			/* Create ChartView by code at ContentPage */

			/* cursor movement buttons */
			Button bBack = new Button();
			Button bFwd = new Button();

			bFwd.Text = "forward";
			bBack.Text = "back";

			bBack.HeightRequest = 100;
			bFwd.HeightRequest = 100;
			bBack.WidthRequest = 200;
			bFwd.WidthRequest = 200;

			bBack.Clicked += OnBackButtonClicked;
			bFwd.Clicked += OnFwdButtonClicked;

			LineChart.Chart.BeforeDraw += ChartBeforeDraw;
			LineChart.Chart.AfterDraw += ChartAfterDraw;

			LineChart.Chart.AutoRepaint = true;

			LineChart.WidthRequest = 400;
			LineChart.HeightRequest = 300;

			Content = new StackLayout
			{
				Children =
									{
										new StackLayout { Orientation=StackOrientation.Horizontal, Children = { bBack, bFwd } },
										LineChart
									},
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			LineChart.Chart.Series.Add(new Line());
			double[] YValues = new double[] { 4000, 2500, 2200, 2000, 1800, 1700, 1500, 1300, 1100, 1000, 900, 850 };

			LineChart.Chart.Series[0].Add(YValues);
			(LineChart.Chart.Series[0] as Line).Marks.Visible = false;
			(LineChart.Chart.Series[0] as Line).LinePen.Width = 5;
			(LineChart.Chart.Series[0] as Line).Pointer.Visible = true;
			LineChart.Chart.Panel.Gradient.Visible = false;
			LineChart.Chart.Panel.Color = Color.White;
			LineChart.Chart.Walls.Left.Color = Color.White;
			LineChart.Chart.Walls.Bottom.Color = Color.White;
			LineChart.Chart.Walls.Back.Transparent = true;
			LineChart.Chart.Walls.Back.Pen.Color = Color.LightGray;
			LineChart.Chart.Legend.Visible = true;
			LineChart.Chart.Aspect.ColorPaletteIndex = 17;
			LineChart.Chart.Title.Text = "Pan to show the Nearest Point !";
			LineChart.Chart.Title.Alignment = TextAlignment.End;
			LineChart.Chart.Axes.Left.Increment = 500;
			LineChart.Chart.Axes.Left.AxisPen.Visible = false;
			LineChart.Chart.Axes.Bottom.AxisPen.Visible = false;
			LineChart.Chart.Panel.MarginBottom += 25;
			LineChart.Chart.Panel.MarginLeft -= 1;
			LineChart.Chart.Title.Font.Color = Color.Gray;
			LineChart.Chart.Walls.Left.Pen.Width = 1;
			LineChart.Chart.Walls.Bottom.Pen.Width = 2;
			LineChart.Chart.Walls.Left.Pen.Color = Color.LightGray;
			LineChart.Chart.Walls.Bottom.Pen.Color = Color.LightGray;
			LineChart.Chart.Aspect.View3D = false;


			Steema.TeeChart.Tools.NearestPoint NearestTool = new Steema.TeeChart.Tools.NearestPoint(LineChart.Chart);
			NearestTool.Series = LineChart.Chart.Series[0];
			NearestTool.Pen.Width = 3;
			NearestTool.Pen.Color = Color.Blue;
			NearestTool.Change += NearestTool_Change;

			LineChart.Chart.Panning.Allow = ScrollModes.None;

			if (Device.OS == TargetPlatform.Windows)
			{
				LineChart.Chart.Touch.Style = TouchStyle.FullChart; //currently required for UWP. Will be replaced.

				LineChart.Chart.Title.Text = "";
				LineChart.Chart.Walls.Back.Gradient.Visible = false;
				LineChart.Chart.Walls.Back.Color = Color.White;
				LineChart.Chart.Panel.MarginBottom -= 25;
				LineChart.Chart.Axes.Left.MinimumOffset = 5;
				LineChart.Chart.Axes.Left.MaximumOffset = 4;
			}
		}

		private void NearestTool_Change(object sender, EventArgs e)
		{
			LineChart.Chart.Title.Text = "Point Value : " + LineChart.Chart.Series[0].YValues[(sender as NearestPoint).Point].ToString();
		}

		int currentIndex = -1;
		Steema.TeeChart.Drawing.ChartBrush pBrush;

		void OnFwdButtonClicked(object sender, EventArgs e)
		{
			if (currentIndex < LineChart.Chart.Series[0].Count - 1)
			{
				currentIndex++;

				pBrush = LineChart.Chart.Series[0].bBrush;
				pBrush.Transparency = 75;

				LineChart.Chart.Invalidate();

			}
		}

		void OnBackButtonClicked(object sender, EventArgs e)
		{
			if (currentIndex > 0)
			{
				currentIndex--;

				pBrush = LineChart.Chart.Series[0].bBrush;
				pBrush.Transparency = 75;

				LineChart.Chart.Invalidate();
			}
		}

		void ChartBeforeDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
		{
			//debug
			/*
			g.Font.Size = 8;
			g.TextOut(10, 10, "repaint count: " + bCounter++.ToString());
			*/
		}

		int bCounter = 0;

		void ChartAfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
		{
			if (currentIndex != -1)
			{
				double xCenter = LineChart.Chart.Series[0].CalcXPos(currentIndex);
				double yCenter = LineChart.Chart.Series[0].CalcYPos(currentIndex);

				g.Font.Size = g.Font.Size * 1.5;
				double offSet = 0;

				g.TextOut(xCenter - offSet, yCenter - (g.Font.Size * 4), " Value: " + LineChart.Chart.Series[0].YValues[currentIndex].ToString());

				Rectangle r = new Rectangle(xCenter - 25, yCenter - 25, 50, 50);

				g.Brush = pBrush;
				g.Pen.Width = 4;
				g.Ellipse(r);
			}
		}
	}
}
