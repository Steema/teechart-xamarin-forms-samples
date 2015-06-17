using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace StandardSeriesDemo.DashBoards
{
    public class Page5 : ContentPage
    {
        Chart dashChart;
        public ChartView DashView4;
        public Page5()
        {
            // NavigationPage.SetHasNavigationBar(this, false);            

            dashChart = new Chart();
            dashChart.Aspect.View3D = false;
            Steema.TeeChart.Styles.Pie pie1 = new Steema.TeeChart.Styles.Pie();
            dashChart.Series.Add(pie1);

            //pie
            pie1.Circled = true;
            pie1.Add(476, "Tables", Color.White);
            pie1.Add(883, "Chairs", Color.FromRgb(242, 242, 242));
            pie1.Add(537, "Sofas", Color.FromRgb(223, 223, 223));
            pie1.Add(364, "Cupboards", Color.FromRgb(215, 215, 215));
            pie1.Marks.Visible = true;
            pie1.Marks.Transparent = true;
            pie1.Pen.Color = Color.FromRgb(255, 105, 180);
            pie1.Pen.Width = 3;
            pie1.Marks.Arrow.Visible = false;
            pie1.Marks.ArrowLength = -25;
            pie1.Marks.Font.Color = Color.FromRgb(255, 105, 180);

            // Pie and Donut chart
            dashChart.Panel.Color = Color.FromRgb(255,105,180);
            dashChart.Panel.Gradient.Visible = false;
            dashChart.Title.Text = "Pies and Donuts";
            dashChart.Title.Alignment = TextAlignment.Center;
            dashChart.Title.Font.Size = 12;
            dashChart.Title.Font.Color = Color.White;
            dashChart.Title.Height = 30;
            //dashBoard0.Title.Font.Name = "";
            dashChart.Legend.Visible = false;

            DashView4 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            DashView4.Model = dashChart;

            Content = new StackLayout
            {
                Children = {
					DashView4
				}
            };
        }
    }
}
