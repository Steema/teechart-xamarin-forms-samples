using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace TeeChartDashBoards.DashBoards
{
    public class Page5 : ContentPage
    {
        public ChartView dashChart;
        public Page5()
        {            
            dashChart = new ChartView();
						dashChart.WidthRequest = 400;
						dashChart.HeightRequest = 300;

						dashChart.Chart.Aspect.View3D = false;
            Steema.TeeChart.Styles.Pie pie1 = new Steema.TeeChart.Styles.Pie();
						dashChart.Chart.Series.Add(pie1);

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
						dashChart.Chart.Panel.Color = Color.FromRgb(255,105,180);
						dashChart.Chart.Panel.Gradient.Visible = false;
						dashChart.Chart.Title.Text = "Pies and Donuts";
						dashChart.Chart.Title.Alignment = TextAlignment.Center;
						dashChart.Chart.Title.Font.Size = 12;
						dashChart.Chart.Title.Font.Color = Color.White;
						dashChart.Chart.Title.Height = 30;
						//dashBoard0.Title.Font.Name = "";
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
