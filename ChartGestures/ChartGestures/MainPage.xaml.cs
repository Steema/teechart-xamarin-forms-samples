using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChartGestures
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AddSeries();
            AddListeners();
        }

        private void AddSeries()
        {
            Color[] colors = new Color[3] { Color.Red, Color.Blue, Color.Green };
            for(int i = 0; i < 3; i++)
            {
                Line line = new Line(chartView.Chart)
                {
                    Color = colors[i],
                    LinePen = new Steema.TeeChart.Drawing.ChartPen()
                    {
                        Width = 2,
                    }
                };
                line.FillSampleValues();
            }
        }

        private void AddListeners()
        {
            chartView.Chart.DoubleClickBackground += Chart_DoubleClickBackground;
            chartView.Chart.ClickBackground += Chart_ClickBackground;
            // add Zome Listeners
            chartView.Chart.Zoom.Active = true;
            chartView.Chart.Zoom.Allow = true;
            chartView.Chart.Zoom.Direction = Steema.TeeChart.ZoomDirections.Both;
            chartView.Chart.Zoomed += Chart_Zoomed;
            chartView.Chart.UndoneZoom += Chart_UndoneZoom;

            chartView.Chart.Touch.Options = Steema.TeeChart.TouchOptions.Drag;
            chartView.Chart.Panning.Active = true;
            chartView.Chart.Panning.Allow = Steema.TeeChart.ScrollModes.Both;

            btnPanning.Clicked += (sender, e) =>
            {
                chartView.Chart.Touch.Options = Steema.TeeChart.TouchOptions.Drag;
            };
            if (Device.RuntimePlatform != Device.UWP)
            {
                btnZoom.Clicked += (sender, e) =>
                {
                    chartView.Chart.Touch.Options = Steema.TeeChart.TouchOptions.Pinch;
                };
            }
        }

        private void Chart_UndoneZoom(object sender, EventArgs e)
        {
            lblAction.Text = "ChartView Unzoom";
        }
        private void Chart_Zoomed(object sender, EventArgs e)
        {
            lblAction.Text = "ChartView Zoomed";
        }
        private void Chart_ClickBackground(object sender, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
            lblAction.Text = "ChartView Click";
        }
        private void Chart_DoubleClickBackground(object sender, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
            lblAction.Text = "ChartView DoubleClick";
        }
    }
}
