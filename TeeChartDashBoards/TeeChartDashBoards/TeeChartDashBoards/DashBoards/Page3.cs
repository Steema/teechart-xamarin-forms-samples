using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace TeeChartDashBoards.DashBoards
{
    public class Page3 : ContentPage
    {
        Chart dashChart;
        public ChartView DashView2;
        public Page3()
        {
            // NavigationPage.SetHasNavigationBar(this, false);            

            dashChart = new Chart();
            dashChart.Aspect.View3D = false;
            Steema.TeeChart.Styles.CircularGauge series = new Steema.TeeChart.Styles.CircularGauge();            
            dashChart.Series.Add(series);
            series.FillSampleValues();

            //Gauges chart
            dashChart.Panel.Color = Color.FromRgb(220,20,60);
            dashChart.Panel.Gradient.Visible = false;
            dashChart.Walls.Back.Visible = false;
            dashChart.Footer.Text = "Gauges";
            dashChart.Footer.Alignment = TextAlignment.Center;
            dashChart.Footer.Visible = true;
            dashChart.Header.Visible = false;
            dashChart.Footer.Font.Size = 12;
            dashChart.Footer.Font.Color = Color.White;
            dashChart.Legend.Visible = false;

            dashChart.Axes.Left.Visible = true;
            dashChart.Axes.Left.Labels.Visible = false;
            dashChart.Axes.Left.Ticks.Visible = false;
            dashChart.Axes.Left.TicksInner.Visible = false;
            dashChart.Axes.Left.Labels.Font.Color = Color.White;
            series.Axis.TicksInner.Visible = false;
            series.Axis.Ticks.Visible = false;
            series.Axis.Labels.Visible = false;
       
            series.FaceBrush.Visible = false;
            series.Frame.Visible = false;
            series.FaceBrush.Gradient.Visible = false;
            series.Axis.AxisPen.Color = Color.White;
            series.Axis.Ticks.Visible = false;
            series.Axis.TicksInner.Length = 3;
            series.RedLine.Gradient.StartColor = Color.White;
            series.GreenLine.Gradient.EndColor = Color.White;
            series.Hand.Gradient.EndColor = Color.White;
            series.Center.Gradient.Visible = false;
            series.Center.Color = Color.White;
            series.Value = 50;

            DashView2 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            DashView2.Model = dashChart;

            Content = new StackLayout
            {
                Children = {
					DashView2
				}
            };
        }
    }
}
