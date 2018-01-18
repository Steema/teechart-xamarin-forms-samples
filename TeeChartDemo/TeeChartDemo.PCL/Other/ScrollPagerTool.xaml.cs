using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using Steema.TeeChart.Themes;
using Steema.TeeChart.Drawing;

namespace TeeChartDemo.PCL.Other
{
    public partial class ScrollPagerTool : ContentPage
    {
        ChartView tChart1 = new ChartView();
        FastLine series;
        private ScrollPager tool;
        private ColorLine colorlinetool;
        NearestPoint point;
        Annotation annotate;

        public ScrollPagerTool()
        {
            InitializeChart();

            tChart1.WidthRequest = 400;
            tChart1.HeightRequest = 500;

            Content = new StackLayout
            {
                Children = { tChart1 },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
        }

        private void InitializeChart()
        {
            tChart1.Chart.Header.Text = "Scroll Pager Tool";
            tChart1.Chart.Panning.Active = true;
            tChart1.Chart.Series.Add(series = new FastLine());
            series.FillSampleValues(1000);

            tChart1.Chart.Tools.Add(tool = new ScrollPager());

            for (int i = 0; i < tChart1.Chart.Series.Count; i++)
            {
                if (tChart1.Chart.Series[i].Count > 0)
                    tool.Series = tChart1.Chart.Series[i];
            }

            tool.ColorBandTool.StartLine.AllowDrag = true;
            tool.ColorBandTool.EndLine.AllowDrag = true;
            tool.ColorBandTool.StartLine.Active = true;
            tool.ColorBandTool.EndLine.Active = true;


            tChart1.Chart.Tools.Add(colorlinetool = new ColorLine());
            colorlinetool.Value = 100;
            colorlinetool.AllowDrag = true;
            colorlinetool.Pen.Color = Color.Blue;

            tChart1.Chart.ClickBackground += TChart1_ClickBackground;

            tChart1.Chart.Tools.Add(point = new NearestPoint());
            tChart1.Chart.Tools.Add(annotate = new Annotation());

            point.Brush.Color = tool.PointerHighlightColor;
            point.DrawLine = false;
            point.Size = 6;
            point.Direction = NearestPointDirection.Horizontal;
            point.Series = series;
            point.Change += new EventHandler(point_Change);

            annotate.Position = AnnotationPositions.RightTop;
            annotate.Text = "YValue:";
            annotate.Shape.Shadow.Visible = false;
            annotate.Shape.Font.Color = tChart1.Chart.Header.Font.Color;
            annotate.Shape.Color = tool.PointerHighlightColor;
            annotate.Shape.Pen.Visible = false;
            annotate.Shape.Font.Color = Color.White;
            annotate.TextAlign = TextAlignment.Center;

            //Theme.ApplyChartTheme(typeof(FlatTheme), tool.SubChartTChart.Chart);
        }

        private void TChart1_ClickBackground(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

        }

        void point_Change(object sender, EventArgs e)
        {
            if (point.Point > -1)
            {
                annotate.Text = "YValue: " + series.YValues[point.Point];
            }
        }

        private void Tools_ScrollPager_SizeChanged(object sender, EventArgs e)
        {
            /* temp commented
            tool.Series = series;
            
            tool.SubChartTChart.Panel.Pen.Visible = false;
            tool.SubChartTChart.Panel.Bevel.Inner = BevelStyles.None;
            tool.SubChartTChart.Panel.Bevel.Outer = BevelStyles.None;
            */
        }
    }
}
