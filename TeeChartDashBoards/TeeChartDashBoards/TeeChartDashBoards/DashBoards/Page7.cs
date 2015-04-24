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
        Chart dashChart;
        public ChartView DashView6;
        public Page7()
        {
            // NavigationPage.SetHasNavigationBar(this, false);            

            dashChart = new Chart();
            dashChart.Aspect.View3D = false;
            Steema.TeeChart.Styles.TagCloud series = new Steema.TeeChart.Styles.TagCloud();
            dashChart.Series.Add(series);
            series.FillSampleValues(20);

            // TagCloud
            dashChart.Panel.Color = Color.White;
            dashChart.Panel.Gradient.Visible = false;
            dashChart.Footer.Text = "TagCloud";
            dashChart.Footer.Alignment = TextAlignment.End;
            dashChart.Footer.Font.Size = 12;
            dashChart.Footer.Font.Color = Color.Navy;
            dashChart.Footer.Visible = true;
            dashChart.Title.Visible = false;
            //dashBoard0.Title.Font.Name = "";
            dashChart.Legend.Visible = false;

            DashView6 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            DashView6.Model = dashChart;

            Content = new StackLayout
            {
                Children = {
					DashView6
				}
            };
        }
    }
}
