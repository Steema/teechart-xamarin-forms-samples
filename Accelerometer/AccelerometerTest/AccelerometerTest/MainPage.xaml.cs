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
using System.Diagnostics;

namespace AccelerometerTest
{
    public partial class MainPage : ContentPage
    {

        private CircularGauge _circularGauge;
        private ChartView _chartView;
        private AccelerationVector _accelerationVector;

        public MainPage()
        {
            InitializeComponent();

            _chartView = InitializeChartView();
            _circularGauge = InitializeCircularGauge();
            _accelerationVector = AccelerationVector.X;

            stkChart.Children.Add(_chartView);
        }

        /// <summary>
        /// Initialize ChartView
        /// </summary>
        private ChartView InitializeChartView()
        {
            ChartView chartView = new ChartView();
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
            return chartView;
        }

        /// <summary>
        /// Create series
        /// </summary>
        /// <returns>CircularGauge</returns>
        private CircularGauge InitializeCircularGauge()
        {
            CircularGauge gauge = new CircularGauge(_chartView.Chart);

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
                Accelerometer.Start(SensorSpeed.UI);
                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            }
            catch(FeatureNotSupportedException exception)
            {
                Debug.WriteLine(exception.Message);
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Alert", "Accelerometer Unavailable", "OK");
                    _circularGauge.Value = 0;
                    _chartView.Chart.Title.Text = "Accelerometer Unavailable";
                    _chartView.Chart.Title.Color = Color.Red;
                });
            }
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            float value = 0;
            switch(_accelerationVector)
            {
                case AccelerationVector.X:
                    value = e.Reading.Acceleration.X;
                    break;
                case AccelerationVector.Y:
                    value = e.Reading.Acceleration.Y;
                    break;
                case AccelerationVector.Z:
                    value = e.Reading.Acceleration.Z;
                    break;
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                _circularGauge.Value = value;
            });
        }

        /// <summary>
        /// Change Accelerometer Reading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAcceleration_Clicked(object sender, EventArgs e)
        {
            string selectedButton = (sender as Button).Text.ToUpper();

            switch (selectedButton)
            {
                case "X":
                    _chartView.Chart.SubTitle.Text = "X Axis";
                    _accelerationVector = AccelerationVector.X;
                    break;

                case "Y":
                    _chartView.Chart.SubTitle.Text = "Y Axis";
                    _accelerationVector = AccelerationVector.Y;
                    break;

                case "Z":
                    _chartView.Chart.SubTitle.Text = "Z Axis";
                    _accelerationVector = AccelerationVector.Z;
                    break;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeAccelerometer();
        }

        private enum AccelerationVector
        {
            X,
            Y,
            Z
        }
        
    }
}
