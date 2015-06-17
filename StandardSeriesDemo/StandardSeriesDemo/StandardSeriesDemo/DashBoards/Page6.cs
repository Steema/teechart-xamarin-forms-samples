using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace StandardSeriesDemo.DashBoards
{
    public class Page6 : ContentPage
    {
        Chart dashChart;
        public ChartView DashView5;
        public Page6()
        {
            // NavigationPage.SetHasNavigationBar(this, false);    

            dashChart = new Chart();
            dashChart.Aspect.View3D = false;
            Steema.TeeChart.Styles.Area area1 = new Steema.TeeChart.Styles.Area();
            Steema.TeeChart.Styles.Area area2 = new Steema.TeeChart.Styles.Area();
            dashChart.Series.Add(area1);
            dashChart.Series.Add(area2);

            area2.Transparency = 50;
            area1.Gradient.Visible = true;
            area2.Gradient.Visible = true;
            area1.AreaLinesPen.Visible = false;
            area2.AreaLinesPen.Visible = false;
            area1.LinePen.Color = Color.White;
            area1.LinePen.Width = 2;
            area2.LinePen.Color = Color.White;
            area2.LinePen.Width = 2;
            area1.Gradient.StartColor = Color.FromRgb(255, 255, 255);
            area1.Gradient.EndColor = Color.FromRgb(186, 85, 211);
            area2.Gradient.StartColor = Color.FromRgb(255, 255, 255);
            area2.Gradient.EndColor = Color.FromRgb(186, 85, 211);

            dashChart.Axes.Left.Visible = false;
            dashChart.Axes.Bottom.AxisPen.Color = Color.White;
            dashChart.Axes.Bottom.Labels.Font.Color = Color.White;

            Random rnd1 = new Random();
            for (int i = 0; i < 40; i++)
            {
                area1.Add(rnd1.Next(100));
                area2.Add(rnd1.Next(70));
            }

            area1.Smoothed = true;
            area2.Smoothed = true;

            dashChart.Axes.Bottom.SetMinMax(10, 30);

            // Areas and Points
            dashChart.Panel.Color = Color.FromRgb(186, 85, 211);
            dashChart.Panel.Gradient.Visible = false;
            dashChart.Title.Text = "Areas and Points";
            dashChart.Title.Alignment = TextAlignment.End;
            dashChart.Title.Font.Size = 12;
            dashChart.Title.Font.Color = Color.White;
            //dashBoard0.Title.Font.Name = "";
            dashChart.Legend.Visible = false;
            dashChart.Walls.Back.Visible = false;


            DashView5 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            DashView5.Model = dashChart;

            Content = new StackLayout
            {
                Children = {
					DashView5
				}
            };
        }
    }
}
