using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SnapCursorTool
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private Points _points = new Points();
        private Steema.TeeChart.Tools.Annotation _annotation;
        private Steema.TeeChart.Tools.CursorTool _cursorTool;

        public MainPage()
        {
            InitializeComponent();

            InitChart();
        }

        void InitChart()
        {
            // Theme settings
            chartView.Chart.setTheme(ThemeType.Flat);

            chartView.Chart.Header.Visible = true;

            // Values to Series
            _points.FillSampleValues();
            chartView.Chart.Series.Add(_points);

            // Chart settings
            chartView.Chart.Aspect.View3D = false;
            chartView.Chart.Panel.Gradient.Visible = false;
            chartView.Chart.Legend.Visible = false;
            chartView.Chart.Panel.Color = Color.White;
            chartView.Chart.Walls.Back.Transparent = true;

            chartView.Chart.Axes.Bottom.Labels.DateTimeFormat = "yyyy-MM-dd";
            _points.XValues.DateTime = true;
            chartView.Chart.Axes.Bottom.Labels.Angle = 90;


            // Use of the Chart events:
            //tChart1.Chart.ClickBackground += TChart1_ClickBackground;
            //tChart1.Chart.ScrollMod += TChart1_ScrollMod;
            //series.ClickPointer += Series_ClickPointer;            
            //tChart1.Chart.Scroll += Chart_Scroll;

            _points.ClickTolerance = 10;
            _points.Pointer.Pen.Visible = false;
            _points.Pointer.Style = PointerStyles.Circle;
            _points.Pointer.HorizSize = 4;
            _points.Pointer.VertSize = 4;
            _points.ColorEachPoint = true;

            // Panning and Scroll modes
            chartView.Chart.Zoom.Active = true;
            chartView.Chart.Zoom.Allow = true;

            chartView.Chart.chart.Zoom.Active = true;
            chartView.Chart.Chart.Zoom.Allow = true;

            chartView.Chart.Zoom.Direction = ZoomDirections.Both;
            chartView.Chart.Panning.Active = true;
            chartView.Chart.Panning.Allow = ScrollModes.Horizontal;

            AddCursorTool();

            // Use of Annotation Tool
            _annotation = new Steema.TeeChart.Tools.Annotation(chartView.Chart.chart);
            _annotation.Active = true;
            _annotation.Shape.Font.Size = 10;
            _annotation.TextAlign = TextAlignment.Center;
            _annotation.Left = 30;
            _annotation.Top = 50;


            // Axes settings
            chartView.Chart.Axes.Left.Increment = chartView.Chart.Axes.Left.Maximum / 10;
            chartView.Chart.Axes.Left.Labels.Font.Size = 10;
            chartView.Chart.Axes.Bottom.Labels.Font.Size = 10;

            // Header settings
            chartView.Chart.Header.Font.Size = 11;

            // Controlling zoom in and zoom out
            chartView.Chart.Zoomed += Chart_Zoomed; ;
        }

        private void Chart_Scroll(object sender, EventArgs e)
        {
            chartView.Chart.Title.Text = "Scroll!";
        }

        private void Chart_Zoomed(object sender, EventArgs e)
        {
            chartView.Chart.Title.Text = "Zoomed!";
        }

        private void AddCursorTool()
        {

            // Use of the Cursor Tool
            _cursorTool = new Steema.TeeChart.Tools.CursorTool(chartView.Chart.chart);
            _cursorTool.SnapChange += CursorTool_SnapChange;
            _cursorTool.CursorClickTolerance = 1000;
            _cursorTool.Style = Steema.TeeChart.Tools.CursorToolStyles.Vertical;
            _cursorTool.Pen.Color = Color.Blue;
            _cursorTool.Snap = true;
            _cursorTool.Series = _points;
            _cursorTool.FollowMouse = false;
            //cursor.FastCursor = true;

            // In the case to Active the CursorTool Panning ScrollMode has to be set to None
            //tChart1.Panning.Allow = ScrollModes.None;
            _cursorTool.Active = true;
            _cursorTool.Change += CursorTool_Change; ;
        }

        private void TChart1_ScrollMod(Axis a, ScrollModEventArgs e)
        {
            chartView.Chart.Header.Text = "Scroll min : " + e.Min.ToString() + " max : " + e.Max.ToString();
        }

        private void CursorTool_SnapChange(object sender, Steema.TeeChart.Tools.CursorChangeEventArgs e)
        {
            
        }

        private void CursorTool_Change(object sender, Steema.TeeChart.Tools.CursorChangeEventArgs e)
        {
            if (e.SnapPoint != -1)
            {
                chartView.Chart.Header.Text = "Snap Point : " + e.SnapPoint.ToString();
                _annotation.Text = chartView.Chart.Series[0].YValues[e.SnapPoint].ToString();
                _annotation.Left = e.x - (_annotation.Bounds.Width / 2);
                _annotation.Top = chartView.Chart.Series[0].CalcYPos(e.SnapPoint);
            }
        }

        private void TChart1_ClickBackground(object sender, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
            chartView.Chart.Header.Text = "Chart Tapped";
        }

        private void Series_ClickPointer(Steema.TeeChart.Styles.CustomPoint series, int valueIndex, double x, double y)
        {
            chartView.Chart.Header.Text = "Pointer Value Index : " + valueIndex.ToString();
        }
    }
}
