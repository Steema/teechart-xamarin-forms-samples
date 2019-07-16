using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZoomPanningDemo
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        Steema.TeeChart.ChartView _chartView;

        public MainPage()
        {
            InitializeComponent();
            _chartView = new Steema.TeeChart.ChartView();

            _chartView.Chart.Zoom.Active = true;
            _chartView.Chart.Zoom.Allow = true;
            _chartView.Chart.Panning.Active = true;
            _chartView.Chart.Zoom.Direction = Steema.TeeChart.ZoomDirections.Both;
            _chartView.Chart.Panning.Allow = Steema.TeeChart.ScrollModes.Both;
            _chartView.HorizontalOptions = LayoutOptions.FillAndExpand;
            _chartView.VerticalOptions = LayoutOptions.FillAndExpand;
            _chartView.HeightRequest = 100;
            _chartView.WidthRequest = 100;

            Line line = new Line(_chartView.Chart);
            Line line2 = new Line(_chartView.Chart);

            line.FillSampleValues();
            line2.FillSampleValues();

            line.LinePen.Color = Color.Red;
            line.LineHeight = 5;
            line.LinePen.Width = 5;
            line.Title = "Line 1";
            line2.LinePen.Color = Color.Blue;
            line2.LineHeight = 5;
            line2.LinePen.Width = 5;
            line2.Title = "Line 2";

            pckZoom.SelectedIndex = 0;
            pckPanning.SelectedIndex = 0;

            (this.Content as StackLayout).Children.Add(_chartView);
        }

        private void ChangeZoomDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = (string)(sender as Picker).SelectedItem;
            if(item == "Vertical")
            {
                _chartView.Chart.Zoom.Direction = Steema.TeeChart.ZoomDirections.Vertical;
            }
            else if(item == "Horizontal")
            {
                _chartView.Chart.Zoom.Direction = Steema.TeeChart.ZoomDirections.Horizontal;
            }
            else if(item == "Both")
            {
                _chartView.Chart.Zoom.Direction = Steema.TeeChart.ZoomDirections.Both;
            }
            else
            {
                _chartView.Chart.Zoom.Direction = Steema.TeeChart.ZoomDirections.None;
            }
        }

        private void ChangePanningMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = (string)(sender as Picker).SelectedItem;
            if (item == "Vertical")
            {
                _chartView.Chart.Panning.Allow = Steema.TeeChart.ScrollModes.Vertical;
            }
            else if (item == "Horizontal")
            {
                _chartView.Chart.Panning.Allow = Steema.TeeChart.ScrollModes.Horizontal;
            }
            else if (item == "Both")
            {
                _chartView.Chart.Panning.Allow = Steema.TeeChart.ScrollModes.Both;
            }
            else
            {
                _chartView.Chart.Panning.Allow = Steema.TeeChart.ScrollModes.None;
            }
        }

    }
}
