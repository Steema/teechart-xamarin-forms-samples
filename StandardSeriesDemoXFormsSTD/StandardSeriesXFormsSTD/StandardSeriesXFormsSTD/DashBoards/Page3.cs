using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace StandardSeriesXFormsSTD.DashBoards
{
    public class Page3 : ContentPage
    {
        public ChartView dashChart;        
        public Page3()
        {
            // NavigationPage.SetHasNavigationBar(this, false);            

            dashChart = new ChartView();
            dashChart.WidthRequest = 400;
            dashChart.HeightRequest = 300;

            dashChart.Chart.Aspect.View3D = false;
            Steema.TeeChart.Styles.CircularGauge series = new Steema.TeeChart.Styles.CircularGauge();            
            dashChart.Chart.Series.Add(series);
            series.FillSampleValues();

            //Gauges chart
            dashChart.Chart.Panel.Color = Color.FromRgb(220,20,60);
            dashChart.Chart.Panel.Gradient.Visible = false;
            dashChart.Chart.Walls.Back.Visible = false;
            dashChart.Chart.Footer.Text = "Gauges";
            dashChart.Chart.Footer.Alignment = TextAlignment.Center;
            dashChart.Chart.Footer.Visible = true;
            dashChart.Chart.Header.Visible = false;
            dashChart.Chart.Footer.Font.Size = 12;
            dashChart.Chart.Footer.Font.Color = Color.White;
            dashChart.Chart.Legend.Visible = false;

            dashChart.Chart.Axes.Left.Visible = true;
            dashChart.Chart.Axes.Left.Labels.Visible = false;
            dashChart.Chart.Axes.Left.Ticks.Visible = false;
            dashChart.Chart.Axes.Left.TicksInner.Visible = false;
            dashChart.Chart.Axes.Left.Labels.Font.Color = Color.White;
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

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    dashChart
                }
            };
        }
    }
}
