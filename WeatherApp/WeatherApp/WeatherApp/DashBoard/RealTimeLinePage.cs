using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace WeatherApp.DashBoard
{
    public class RealTimeLine
    {
        public ChartView chartView = new ChartView();
        public Points wndSpeedLinear;
        public RealTimeLine()
        {
            wndSpeedLinear = new Points(chartView.Chart);
            wndSpeedLinear.Color = Color.FromHex("#79b782");
            wndSpeedLinear.Add(0, 0);
            wndSpeedLinear.XValues.DateTime = true;
            wndSpeedLinear.Color = Color.White;
            wndSpeedLinear.ColorEach = false;
            wndSpeedLinear.Pointer.Pen.Visible = false;
            wndSpeedLinear.Pointer.VertSize = 3;
            wndSpeedLinear.Pointer.HorizSize = 3;

            chartView.Chart.Axes.Left.Labels.Font.Size = 12;
            chartView.Chart.Axes.Left.Increment = 1;
            chartView.Chart.Axes.Left.MaximumOffset = 15;
            chartView.Chart.Axes.Left.MinimumOffset = 15;
            chartView.Chart.Axes.Bottom.MaximumOffset = 15;
            chartView.Chart.Axes.Bottom.MinimumOffset = 15;
            chartView.Chart.Axes.Bottom.Labels.Font.Size = 12;
            chartView.Chart.Axes.Bottom.Labels.Angle = 90;
            chartView.Chart.Axes.Bottom.Labels.Visible = true;
            chartView.Chart.Axes.Bottom.Labels.DateTimeFormat = "dd/MMM";
            chartView.Chart.Aspect.View3D = false;
            chartView.Chart.Axes.Bottom.Automatic = false;
            chartView.Chart.Header.Font.Size = 12;
            chartView.Chart.Header.TextAlign = TextAlignment.Center;
            chartView.Chart.Header.Font.Color = Color.White;
            chartView.Chart.Header.Alignment = TextAlignment.End;
            chartView.Chart.Panel.Gradient.Visible = false;
            chartView.Chart.Legend.Visible = false;
            chartView.Chart.Axes.Automatic = true;
            chartView.Chart.Panel.MarginBottom = 5;
            chartView.Chart.Axes.Left.AxisPen.Visible = false;
            chartView.Chart.Axes.Left.Grid.Color = Color.White;
            chartView.Chart.Axes.Bottom.AxisPen.Width = 2;
            chartView.Chart.Axes.Bottom.AxisPen.Color = Color.White;
            chartView.Chart.Axes.Bottom.Grid.Visible = false;
            chartView.Chart.Axes.Bottom.Labels.Font.Size = 10;
            chartView.Chart.Axes.Bottom.Labels.Font.Color = Color.White;
            chartView.Chart.Axes.Left.Labels.Font.Size = 10;
            chartView.Chart.Axes.Left.Labels.Font.Color = Color.White;
            chartView.Chart.Walls.Back.Visible = false;
            chartView.Chart.Axes.Bottom.Ticks.Length = 10;
            chartView.Chart.Axes.Left.Ticks.Length = 10;

            chartView.VerticalOptions = LayoutOptions.FillAndExpand;
            chartView.HorizontalOptions = LayoutOptions.FillAndExpand;

        }

    }
}