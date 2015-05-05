using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace TeeChartDashBoards.DashBoards
{
    public class Page4 : ContentPage
    {
        Chart dashChart;
        public ChartView DashView3;
        public Page4()
        {
            // NavigationPage.SetHasNavigationBar(this, false);            

            dashChart = new Chart();
            dashChart.Aspect.View3D = false;
            Steema.TeeChart.Styles.Bubble series = new Steema.TeeChart.Styles.Bubble();
            dashChart.Series.Add(series);
            series.FillSampleValues(6);
            series.Pointer.Gradient.Visible = true;
            series.ColorEach = false;
            series.Pointer.Pen.Visible = false;
            series.Color = Color.White;
            series.Pointer.Gradient.StartColor = Color.White;
            series.Pointer.Gradient.EndColor = Color.FromRgb(255, 165, 0);           

            //Bubble chart
            dashChart.Panel.Color = Color.FromRgb(255,165,0);
            dashChart.Panel.Gradient.Visible = false;
            dashChart.Walls.Back.Visible = false;
            dashChart.Title.Text = "Bubbles";
            dashChart.Title.Alignment = TextAlignment.Start;
            dashChart.Title.Font.Size = 12;
            dashChart.Title.Font.Color = Color.White;
            dashChart.Legend.Visible = false;
            dashChart.Axes.Left.AxisPen.Visible = false;
            dashChart.Axes.Left.Labels.Color = Color.FromRgb(255, 165, 0); 
            dashChart.Axes.Bottom.AxisPen.Visible = false;
            dashChart.Axes.Left.Grid.Color = Color.White;
            dashChart.Axes.Left.Increment = 25;
            dashChart.Axes.Bottom.Grid.Color = Color.White;
            dashChart.Axes.Left.Grid.Fill.Gradient.Visible = true;

            dashChart.Axes.Bottom.Labels.Font.Color = Color.FromRgb(255, 165, 0);
            dashChart.Axes.Left.Labels.Font.Color = Color.FromRgb(255, 165, 0);

            DashView3 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            DashView3.Model = dashChart;

            Content = new StackLayout
            {
                Children = {
					DashView3
				}
            };
        }
    }
}
