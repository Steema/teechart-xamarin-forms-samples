using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using Xamarin.Forms;
using XamControls.Variables;
using Steema.TeeChart.Drawing;
using XamControls.Services.Gesture.Swipe.Views;

namespace XamControls.Charts.Calendar
{
	public partial class SpecialDatesChart
	{

		private Steema.TeeChart.Styles.Calendar calendar;
		private ChartView BaseChart;
		private Services.Gesture.Swipe.SwipeGesture swipeGesture;
		private LabelSwipe labelHeader;

		public SpecialDatesChart(ChartView BaseChart, Label label)
		{

			calendar = new Steema.TeeChart.Styles.Calendar();
			this.BaseChart = BaseChart;
			labelHeader = label as LabelSwipe;
			swipeGesture = new Services.Gesture.Swipe.SwipeGesture(labelHeader);

			labelHeader.Text = DateTime.Today.ToShortDateString();

			BaseChart.Chart.Header.TextAlign = TextAlignment.End;
			BaseChart.Chart.Header.Visible = false;
			labelHeader.TextColor = Color.FromRgb(170, 100, 100);
			BaseChart.Chart.Header.Text = "SpecialCalendar";

			BaseChart.Chart.SubHeader.Visible = true;
			BaseChart.Chart.SubHeader.Text = "Hola";
			BaseChart.Chart.SubHeader.Font.Size = 15;
			BaseChart.Chart.SubHeader.Transparency = 100;

			calendar.FillSampleValues();
			BaseChart.Chart.Series.Add(calendar);
			calendar.PreviousMonthButton.Visible = false;
			calendar.NextMonthButton.Visible = false;
			calendar.Trailing.Color = Color.FromRgb(200, 200, 200);
			calendar.Trailing.Font.Size = 14;
			calendar.Today.Color = Color.FromRgb(255, 240, 240);
			calendar.Today.Font.Color = Color.Black;
			calendar.Today.Font.Size = 14;
			calendar.Today.BorderRound = 90;
			calendar.WeekDays.Font.Size = 15;
			calendar.WeekDays.Font.Color = Color.FromRgb(180, 100, 100);
			calendar.WeekDays.TextAlign = TextAlignment.Start;
			calendar.WeekDays.Pen.Width = 1;
			calendar.WeekDays.UpperCase = true;
			calendar.Days.Font.Size = 14;
			calendar.Days.TextAlign = TextAlignment.Start;
			calendar.WeekDays.Color = Color.FromRgb(250, 230, 230);
			calendar.Sunday.Color = Color.Red;
			calendar.Sunday.Font.Size = 16;
			calendar.Sunday.Font.Color = Color.White;
			calendar.Sunday.ShapeStyle = TextShapeStyle.Rectangle;
			//calendar.Sunday.Brush.Style = HatchStyle.DiagonalBrick;
			//calendar.Sunday.Brush.ForegroundColor = Color.Green;
			//calendar.Sunday.Brush.Color = Color.Red;
			//calendar.Sunday.Brush.Visible = true;
			//calendar.Sunday.Brush.Solid = false;
			calendar.Sunday.Color = Color.FromRgb(235, 160, 160);
			calendar.Sunday.Gradient.Visible = false;
			calendar.Sunday.Pen.Visible = false;
			calendar.Months.Visible = false;
			calendar.Pen.Visible = true;
			calendar.Pen.Width = 3;
			calendar.Pen.Style = DashStyle.DashDot;
			calendar.Pen.DashCap = PenLineCap.Round;
			calendar.Pen.Color = Color.FromRgb(200, 130, 130);

			BaseChart.Chart.ClickSeries += Chart_ClickSeries;
            //calendar.BeforeDrawValues += calendar_BeforeDrawValues;

            NextBackButtonsUpdate();


        }

		private void Chart_ClickSeries(object sender, Series s, int valueIndex, Steema.TeeChart.Drawing.MouseEventArgs e)
		{

			var chart = sender as Chart;

			calendar.SetCell(e.X, e.Y);
			labelHeader.Text = calendar.Date.ToShortDateString();

		}


		private void calendar_BeforeDrawValues(object sender, Steema.TeeChart.Drawing.Graphics3D g)
		{

				var item = sender as Steema.TeeChart.Styles.Calendar;

				Rectangle rectangle = item.RectCell(1, 1);

				g.Rectangle(rectangle);

		}

        // Botones que permiten moverse entre los meses
        private void NextBackButtonsUpdate()
        {

            var backButton = ((labelHeader.Parent as Grid).Children[1] as Button);
            var nextButton = ((labelHeader.Parent as Grid).Children[2] as Button);

            backButton.Clicked += BackButton_Clicked;
            nextButton.Clicked += NextButton_Clicked;

        }

        // Permite ir al siguiente mes - nextButton
        private void NextButton_Clicked(object sender, EventArgs e)
        {

            calendar.NextMonth();
            labelHeader.Text = calendar.Date.ToShortDateString();

        }

        // Vuelve un mes atras - backButton
        private void BackButton_Clicked(object sender, EventArgs e)
        {

            calendar.PreviousMonth();
            labelHeader.Text = calendar.Date.ToShortDateString();

        }

    }
}
