using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace StandardSeriesDemo.DashBoards
{
    public class Page1 : ContentPage
    {
        Chart dashBoard0;
        public ChartView DashView0;
        public Page1()
        {
            // NavigationPage.SetHasNavigationBar(this, false);            

            dashBoard0 = new Chart();
            dashBoard0.Aspect.View3D = false;
            Steema.TeeChart.Styles.Bar bar1 = new Steema.TeeChart.Styles.Bar();
            Steema.TeeChart.Styles.Line line1 = new Steema.TeeChart.Styles.Line();
            dashBoard0.Series.Add(bar1);
            dashBoard0.Series.Add(line1);
            //barline chart
            bar1.Clear();
            bar1.Add(20);
            bar1.Add(50);
            bar1.Add(10);
            bar1.Add(70);
            bar1.Add(46);
            bar1.Pen.Visible = false;
            bar1.BarStyle = Steema.TeeChart.Styles.BarStyles.RectGradient;
            bar1.Marks.Visible = false;
            bar1.Gradient.StartColor = Color.White;
            bar1.Gradient.EndColor = Color.FromRgb(102, 205, 170);
            bar1.Marks.Visible = true;
            bar1.Marks.Shadow.Visible = false;
            bar1.Marks.Color = Color.White;
            bar1.Marks.Font.Size = 10;
            bar1.Marks.Font.Color = Color.FromRgb(102, 205, 170);
            bar1.Marks.Pen.Visible = false;
            bar1.Marks.ArrowLength = 5;
            bar1.Color = Color.White;

            line1.Clear();
            line1.Add(0, 45);
            line1.Add(0.444444444444444, 55);
            line1.Add(0.888888888888889, 75);
            line1.Add(1.33333333333333, 65);
            line1.Add(1.77777777777778, 45);
            line1.Add(2.22222222222222, 80);
            line1.Add(2.66666666666667, 85);
            line1.Add(3.11111111111111, 98);
            line1.Add(3.55555555555556, 75);
            line1.Add(4, 68);
            line1.Color = Color.FromRgb(255, 255, 240);

            line1.LinePen.Width = 3;
            line1.Smoothed = true;

            dashBoard0.Panel.Color = Color.FromRgb(102, 205, 170);
            dashBoard0.Panel.Gradient.Visible = false;
            dashBoard0.Walls.Back.Visible = false;
            dashBoard0.Title.Text = "Bars and Lines";
            dashBoard0.Title.Alignment = TextAlignment.Start;
            dashBoard0.Title.Font.Size = 12;
            dashBoard0.Title.Font.Color = Color.White;
            //dashBoard0.Title.Font.Name = "";
            dashBoard0.Axes.Left.AxisPen.Visible = false;
            dashBoard0.Axes.Bottom.AxisPen.Color = Color.White;
            dashBoard0.Legend.Visible = false;
            dashBoard0.Axes.Left.Grid.Color = Color.White;
            dashBoard0.Axes.Left.Grid.Style = Steema.TeeChart.Drawing.DashStyle.Dot;
            dashBoard0.Axes.Left.Labels.Font.Color = Color.White;
            dashBoard0.Axes.Bottom.Labels.Font.Color = Color.White;
            dashBoard0.Axes.Left.Increment = 25;

            DashView0 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            DashView0.Model = dashBoard0;

            Content = new StackLayout
            {
                Children = {
					DashView0
				}
            };
        }
    }
}