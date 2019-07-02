using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamControls.Data.Series;
using XamControls.PCL.Models;
using XamControls.PCL.ViewModels;
using XamControls.PCL.Utils;
using XamControls.Data.Payloads;

namespace XamControls.PCL.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeriesPage : TabbedPage
    {

        SeriesPageViewModel _seriesPageViewModel;
        ChartView _chartView;
        Random random = new Random();

        public SeriesPage(SeriesGroupItem seriesGroupItem)
        {
            _seriesPageViewModel = new SeriesPageViewModel();
            _seriesPageViewModel.SeriesGroupItem = seriesGroupItem;
            BindingContext = _seriesPageViewModel;
            InitializeComponent();
            this.Title = _seriesPageViewModel.SeriesGroupItem.SeriesGroup.SeriesGroupToFriendlyName();
            SetUpPage();
        }

        private void SetUpPage()
        {
            InitializePages();
            InitializeCurrentChart();
            SetLastThings();
        }

        private void SetLastThings()
        {
            if(this.Children.Count > 1)
            {
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this, Xamarin.Forms.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Bottom);
                //Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.
            }
        }

        void InitializeCurrentChart()
        {
            Data.Series.SeriesGroup seriesGroup = _seriesPageViewModel.SeriesGroupItem.SeriesGroup;
            
            switch (seriesGroup)
            {
                case Data.Series.SeriesGroup.Standard:
                    AddLineSeries();
                    break;
                case Data.Series.SeriesGroup.Advanced:
                    break;
            }
        }

        View InitializeChartView()
        {
            if (_chartView == null)
            {
                _chartView = new ChartView();
                _chartView.HorizontalOptions = LayoutOptions.FillAndExpand;
                _chartView.VerticalOptions = LayoutOptions.FillAndExpand;
                _chartView.WidthRequest = 500;
                _chartView.HeightRequest = 500;
                _chartView.Chart.Legend.Alignment = LegendAlignments.Bottom;
                _chartView.Chart.Legend.LegendStyle = LegendStyles.Series;
                _chartView.Chart.Title.Font.Size = 20;
                _chartView.Chart.Title.Alignment = TextAlignment.Center;
                _chartView.Chart.Title.TextAlign = TextAlignment.Center;
                _chartView.Chart.Axes.Left.Labels.ValueFormat = "0K";
                _chartView.Chart.Axes.Bottom.Increment = 1;
                _chartView.Chart.Axes.Left.Visible = true;
                _chartView.Chart.Axes.Left.Title = null;
                _chartView.Chart.Axes.Bottom.Title = null;
                _chartView.Chart.Axes.Left.AxisPen.Visible = false;
                _chartView.Chart.Axes.Left.Ticks.Visible = false;
                _chartView.Chart.Axes.Left.Grid.Visible = true;
                _chartView.Chart.Axes.Bottom.Grid.Visible = false;

                switch (Device.RuntimePlatform)
                {
                    case Device.UWP:
                        _chartView.Chart.Panel.MarginLeft = 3;
                        _chartView.Chart.Panel.MarginTop = 0;
                        _chartView.Chart.Panel.MarginRight = 3;
                        _chartView.Chart.Panel.MarginBottom = 4;
                        _chartView.Chart.Panning.Allow = ScrollModes.None;
                        break;
                    case Device.Android:
                        _chartView.Chart.Panel.MarginLeft = 5;
                        _chartView.Chart.Panel.MarginTop = 5;
                        _chartView.Chart.Panel.MarginRight = 5;
                        _chartView.Chart.Panel.MarginBottom = 5;
                        break;
                }
            }
            else
            {

            }
            return _chartView;
        }

        void InitializePages()
        {
            ContentPage contentPage = new ContentPage();
            this.Children.Add(contentPage);
            contentPage.Title = "TYPES";
            contentPage.Content = InitializeChartView();
        }

        #region SERIES

        void AddLineSeries()
        {
            Dictionary<int, ListPayload<string, int>> GenerateData()
            {
                Dictionary<int, ListPayload<string, int>> data = new Dictionary<int, ListPayload<string, int>>();
                ListPayload<string, int> dataLine1 = new ListPayload<string, int>();
                ListPayload<string, int> dataLine2 = new ListPayload<string, int>();
                string[] months = {"January", "February", "March", "April", "May", "June", "July", "August", "September",
                    "October", "November", "December" };
                for (int i = 0; i < 12; i++)
                {
                    dataLine1.Values.Add(random.Next(11));
                    dataLine1.DateTimes.Add(months[i]);
                    dataLine2.Values.Add(random.Next(11));
                    dataLine2.DateTimes.Add(months[i]);
                }
                data.Add(0, dataLine1);
                data.Add(1, dataLine2);
                return data;
            }
            void CreateLineSeries()
            {
                Line line1 = new Line(_chartView.Chart);
                Line line2 = new Line(_chartView.Chart);
                var data = GenerateData();

                line1.Color = Utils.Helpers.GetColorResource(XamControls.PCL.Resources.Resources.SERIES_COLOR_1);
                line2.Color = Utils.Helpers.GetColorResource(XamControls.PCL.Resources.Resources.SERIES_COLOR_2);
                line1.Title = "Births";
                line2.Title = "Deaths";

                for(int i = 0; i < _chartView.Chart.Series.Count; i++)
                {
                    Line serie = _chartView.Chart.Series[i] as Line;
                    var serieData = data[i];
                    serie.LinePen.Width = 2;
                    serie.Pointer.Visible = true;
                    serie.Pointer.Style = PointerStyles.Circle;
                    serie.Add(serieData.DateTimes.ToArray(), serieData.Values.ToArray());
                }

                _chartView.Chart.Legend.Visible = true;
                _chartView.Chart.Axes.Left.Grid.Visible = true;
                _chartView.Chart.Axes.Left.Grid.Color = Color.FromRgb(230, 230, 230);
                _chartView.Chart.Header.Text = "Deaths and Births in Spain";
                _chartView.Chart.Axes.Bottom.Labels.DateTimeFormat = "hh:mm";
            }
            void AddEventsHandlers()
            {
                void AddCursorTool()
                {
                    Steema.TeeChart.Tools.CursorTool cursorTool = new Steema.TeeChart.Tools.CursorTool(_chartView.Chart);
                    cursorTool.FollowMouse = true;
                    cursorTool.Series = _chartView.Chart.Series[0];
                    cursorTool.Style = Steema.TeeChart.Tools.CursorToolStyles.Vertical;
                    cursorTool.Pen.Color = Color.Red;
                    cursorTool.Pen.Width = 2;
                    cursorTool.Active = true;
                    cursorTool.Change += CursorTool_Change;
                    cursorTool.Snap = true;
                    Steema.TeeChart.Tools.ColorLine colorLine = new Steema.TeeChart.Tools.ColorLine(_chartView.Chart)
                    {
                        Active = true,
                    };              
                }
                AddCursorTool();
            }
            
            CreateLineSeries();
            AddEventsHandlers();
            Debug.WriteLine(_chartView.Chart.Series[0].ValueMarkText(0));
        }
        private void CursorTool_Change(object sender, Steema.TeeChart.Tools.CursorChangeEventArgs e)
        {
            Debug.WriteLine("Snap -> " + e.SnapPoint);
            Debug.WriteLine("Value Index:" + e.ValueIndex + ";" + "X" + e.x + ";Y" + e.y + ";XV" + e.XValue + ";YV" + e.YValue);
        }
        private void Chart_ClickSeries(object sender, Series s, int valueIndex, MouseEventArgs e)
        {
            Debug.WriteLine(valueIndex);
        }

        #endregion

    }
}