using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using Xamarin.Essentials;
using System.Threading;

namespace AccelerometerTest
{
    public partial class MainPage : TabbedPage
    {

        private CircularGauge circularGaugeX;
        private CircularGauge circularGaugeY;
        private CircularGauge circularGaugeZ;
        private int axis = 0;

        public MainPage()
        {
            InitializeComponent();

            this.CurrentPage = xContentPage;

            InitializePages(ChartX);
            InitializePages(ChartY);
            InitializePages(ChartZ);

            circularGaugeX = InitializeGauge();
            circularGaugeY = InitializeGauge();
            circularGaugeZ = InitializeGauge();

            InitializeAccelerometer();

            ChartX.Chart.Series.Add(circularGaugeX);
            ChartY.Chart.Series.Add(circularGaugeY);
            ChartZ.Chart.Series.Add(circularGaugeZ);

            threadAccelerometer = new Thread(InitializeAccelerometer);
        }

        /// <summary>
        /// Custom chartView
        /// </summary>
        /// <param name="chartView"></param>
        private void InitializePages(ChartView chartView)
        {
            chartView.Chart.Title.Text = "Accelerometer Circular Gauge";
            chartView.Chart.Title.Alignment = TextAlignment.Center;
            chartView.Chart.Title.TextAlign = TextAlignment.End;
            chartView.Chart.SubTitle.Text = "X Axis";
            chartView.Chart.SubTitle.Visible = true;
            chartView.Chart.SubTitle.Font.Size += 6;
            chartView.Chart.Title.Font.Size += 6;
            chartView.Chart.Title.Font.Bold = true;
            chartView.Chart.Axes.Left.Increment = 0.2;
            chartView.Chart.Axes.Left.Labels.Font.Color = Color.FromRgb(110, 110, 110);
            chartView.Chart.Axes.Left.Labels.Font.Size += 7;
            chartView.HorizontalOptions = LayoutOptions.FillAndExpand;
            chartView.VerticalOptions = LayoutOptions.FillAndExpand;
        }

        /// <summary>
        /// Create serie
        /// </summary>
        /// <returns></returns>
        private CircularGauge InitializeGauge()
        {
            CircularGauge gauge = new CircularGauge();

            gauge.Title = "Accelerometer Circular Gauge";
            gauge.Maximum = 1;
            gauge.Minimum = -1;
            gauge.GreenLine.Visible = false;
            gauge.RedLine.Visible = false;
            gauge.Frame.Width = 1;
            gauge.Hand.Gradient.Visible = false;
            gauge.Hand.Color = Color.FromRgb(170, 170, 170);
            gauge.HandOffset = 0;
            gauge.Hand.Style = PointerStyles.DownTriangle;
            gauge.Hand.HorizSize += 10;
            gauge.Center.Gradient.Visible = false;
            gauge.Center.Color = Color.FromRgb(170, 170, 170);
            gauge.Center.Shadow.Visible = false;
            gauge.Center.HorizSize += 10;
            gauge.Center.VertSize += 10;
            gauge.FaceBrush.Color = Color.White;
            gauge.FaceBrush.Gradient.Visible = false;
            gauge.Hand.HorizSize += 4;
            gauge.Hand.VertSize += 4;
            gauge.Ticks.VertSize = 10;
            gauge.Ticks.HorizSize = 2;
            gauge.MinorTicks.Visible = true;
            gauge.MinorTickDistance = 3;
            gauge.MinorTicks.HorizSize = 1;
            gauge.MinorTicks.VertSize = 5;
            gauge.Ticks.Pen.Visible = false;
            gauge.Ticks.Color = Color.FromRgb(140, 140, 140);
            gauge.RotateLabels = false;
            gauge.Frame.OuterBand.Visible = false;
            gauge.Frame.MiddleBand.Visible = false;
            gauge.Frame.InnerBand.Visible = true;
            gauge.Frame.InnerBand.Gradient.Visible = false;
            gauge.Frame.InnerBand.Color = Color.FromRgb(120, 120, 120);

            return gauge; 
        }

        private void InitializeAccelerometer()
        {
            try
            {
                Accelerometer.Start(SensorSpeed.Fastest);
                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            }
            catch(FeatureNotSupportedException)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Alert", "Accelerometer Unavailable", "OK");
                    circularGaugeX.Value = 0;
                    circularGaugeY.Value = 0;
                    circularGaugeZ.Value = 0;
                    ChartX.Chart.Title.Text = "Accelerometer Unavailable";
                    ChartX.Chart.Title.Color = Color.Red;
                    ChartY.Chart.Title.Text = "Accelerometer Unavailable";
                    ChartY.Chart.Title.Color = Color.Red;
                    ChartZ.Chart.Title.Text = "Accelerometer Unavailable";
                    ChartZ.Chart.Title.Color = Color.Red;
                });
            }
        }

        Thread threadAccelerometer;

        /// <summary>
        /// Change page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            var tabbedPage = sender as TabbedPage;

            if(tabbedPage.CurrentPage == xContentPage)
            {
                axis = 0;
                ChartX.Chart.SubTitle.Text = "X Axis";
                if(circularGaugeY != null) circularGaugeY.Value = 0;
                if (circularGaugeZ != null) circularGaugeZ.Value = 0;
            }
            else if(tabbedPage.CurrentPage == yContentPage)
            {
                axis = 1;
                ChartY.Chart.SubTitle.Text = "Y Axis";
                circularGaugeX.Value = 0;
                circularGaugeZ.Value = 0;
            }
            else
            { 
                axis = 2;
                ChartZ.Chart.SubTitle.Text = "Z Axis";
                circularGaugeY.Value = 0;
                circularGaugeX.Value = 0;
            }
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            CircularGauge circularGauge;
            float newValue;
            if (axis == 0)
            {
                circularGauge = circularGaugeX;
                newValue = e.Reading.Acceleration.X;
            }
            else if (axis == 1)
            {
                circularGauge = circularGaugeY;
                newValue = e.Reading.Acceleration.Y;
            }
            else
            {
                circularGauge = circularGaugeZ;
                newValue = e.Reading.Acceleration.Z;
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                circularGauge.Value = newValue;
            });
        }

    }
}
