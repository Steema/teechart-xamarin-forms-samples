using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace TeeChartDashBoards.DashBoards
{
    public class Page7 : ContentPage
    {
        public ChartView dashChart;
        
        public Page7()
        {
            dashChart = new ChartView();
						dashChart.WidthRequest = 400;
						dashChart.HeightRequest = 300;

						dashChart.Chart.Aspect.View3D = false;
            Steema.TeeChart.Styles.TagCloud series = new Steema.TeeChart.Styles.TagCloud();
						dashChart.Chart.Series.Add(series);
						series.FillSampleValues(20);

						// TagCloud
						dashChart.Chart.Panel.Color = Color.White;
						dashChart.Chart.Panel.Gradient.Visible = false;
						dashChart.Chart.Footer.Text = "TagCloud";
						dashChart.Chart.Footer.Alignment = TextAlignment.End;
						dashChart.Chart.Footer.Font.Size = 12;
						dashChart.Chart.Footer.Font.Color = Color.Navy;
						dashChart.Chart.Footer.Visible = true;
						dashChart.Chart.Title.Visible = false;
						//dashChart.Chart.Title.Font.Name = "";
						dashChart.Chart.Legend.Visible = false;

            Content = new StackLayout
            {
							Children = {
									dashChart
							},
							VerticalOptions = LayoutOptions.CenterAndExpand,
							HorizontalOptions = LayoutOptions.CenterAndExpand,
						};
        }
    }
}
