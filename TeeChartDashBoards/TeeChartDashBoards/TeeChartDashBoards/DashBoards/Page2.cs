using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace TeeChartDashBoards.DashBoards
{
    public class Page2 : ContentPage
    {
        public ChartView dashBoard1;        
        public Page2()
        {
            dashBoard1 = new ChartView();
						dashBoard1.WidthRequest = 400;
						dashBoard1.HeightRequest = 300;

						dashBoard1.Chart.Aspect.View3D = false;
            Steema.TeeChart.Styles.World world1 = new Steema.TeeChart.Styles.World();
						dashBoard1.Chart.Series.Add(world1);
            world1.FillSampleValues();
            world1.UsePalette = false;
            world1.UseColorRange = false;
            world1.SeriesColor = Color.White;

						dashBoard1.Chart.Panel.Color = Color.Blue;
						dashBoard1.Chart.Panel.Gradient.Visible = false;
						dashBoard1.Chart.Walls.Visible = false;
						dashBoard1.Chart.Title.Text = "Maps";
						dashBoard1.Chart.Title.Alignment = TextAlignment.Start;
						dashBoard1.Chart.Title.Font.Size = 12;
						dashBoard1.Chart.Title.Font.Color = Color.White;
						dashBoard1.Chart.Axes.Visible = false;
						dashBoard1.Chart.Legend.Visible = false;

            Content = new StackLayout
            {
							Children = {
								dashBoard1
							},
							VerticalOptions = LayoutOptions.CenterAndExpand,
							HorizontalOptions = LayoutOptions.CenterAndExpand,
						};
        }
    }
}
