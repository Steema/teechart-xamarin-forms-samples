using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PieChart
{

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private Steema.TeeChart.Styles.Pie pie;
        ChartView PieChart;
        Steema.TeeChart.Tools.Annotation ann = new Steema.TeeChart.Tools.Annotation();

        public MainPage()
        {
            InitializeComponent();

            PieChart = new ChartView();
            pie = new Steema.TeeChart.Styles.Pie();
            PieChart.Chart.ClickSeries += Chart_ClickSeries;
            PieChart.Chart.Series.Add(pie);

            PieChart.HorizontalOptions = LayoutOptions.FillAndExpand;
            PieChart.VerticalOptions = LayoutOptions.FillAndExpand;

            PieChart.Chart.Panning.Allow = ScrollModes.None;

            PieChart.Chart.Panel.Gradient.Visible = false;
            PieChart.Chart.Panel.Color = Color.White;
            PieChart.Chart.Walls.Back.Visible = false;
            PieChart.Chart.Header.Visible = false;

            PieChart.Chart.Legend.Visible = false;
            PieChart.Chart.Aspect.View3D = false;

            PieChart.WidthRequest = 650;
            PieChart.HeightRequest = 350;

            pie.Chart.Zoom.Allow = false;
            pie.Chart.Panning.Allow = ScrollModes.None;
            pie.AutoCircleResize = false;
            pie.RecalcOptions = RecalcOptions.OnModify;
            pie.DefaultNullValue = 0;
            pie.Circled = true;
            pie.AutoPenColor = false;
            pie.DarkPen = false;
            pie.Pen.Style = DashStyle.Solid;
            pie.Pen.Visible = true;
            pie.VertAxis = VerticalAxis.Both;
            pie.HorizAxis = HorizontalAxis.Both;
            pie.Pen.Color = Color.White;
            pie.Pen.Width = 3;
            pie.Marks.Visible = false;
            pie.FillSampleValues(4);

            PieChart.Chart.Axes.Left.SetMinMax(PieChart.Chart.Axes.Left.MinYValue, PieChart.Chart.Axes.Left.MaxYValue);
            PieChart.Chart.Axes.Bottom.SetMinMax(PieChart.Chart.Axes.Bottom.MinYValue, PieChart.Chart.Axes.Bottom.MaxXValue);

            PieChart.Chart.Axes.Bottom.Increment = 5;
            PieChart.Chart.Axes.Left.Increment = 5;

            PieChart.Chart.Axes.Left.Visible = true;
            PieChart.Chart.Axes.Left.AxisPen.Visible = true;
            PieChart.Chart.Axes.Left.Ticks = new Axis.TicksPen { Width = 2, Visible = true, Color = Color.FromRgb(200, 200, 200), EndCap = PenLineCap.Flat, Style = DashStyle.Solid, Length = 10, };
            PieChart.Chart.Axes.Bottom.Visible = true;

            PieChart.Chart.Axes.Left.Title.Angle = 90;
            PieChart.Chart.Axes.Left.Grid.Visible = false;
            PieChart.Chart.Axes.Bottom.Grid.Visible = false;

            PieChart.Chart.Panel.Brush.Solid = true;

            PieChart.Chart.Tools.Add(ann);
            ann.Active = false;
            ann.Shape.Font.Size = 25;
            ann.Shape.TextAlign = TextAlignment.Center;
            ann.TextAlign = TextAlignment.Center;
            ann.Shape.Pen.Color = ann.Shape.Color;
            ann.AutoSize = false;

            if (Device.RuntimePlatform == Device.iOS)
            {
                ann.Shape.Width = 80;
                ann.Shape.Height = 40;
            }
            else if(Device.RuntimePlatform == Device.Android)
            {
                ann.Shape.Width = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Width / 6;
                ann.Shape.Height = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Height / 23;
            }
            else
            {
                pie.Marks.Visible = true;
                pie.MarksPie.InsideSlice = true;
            }

            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);

            Content = PieChart;
        }

        private void Chart_ClickSeries(object sender, Steema.TeeChart.Styles.Series s, int valueIndex, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
            ann.Active = true;
            ann.Text = pie.PieValues.Value[valueIndex].ToString();
            ann.Left = e.X - ann.Width / 2;
            ann.Top = e.Y - 20;
        }
    }
}
