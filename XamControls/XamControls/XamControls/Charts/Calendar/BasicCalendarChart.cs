using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using Xamarin.Forms;
using XamControls.Variables;
using Steema.TeeChart.Drawing;
using XamControls.Services.Gesture.Swipe;
using XamControls.ViewModels.Base;
using XamControls.Services.Gesture.Swipe.Views;

namespace XamControls.Charts.Calendar
{
	public class BasicCalendarChart
    {

		private Steema.TeeChart.Styles.Calendar calendar;
		private SwipeGesture swipeGesture;
		private LabelSwipe labelHeader;
        private ChartView BaseChart;
				

		public BasicCalendarChart(ChartViewRender BaseChart, Label label)
		{

			calendar = new Steema.TeeChart.Styles.Calendar();
			swipeGesture = new SwipeGesture(label);
			labelHeader = (label as LabelSwipe);
			labelHeader.GetChart = BaseChart.Chart;
            this.BaseChart = BaseChart;
    
			labelHeader.Text = MyConvert.NumericMonthToString(calendar.Date.Month) + ", " + calendar.Date.Year.ToString();
			BaseChart.Chart.Header.Font.Size = 25;
			labelHeader.TextColor = Color.FromRgb(70, 70, 70);
			BaseChart.Chart.Header.Text = "BasicCalendar";
			BaseChart.Chart.Header.Visible = false;

			calendar.FillSampleValues();
			BaseChart.Chart.Series.Add(calendar);
			calendar.PreviousMonthButton.Visible = false;
			calendar.NextMonthButton.Visible = false;
			calendar.Trailing.Color = Color.FromRgb(200, 200, 200);
			calendar.Trailing.Font.Size = 14;
			calendar.Today.Color = Color.FromRgb(210, 210, 210);
			calendar.Today.Font.Color = Color.Black;
			calendar.Today.Font.Size = 14;
			calendar.WeekDays.Font.Size = 16;
			calendar.WeekDays.Font.Color = Color.FromRgb(150, 150, 150);
			calendar.WeekDays.TextAlign = TextAlignment.Start;
			calendar.WeekDays.Pen.Width = 1;
			calendar.Days.Font.Size = 14;
			calendar.Days.TextAlign = TextAlignment.Start;
			calendar.WeekDays.Color = Color.Transparent;
			calendar.Sunday.Color = Color.Transparent;
			calendar.Sunday.Font.Size = 14;
			calendar.Sunday.Font.Color = Color.Black;
			calendar.Sunday.Pen.Width = 0;
			calendar.Sunday.Pen.Visible = false;
			calendar.Months.Visible = false;

			//calendar.Active = true;

			BaseChart.Chart.ClickSeries += Chart_ClickSeries;

			BaseChart.Chart.Panning.Active = true;

            NextBackButtonsUpdate();

        }

        // Click en el calendario modifica la "cell" seleccionada
		private void Chart_ClickSeries(object sender, Series s, int valueIndex, MouseEventArgs e)
		{

			var chart = sender as Chart;

			calendar.SetCell(e.X, e.Y);
			labelHeader.Text = MyConvert.NumericMonthToString(calendar.Date.Month) + ", " + calendar.Date.Year.ToString();

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
            labelHeader.Text = MyConvert.NumericMonthToString(calendar.Date.Month) + ", " + calendar.Date.Year.ToString();

        }

        // Vuelve un mes atras - backButton
        private void BackButton_Clicked(object sender, EventArgs e)
        {

            calendar.PreviousMonth();
            labelHeader.Text = MyConvert.NumericMonthToString(calendar.Date.Month) + ", " + calendar.Date.Year.ToString();

        }
    }
}
