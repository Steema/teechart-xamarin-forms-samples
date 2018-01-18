using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;


namespace TeeChartDemo.PCL.Other
{
    public partial class SnapCursorToolTip : ContentPage
    {
        ChartView tChart1 = new ChartView();
        Points series = new Points();
        Annotation annotation;
        CursorTool cursor;

        public SnapCursorToolTip()
        {
            // Values to Series
            series.FillSampleValues();
            tChart1.Chart.Series.Add(series);

            // Chart settings
            tChart1.Chart.Aspect.View3D = false;
            tChart1.Chart.Panel.Gradient.Visible = false;
            tChart1.Chart.Legend.Visible = false;
            tChart1.Chart.Panel.Color = Color.White;
            tChart1.Chart.Walls.Back.Transparent = true;
            tChart1.Chart.SubHeader.Visible = true;
            tChart1.Chart.SubHeader.Text = "";

            // Use of the Chart events :
            tChart1.Chart.ClickBackground += TChart1_ClickBackground;
            tChart1.Chart.ScrollMod += TChart1_ScrollMod;
            tChart1.Chart.Zoomed += TChart1_Zoomed;
            tChart1.Chart.UndoneZoom += TChart1_UndoneZoom;
            series.ClickPointer += Series_ClickPointer;
            //tChart1.ClickSeries += TChart1_ClickSeries;
            //tChart1.AfterDraw += TChart1_AfterDraw;
            //tChart1.Scroll += TChart1_Scroll;

            series.ClickTolerance = 10;

            // Panning and Scroll modes
            tChart1.Chart.Zoom.Active = true;
            tChart1.Chart.Panning.Active = true;
            tChart1.Chart.Panning.Allow = ScrollModes.Horizontal;
            

            // Use of the Cursor Tool
            cursor = new CursorTool(tChart1.Chart.chart);            
            cursor.SnapChange += Cursor_SnapChange;
            cursor.CursorClickTolerance = 1000;
            cursor.Style = CursorToolStyles.Both;
            cursor.Snap = true;
            cursor.Series = series;
            cursor.FollowMouse = true;
            cursor.FastCursor = true;
            cursor.Pen.Visible = false;
            // In the case to Active the CursorTool Panning ScrollMode has to be set to None
            ////tChart1.Panning.Allow = ScrollModes.None;
            cursor.Active = false;
            //cursor.Change += Cursor_Change;

            // Use of Annotation Tool            
            annotation = new Annotation(tChart1.Chart.chart);
            annotation.Active = false;
            annotation.Shape.Font.Size = 16;
            annotation.TextAlign = TextAlignment.Center;

            // Axes settings
            tChart1.Chart.Axes.Left.Increment = tChart1.Chart.Axes.Left.Maximum / 10;
            tChart1.Chart.Axes.Left.Labels.Font.Size -= 4;

            // Them settings
            tChart1.Chart.setTheme(ThemeType.Flat);

            // Header settings
            tChart1.Chart.Header.Font.Size = 11;

            tChart1.WidthRequest = 400;
            tChart1.HeightRequest = 500;

            Content = new StackLayout
            {
                Children = {
                        tChart1,
                    },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            // property like userinteraction for ios enabling scrollview to scroll over the chart.
            // chartView.InputTransparent = true;
        }

        private void TChart1_UndoneZoom(object sender, EventArgs e)
        {
            tChart1.Chart.Header.Text = "UnZoom XAxis min : " + tChart1.Chart.Axes.Bottom.Minimum.ToString() + " XAxis max : " +
                 tChart1.Chart.Axes.Bottom.Maximum.ToString();
            tChart1.Chart.SubHeader.Text = "UnZoom YAxis min : " + tChart1.Chart.Axes.Left.Minimum.ToString() + " YXAxis max : " +
                 tChart1.Chart.Axes.Left.Maximum.ToString();
        }

        private void TChart1_Zoomed(object sender, EventArgs e)
        {
            tChart1.Chart.Header.Text = "Zoom XAxis min : " + tChart1.Chart.Axes.Bottom.Minimum.ToString() + " XAxis max : " +
                tChart1.Chart.Axes.Bottom.Maximum.ToString();
            tChart1.Chart.SubHeader.Text = "Zoom YAxis min : " + tChart1.Chart.Axes.Left.Minimum.ToString() + " YXAxis max : " +
                tChart1.Chart.Axes.Left.Maximum.ToString();
        }

        private void TChart1_ScrollMod(Axis a, ScrollModEventArgs e)
        {
            tChart1.Chart.Header.Text = "Scroll min : " + e.Min.ToString() + " max : " + e.Max.ToString();
        }

        private void Cursor_SnapChange(object sender, Steema.TeeChart.Tools.CursorChangeEventArgs e)
        {
        }

        private void Cursor_Change(object sender, Steema.TeeChart.Tools.CursorChangeEventArgs e)
        {
            annotation.Text = e.YValue.ToString();
            annotation.Left = e.x - (annotation.Bounds.Width / 2);
            annotation.Top = e.y;
        }

        private void TChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
        }

        private void TChart1_ClickBackground(object sender, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
            tChart1.Chart.Header.Text = "Chart Tapped";
        }

        private void Series_ClickPointer(Steema.TeeChart.Styles.CustomPoint series, int valueIndex, double x, double y)
        {
            tChart1.Chart.Header.Text = "Point index clicked : " + valueIndex.ToString();
        }

        private void TChart1_ClickSeries(object sender, Steema.TeeChart.Styles.Series s, int valueIndex, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
        }
    }
}
