using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using Xamarin.Forms;
using XamControls.Variables;
using Steema.TeeChart.Drawing;

namespace XamControls.Charts.Calendar
{
	public partial class EventCalendarChart
    {

		private Steema.TeeChart.Styles.Calendar calendar;

		public EventCalendarChart(ChartView BaseChart)
		{

			calendar = new Steema.TeeChart.Styles.Calendar();

			BaseChart.Chart.Header.Text = MyConvert.NumericMonthToString(calendar.Date.Month) + ", " + calendar.Date.Year.ToString();
			BaseChart.Chart.Header.TextAlign = TextAlignment.End;
			BaseChart.Chart.Header.Visible = false;
			BaseChart.Chart.Header.Font.Color = Color.FromRgb(70, 70, 70);
			BaseChart.Chart.Header.Text = "EventCalendar";

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
			calendar.Sunday.Pen.Width = 1;
			calendar.Months.Visible = false;

			BaseChart.Chart.ClickSeries += Chart_ClickSeries;

		}

		private void Chart_ClickSeries(object sender, Series s, int valueIndex, Steema.TeeChart.Drawing.MouseEventArgs e)
		{

			var chart = sender as Chart;
			calendar.SetCell(e.X, e.Y);
			//Steema.TeeChart.Styles.Calendar.CalendarCell cell = new Steema.TeeChart.Styles.Calendar.CalendarCell();
			calendar[calendar.Clicked(e.Location)].Color = Color.Red;
			chart.Header.Text = MyConvert.NumericMonthToString(calendar.Date.Month) + ", " + calendar.Date.Year.ToString();

		}

        // Botones que permiten moverse entre los meses
        private void NextBackButtonsUpdate()
        {

            //var backButton = ((labelHeader.Parent as Grid).Children[1] as Button);
            //var nextButton = ((.Parent as Grid).Children[2] as Button);

            //backButton.Clicked += BackButton_Clicked;
            //nextButton.Clicked += NextButton_Clicked;

        }

        // Permite ir al siguiente mes - nextButton
        private void NextButton_Clicked(object sender, EventArgs e)
        {

            calendar.NextMonth();
            //labelHeader.Text = MyConvert.NumericMonthToString(calendar.Date.Month) + ", " + calendar.Date.Year.ToString();

        }

        // Vuelve un mes atras - backButton
        private void BackButton_Clicked(object sender, EventArgs e)
        {

            calendar.PreviousMonth();
            //labelHeader.Text = MyConvert.NumericMonthToString(calendar.Date.Month) + ", " + calendar.Date.Year.ToString();

        }

    }
}
