using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;
using Xamarin.Forms;
using Steema.TeeChart.Styles;
using System.Threading.Tasks;

namespace WeatherApp.DashBoard
{
    public class CircularGaugeChart
    {

        public ChartView chartView = new ChartView();
        
        public CircularGauge wndSpeedGauge;
        public CircularGaugeChart(ActualWeather weather)
        {
            double max = 0, min = 0;
            foreach (var item in weather.LstWeather)
            {
                if (item.WindSpeed > max) max = item.WindSpeed;
                if (item.WindSpeed < min) min = item.WindSpeed;
            }

            wndSpeedGauge = new CircularGauge(chartView.Chart);

            chartView.Chart.Header.Font.Size = 10;
            chartView.Chart.Title.Alignment = TextAlignment.Start;            
            chartView.Chart.Header.TextAlign = TextAlignment.Center;            
            chartView.Chart.Header.Size.Height = 50;
            chartView.Chart.Panel.Gradient.Visible = false;

            wndSpeedGauge.MinorTicks.Visible = true;
            wndSpeedGauge.Minimum = min;
            wndSpeedGauge.Maximum = 10;
            wndSpeedGauge.GreenLineStartValue = 0;
            wndSpeedGauge.GreenLineEndValue = max - max * 0.2;
            wndSpeedGauge.RedLineStartValue = max-max*0.2;
            wndSpeedGauge.RedLineEndValue = max+max*0.1;
            wndSpeedGauge.TotalAngle = 300;
            //wndSpeedGauge.Axis.Increment = 10;
            wndSpeedGauge.Frame.InnerBand.Gradient.Visible = false;
            wndSpeedGauge.Frame.OuterBand.Gradient.Visible = false;
            wndSpeedGauge.Frame.MiddleBand.Gradient.Visible = false;

            wndSpeedGauge.FaceBrush.Gradient.Visible = false;
            wndSpeedGauge.FaceBrush.Color = Color.White;
            wndSpeedGauge.CircleBackColor = Color.White;

            chartView.Chart.Panel.Color = Color.FromHex("#46BBBD");

            chartView.Chart.Axes.Left.Labels.Font.Color = Color.Black;
            chartView.Chart.Axes.Left.Labels.Font.Gradient.Visible = false;
            chartView.Chart.Axes.Left.Increment = 1;

        }

    }
}
