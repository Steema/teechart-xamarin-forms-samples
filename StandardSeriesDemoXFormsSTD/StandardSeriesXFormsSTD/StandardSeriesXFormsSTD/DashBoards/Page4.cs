using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace StandardSeriesXFormsSTD.DashBoards
{
    public class Page4 : ContentPage
    {
        public ChartView dashChart;        
        public Page4()
        {
            // NavigationPage.SetHasNavigationBar(this, false);            

            dashChart = new ChartView();
            dashChart.WidthRequest = 400;
            dashChart.HeightRequest = 300;

            dashChart.Chart.Aspect.View3D = false;
            Steema.TeeChart.Styles.Bubble series = new Steema.TeeChart.Styles.Bubble();
            dashChart.Chart.Series.Add(series);
            series.FillSampleValues(6);
            series.Pointer.Gradient.Visible = true;
            series.ColorEach = false;
            series.Pointer.Pen.Visible = false;
            series.Color = Color.White;
            series.Pointer.Gradient.StartColor = Color.White;
            series.Pointer.Gradient.EndColor = Color.FromRgb(255, 165, 0);           

            //Bubble chart
            dashChart.Chart.Panel.Color = Color.FromRgb(255,165,0);
            dashChart.Chart.Panel.Gradient.Visible = false;
            dashChart.Chart.Walls.Back.Visible = false;
            dashChart.Chart.Title.Text = "Bubbles";
            dashChart.Chart.Title.Alignment = TextAlignment.Start;
            dashChart.Chart.Title.Font.Size = 12;
            dashChart.Chart.Title.Font.Color = Color.White;
            dashChart.Chart.Legend.Visible = false;
            dashChart.Chart.Axes.Left.AxisPen.Visible = false;
            dashChart.Chart.Axes.Left.Labels.Color = Color.FromRgb(255, 165, 0); 
            dashChart.Chart.Axes.Bottom.AxisPen.Visible = false;
            dashChart.Chart.Axes.Left.Grid.Color = Color.White;
            dashChart.Chart.Axes.Left.Increment = 25;
            dashChart.Chart.Axes.Bottom.Grid.Color = Color.White;
            dashChart.Chart.Axes.Left.Grid.Fill.Gradient.Visible = true;

            dashChart.Chart.Axes.Bottom.Labels.Font.Color = Color.FromRgb(255, 165, 0);
            dashChart.Chart.Axes.Left.Labels.Font.Color = Color.FromRgb(255, 165, 0);

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
