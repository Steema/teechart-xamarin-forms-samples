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
        Chart tChart1 = new Chart();
        Points series = new Points();
        Annotation annotation;
        CursorTool cursor;

        public SnapCursorToolTip()
        {
            // Values to Series
            series.FillSampleValues();
            tChart1.Series.Add(series);

            // Chart settings
            tChart1.Aspect.View3D = false;
            tChart1.Panel.Gradient.Visible = false;
            tChart1.Legend.Visible = false;
            tChart1.Panel.Color = Color.White;
            tChart1.Walls.Back.Transparent = true;
            tChart1.SubHeader.Visible = true;
            tChart1.SubHeader.Text = "";     

            // Use of the Chart events :
            tChart1.ClickBackground += TChart1_ClickBackground;
            tChart1.ScrollMod += TChart1_ScrollMod;
            tChart1.Zoomed += TChart1_Zoomed;
            tChart1.UndoneZoom += TChart1_UndoneZoom;
            series.ClickPointer += Series_ClickPointer;
            //tChart1.ClickSeries += TChart1_ClickSeries;
            //tChart1.AfterDraw += TChart1_AfterDraw;
            //tChart1.Scroll += TChart1_Scroll;

            series.ClickTolerance = 10;

            // Panning and Scroll modes
            tChart1.Zoom.Active = true;
            tChart1.Panning.Active = true;
            tChart1.Panning.Allow = ScrollModes.Horizontal;
            

            // Use of the Cursor Tool
            cursor = new CursorTool(tChart1.chart);            
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
            annotation = new Annotation(tChart1.chart);
            annotation.Active = false;
            annotation.Shape.Font.Size = 16;
            annotation.TextAlign = TextAlignment.Center;            

            // Axes settings
            tChart1.Axes.Left.Increment = tChart1.Axes.Left.Maximum / 10;
            tChart1.Axes.Left.Labels.Font.Size -= 4;

            // Them settings
            tChart1.setTheme(ThemeType.Flat);

            // Header settings
            tChart1.Header.Font.Size = 11;
            
            // Chart to View
            ChartView chartView = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,

                WidthRequest = 400,
                HeightRequest = 500
            };

            chartView.Model = tChart1;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Fill,
                Children = {
                        chartView,
                    }
            };

            // property like userinteraction for ios enabling scrollview to scroll over the chart.
            // chartView.InputTransparent = true;
        }

        private void TChart1_UndoneZoom(object sender, EventArgs e)
        {
            tChart1.Header.Text = "UnZoom XAxis min : " + tChart1.Axes.Bottom.Minimum.ToString() + " XAxis max : " +
                 tChart1.Axes.Bottom.Maximum.ToString();
            tChart1.SubHeader.Text = "UnZoom YAxis min : " + tChart1.Axes.Left.Minimum.ToString() + " YXAxis max : " +
                 tChart1.Axes.Left.Maximum.ToString();
        }

        private void TChart1_Zoomed(object sender, EventArgs e)
        {
            tChart1.Header.Text = "Zoom XAxis min : " + tChart1.Axes.Bottom.Minimum.ToString() + " XAxis max : " +
                tChart1.Axes.Bottom.Maximum.ToString();
            tChart1.SubHeader.Text = "Zoom YAxis min : " + tChart1.Axes.Left.Minimum.ToString() + " YXAxis max : " +
                tChart1.Axes.Left.Maximum.ToString();
        }

        private void TChart1_ScrollMod(Axis a, ScrollModEventArgs e)
        {
            tChart1.Header.Text = "Scroll min : " + e.Min.ToString() + " max : " + e.Max.ToString();
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
            tChart1.Header.Text = "Chart Tapped";
        }

        private void Series_ClickPointer(Steema.TeeChart.Styles.CustomPoint series, int valueIndex, double x, double y)
        {
            tChart1.Header.Text = "Point index clicked : " + valueIndex.ToString();
        }

        private void TChart1_ClickSeries(object sender, Steema.TeeChart.Styles.Series s, int valueIndex, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
        }
    }
}
